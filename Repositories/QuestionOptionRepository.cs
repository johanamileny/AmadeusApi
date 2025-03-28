using Amadeus.Models;
using AmadeusApi.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amadeus.Repositories
{
    public class QuestionOptionRepository
    {
        private readonly AmadeusDbContext _context;

        public QuestionOptionRepository(AmadeusDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestionOption>> GetAllAsync()
        {
            var options = await _context.QuestionOptions.ToListAsync();
            ConvertImagesToBase64(options);
            return options;
        }

        public async Task<QuestionOption> GetByIdAsync(int id)
        {
            var option = await _context.QuestionOptions.FindAsync(id);
            if (option != null)
            {
                ConvertImageToBase64(option);
            }
            return option;
        }

        public async Task<IEnumerable<QuestionOption>> GetByQuestionIdAsync(int questionId)
        {
            var options = await _context.QuestionOptions
                .Where(option => option.QuestionId == questionId)
                .ToListAsync();
            
            ConvertImagesToBase64(options);
            return options;
        }

        public async Task AddAsync(QuestionOption questionOption)
        {
            await _context.QuestionOptions.AddAsync(questionOption);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(QuestionOption questionOption)
        {
            _context.QuestionOptions.Update(questionOption);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var questionOption = await _context.QuestionOptions.FindAsync(id);
            if (questionOption != null)
            {
                _context.QuestionOptions.Remove(questionOption);
                await _context.SaveChangesAsync();
            }
        }

        // Helper methods to convert images to Base64
        private void ConvertImagesToBase64(IEnumerable<QuestionOption> options)
        {
            foreach (var option in options)
            {
                ConvertImageToBase64(option);
            }
        }

        private void ConvertImageToBase64(QuestionOption option)
        {
            if (!string.IsNullOrEmpty(option.Image))
            {
                option.Image = ImageConverter.ConvertImagePathToBase64(option.Image);
            }
        }
    }
}
