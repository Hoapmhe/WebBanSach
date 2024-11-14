using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSach.Models
{
    public class Category
    {
        [Key]//pm
        public int Id { get; set; }
        [Required]//not null
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        public string DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

    }
}
