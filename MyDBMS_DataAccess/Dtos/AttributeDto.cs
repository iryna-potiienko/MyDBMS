using System.ComponentModel.DataAnnotations;

namespace MyDBMS.Dtos
{
    public class AttributeDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TypeName { get; set; }
        [Required]
        public int TableId { get; set; }
    }
}