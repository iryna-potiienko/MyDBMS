using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDBMS.Models
{
    public class Type
    {
        public int Id { get; set; }
        public Type()
        {
            Attributes = new List<Attribute>();
        }
        //[Required]
        public string Name { get; set; }
        public virtual ICollection<Attribute> Attributes { get; set; }
    }
}