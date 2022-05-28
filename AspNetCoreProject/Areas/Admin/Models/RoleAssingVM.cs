using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Areas.Admin.Models
{
    public class RoleAssingVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Exists { get; set; }
    }
}
