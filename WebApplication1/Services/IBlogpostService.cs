using WebApplication1.Dtos;

namespace WebApplication1.Services
{
    public interface IBlogpostService
    {
        Task<List<BlogpostDto>> GetAllAsync();
        Task<BlogpostDto?> GetByIdAsync(int id);
        Task<BlogpostDto> CreateAsync(BlogpostInputDto input);
        Task<bool> UpdateAsync(int id, BlogpostInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
