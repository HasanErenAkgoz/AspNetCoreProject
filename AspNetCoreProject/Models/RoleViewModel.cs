using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Models
{
    public class RoleViewModel
    {   
        [Required(ErrorMessage ="Lütfen Rol Adı Giriniz")]
        public string Name { get; set; }
    }
}
