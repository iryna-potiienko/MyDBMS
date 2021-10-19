using System.ComponentModel.DataAnnotations;

namespace MyDBMS.Dtos
{
    public class TableDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DatabaseId { get; set; }
    }
}