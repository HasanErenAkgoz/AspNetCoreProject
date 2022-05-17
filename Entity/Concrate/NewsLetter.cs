using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
   public class NewsLetter
    {
        [Key]
        public int Id { get; set; }

        public string Mail { get; set; }

        public bool Status { get; set; }
    }
}
