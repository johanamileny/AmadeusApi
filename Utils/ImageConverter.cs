using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace AmadeusApi.Utils
{
    public static class ImageConverter
    {
        private static string _baseImagePath;
        private static string _projectRootPath;
        private static ILogger _logger;

        public static void Initialize(string baseImagePath, ILoggerFactory loggerFactory = null)
        {
            _baseImagePath = baseImagePath;
            _projectRootPath = Directory.GetParent(baseImagePath).Parent.FullName;
            
            if (loggerFactory != null)
            {
                _logger = loggerFactory.CreateLogger("ImageConverter");
            }
        }

        public static string ConvertImagePathToBase64(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return null;

            try
            {
                // Remove leading "/" if present
                if (imagePath.StartsWith("/"))
                    imagePath = imagePath.Substring(1);

                string fullPath;
                
                // Check if the path already contains Resources/img
                if (imagePath.StartsWith("Resources/img") || imagePath.StartsWith("Resources\\img"))
                {
                    // Use project root path instead of base image path
                    fullPath = Path.Combine(_projectRootPath, imagePath);
                }
                else
                {
                    // Use the base image path for just the filename
                    fullPath = Path.Combine(_baseImagePath, imagePath);
                }
                
                _logger?.LogInformation($"Attempting to load image from: {fullPath}");

                if (!File.Exists(fullPath))
                {
                    _logger?.LogWarning($"Image file not found: {fullPath}");
                    return imagePath; // Return original path if file not found
                }

                // Read image file and convert to base64
                byte[] imageBytes = File.ReadAllBytes(fullPath);
                string base64String = Convert.ToBase64String(imageBytes);

                // Determine content type based on file extension
                string contentType = GetContentType(Path.GetExtension(imagePath));
                
                _logger?.LogInformation($"Successfully converted image to base64: {imagePath}");
                
                // Format as data URL
                return $"data:{contentType};base64,{base64String}";
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error converting image to base64: {ex.Message}");
                return imagePath; // Return original path if conversion fails
            }
        }

        private static string GetContentType(string extension)
        {
            switch (extension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".webp":
                    return "image/webp";
                default:
                    return "application/octet-stream";
            }
        }
    }
}