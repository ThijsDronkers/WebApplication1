using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class BlogpostService : IBlogpostService
    {
        private readonly PortfolioDBContext _context;

        public BlogpostService(PortfolioDBContext context)
        {
            _context = context;
        }

        public async Task<List<BlogpostDto>> GetAllAsync()
        {
            List<Blogpost> blogposts = await _context.Blogposts.ToListAsync();
            return blogposts.Select(b => ToDto(b)).ToList();    
        }

        public async Task<BlogpostDto?> GetByIdAsync(int id)
        {
            Blogpost? blogpost = await _context.Blogposts.FindAsync(id);
            if (blogpost == null)
            {
                return null;
            }
            return ToDto(blogpost);
        }

        private static BlogpostDto ToDto(Blogpost blogpost)
        {
            return new BlogpostDto
            {
                Id = blogpost.Id,
                Titel = blogpost.Titel,
                Inhoud = blogpost.Inhoud,
                PublicatieDatum = blogpost.PublicatieDatum
            };
        }

        public async Task<BlogpostDto> CreateAsync(BlogpostInputDto input)
        {
            Blogpost blogpost = new Blogpost();
            CopyInput(input, blogpost);

            _context.Blogposts.Add(blogpost);
            await _context.SaveChangesAsync();

            return ToDto(blogpost);
        }

        public async Task<bool> UpdateAsync(int id, BlogpostInputDto input)
        {
            Blogpost? blogpost = await _context.Blogposts.FindAsync(id);
            if (blogpost == null)
            {
                return false;
            }

            CopyInput(input, blogpost);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Blogpost? blogpost = await _context.Blogposts.FindAsync(id);
            if (blogpost == null)
            {
                return false;
            }
            _context.Blogposts.Remove(blogpost);
            await _context.SaveChangesAsync();
            return true;

        }

        private static void CopyInput(BlogpostInputDto input, Blogpost blogpost)
        {
            blogpost.Titel = input.Titel;
            blogpost.Inhoud = input.Inhoud;
            blogpost.PublicatieDatum = input.PublicatieDatum;
        }
    }
}
