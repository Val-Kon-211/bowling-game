using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Entity
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }

        public int WinCount { get; set; } = 0;
        public int LoseCount { get; set; } = 0;
    }
}
