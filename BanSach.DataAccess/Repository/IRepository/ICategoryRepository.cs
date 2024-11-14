using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanSach.Models;

namespace BanSach.DataAccess.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public void Update(Category category);
        public void Save();
    }
}
