using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Models
{
    public class AddProfileImage
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(300)]
        public string About { get; set; }
        public IFormFile Image { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public bool Status { get; set; }
    }
}
