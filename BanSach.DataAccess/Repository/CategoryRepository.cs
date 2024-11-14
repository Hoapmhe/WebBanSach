using BanSach.DataAccess.Repository;
using BanSach.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanSach.DataAccess.Data;

namespace BanSach.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        void ICategoryRepository.Save()
        {
            _context.SaveChanges();
        }

        void ICategoryRepository.Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
