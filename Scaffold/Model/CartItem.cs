using System;
using System.Collections.Generic;

namespace Scaffold.Model
{
    public partial class CartItem
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? CartId { get; set; }
        public int? Quantity { get; set; }
        public short? Status { get; set; }
        public int? OrderId { get; set; }
    }
}
