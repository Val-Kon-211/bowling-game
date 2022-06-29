using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class OpenGames
    {
        [Key]
        public int GameID { get; set; }
        public int Player1 { get; set; }
        public int sessionID { get; set; } = -1;
    }
}
