using CodePulseAPI.Models.Domain;

namespace CodePulseAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category category);
    }
}
