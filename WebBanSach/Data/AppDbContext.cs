using Microsoft.EntityFrameworkCore;
using WebBanSach.Models;

namespace WebBanSach.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }

        public DbSet<Category> Categories { get; set; }

    }
}
