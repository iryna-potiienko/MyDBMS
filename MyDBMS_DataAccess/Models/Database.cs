﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDBMS.Models
{
    public class Database
    {
        public Database()
        {
            Tables = new List<Table>();
        }
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}