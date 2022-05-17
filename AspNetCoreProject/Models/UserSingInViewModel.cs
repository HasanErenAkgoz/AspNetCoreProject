using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Models
{
    public class UserSingInViewModel
    {
        [Display(Name = "Ad-Soyad")]
        [Required(ErrorMessage = "Lütfen Ad-Soyad Giriniz")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }
    }
}
