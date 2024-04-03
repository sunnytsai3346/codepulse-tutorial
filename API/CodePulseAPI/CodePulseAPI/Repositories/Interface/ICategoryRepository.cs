using CodePulseAPI.Models.Domain;

namespace CodePulseAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category category);

        public Task<List<Category>> GetListAsync();

        public Task<Category> GetByIdAsync(Guid id);

        public Task<Category> UpdateAsync(Category category);

        public Task<Category> RemoveAsync(Category category);

    }
}
