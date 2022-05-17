using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(300)]
        public string About { get; set; }
        public string Image { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public bool Status { get; set; }
        public List<Blog> Blogs { get; set; }
        public virtual ICollection<MessageTwo> WriterSedner { get; set; }
        public virtual ICollection<MessageTwo> WriterReceiver { get; set; }

    }
}
