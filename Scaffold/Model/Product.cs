using System;
using System.Collections.Generic;

namespace Scaffold.Model
{
    public partial class Product
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public int? StorageId { get; set; }
    }
}
