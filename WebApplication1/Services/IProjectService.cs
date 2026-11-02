using WebApplication1.Dtos;

namespace WebApplication1.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAllAsync();
        Task<ProjectDto?> GetByIdAsync(int id);
        Task<ProjectDto> CreateAsync(ProjectInputDto input);
        Task<bool> UpdateAsync(int id, ProjectInputDto input);
        Task<bool> DeleteAsync(int id);
    }
}
