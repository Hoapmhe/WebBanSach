using Microsoft.EntityFrameworkCore;
using BanSach.Models;

namespace BanSach.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }

        public DbSet<Category> Categories { get; set; }

    }
}
