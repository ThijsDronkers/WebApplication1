using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class ProjectService : IProjectService
    {
        private readonly PortfolioDBContext _context;

        public ProjectService(PortfolioDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
            List<Project> projects = await _context.Projects.ToListAsync();
            return projects.Select(p => ToDto(p)).ToList();
        }

        public async Task<ProjectDto?> GetByIdAsync(int id)
        {
            Project? project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return null;
            }
            return ToDto(project);
        }

        private static ProjectDto ToDto(Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Titel = project.Titel,
                Beschrijving = project.Beschrijving,
                Categorie = project.Categorie,
                GitHubUrl = project.GitHubUrl,
                Datum = project.Datum
            };
        }

        public async Task<ProjectDto> CreateAsync(ProjectInputDto input)
        {
            Project project = new Project();
            CopyInput(input, project);

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return ToDto(project);
        }

        public async Task<bool> UpdateAsync(int id, ProjectInputDto input)
        {
            Project? project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }

            CopyInput(input, project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Project? project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;

        }

        private static void CopyInput(ProjectInputDto input, Project project)
        {
            project.Titel = input.Titel;
            project.Beschrijving = input.Beschrijving;
            project.Categorie = input.Categorie;
            project.GitHubUrl = input.GitHubUrl;
            project.Datum = input.Datum;
        }
    }
}


