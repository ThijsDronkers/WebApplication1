using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class PortfolioDBContext : DbContext
    {
        public PortfolioDBContext(DbContextOptions<PortfolioDBContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
    }
}
