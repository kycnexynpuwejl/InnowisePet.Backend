using System;
using System.Collections.Generic;

namespace Scaffold.Model
{
    public partial class User
    {
        public int? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Mobile { get; set; }
    }
}
