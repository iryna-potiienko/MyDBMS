﻿namespace MyDBMS.Models
{
    public class Cell
    {
        public int Id { get; set; }
        public string Data { get; set; }
        
        public int? AttributeId { get; set; }
        public int RowId { get; set; }
        
        public virtual Attribute Attribute { get; set; }
        public virtual Row Row { get; set; }
    }
}