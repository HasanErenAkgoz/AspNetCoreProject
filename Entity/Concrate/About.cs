using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
   public class About
    {
        [Key]
        public int Id { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string MapLocation { get; set; }
        public bool Status { get; set; }
    }
}
