using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
   public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Sender  { get; set; }
        public string Receviver  { get; set; }
        public string Subject  { get; set; }
        public string Details  { get; set; }
        public DateTime Date  { get; set; }
        public bool Status  { get; set; }
     

    }
}
