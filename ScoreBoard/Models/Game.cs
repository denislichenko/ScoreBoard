using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreBoard.Models
{
    class Game
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public Tuple<int, int> Score { get; set; }

        public Game()
        {
            Score = new Tuple<int, int>(0, 0); 
        }
    }
}
