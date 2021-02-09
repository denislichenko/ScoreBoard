using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreBoard.Models
{
    public class Team
    {
        public string Name { get; set; }
        public int Score { get; set; }
        
        public Team(string name, int score)
        {
            Name = name;
            Score = score; 
        }
    }
}
