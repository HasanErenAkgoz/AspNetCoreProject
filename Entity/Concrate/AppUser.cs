using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
   public class AppUser:IdentityUser<int>
    {
        [StringLength(100)]
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
    }
}
