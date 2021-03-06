using System.Collections.Generic;

namespace MyDBMS.Models
{
    public class Attribute
    {
        public Attribute()
        {
            Cells = new List<Cell>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public virtual Type Type { get; set; }
        
        public int TableId { get; set; }
        //public virtual Table Table { get; set; }
        public virtual ICollection<Cell> Cells { get; set; }
        
        public bool ShouldSerializeId()
        {
            return false;
        }
    }
}