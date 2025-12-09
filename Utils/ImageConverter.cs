using System;
using System.IO;

namespace AmadeusApi.Utils
{
    public static class ImageConverter
    {
        public static string ConvertImageToBase64(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                return string.Empty;
            }

            byte[] imageBytes = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }

        public static void ConvertBase64ToImage(string base64String, string outputPath)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                throw new ArgumentException("Base64 string cannot be null or empty", nameof(base64String));
            }

            byte[] imageBytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(outputPath, imageBytes);
        }
    }
}
