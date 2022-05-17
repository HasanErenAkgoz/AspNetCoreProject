using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
   public class BlogRating
    {
        [Key]
        public int Id { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRatingCount { get; set; }

    }
}
