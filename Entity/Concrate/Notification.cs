﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
   public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string TypeSymbol { get; set; }
        public string Color { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
