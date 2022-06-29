using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class GameSession
    {
        [Key]
        public int sessionId { get; set; }
        public int player1 { get; set; }
        public int p1Hits { get; set; } = 0;
        public int p1HitsForWin { get; set; }
        public int player2 { get; set; }
        public int p2Hits { get; set; } = 0;
        public int p2HitsForWin { get; set; }
        public bool started { get; set; } = false;
        // 1 или 2
        public int playerTurn { get; set; } = 1;
        public bool finished { get; set; } = false;
        public int lobbyID { get; set; }
        public int lastP1HitX { get; set; } = -1;
        public int lastP1HitY { get; set; } = -1;
        public int lastP2HitX { get; set; } = -1;
        public int lastP2HitY { get; set; } = -1;
        public int winner { get; set; } = -1;
    }
}
