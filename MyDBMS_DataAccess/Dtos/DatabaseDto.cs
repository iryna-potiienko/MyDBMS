using System.ComponentModel.DataAnnotations;

namespace MyDBMS.Dtos
{
    public class DatabaseDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}