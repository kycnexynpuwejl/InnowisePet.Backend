using System;
using System.Collections.Generic;

namespace Scaffold.Model
{
    public partial class Order
    {
        public int? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
