using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CodePulseAPI.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetListAsync()
        {
            var category = await dbContext.Categories.ToListAsync();
            return  category;
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);            
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> RemoveAsync(Category category)
        {

            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
            return category;

        }
    }
}
