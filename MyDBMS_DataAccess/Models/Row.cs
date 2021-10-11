using System.Collections.Generic;

namespace MyDBMS.Models
{
    public class Row
    {
        public Row()
        {
            Cells = new List<Cell>();
        }
        
        public int Id { get; set; }
        
        public int TableId { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<Cell> Cells { get; set; }
    }
}