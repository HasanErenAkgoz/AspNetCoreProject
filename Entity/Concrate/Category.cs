using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
   public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool Status { get; set; }

        public  List<Blog> Blogs { get; set; }
    }
}
