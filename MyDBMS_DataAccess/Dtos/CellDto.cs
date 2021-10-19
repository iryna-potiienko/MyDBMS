using System.ComponentModel.DataAnnotations;

namespace MyDBMS.Dtos
{
    //Am I need it?
    public class CellDto
    {
        public int Id { get; set; }
        public string Data { get; set; }
        
        [Required]
        public int? AttributeId { get; set; }
        [Required]
        public int RowId { get; set; }
    }
}