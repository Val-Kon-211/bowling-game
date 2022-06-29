using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class PlayerShips
    {
        public int gameSessionId { get; set; }
        public int player { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool hit { get; set; } = false;
    }
}
