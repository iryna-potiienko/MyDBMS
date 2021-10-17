using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDBMS.Models
{
    public class Table
    {
        public Table()
        {
            Attributes = new List<Attribute>();
            Rows = new List<Row>();
        }
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        
        public int DatabaseId { get; set; }
        public virtual Database Database { get; set; }
        public virtual ICollection<Attribute> Attributes { get; set; }
        //public List<List<Cell>> TableCells { get; set; }
        
        public virtual ICollection<Row> Rows { get; set; }
    }
}