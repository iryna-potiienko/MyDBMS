using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyDBMS.Models
{
    public class Database
    {
        public Database()
        {
            Tables = new List<Table>();
        }
        //[JsonIgnore]
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        public virtual ICollection<Table> Tables { get; set; }

        public bool ShouldSerializeId()
        {
            return false;
        }
    }
}