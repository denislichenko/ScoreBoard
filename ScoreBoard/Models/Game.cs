using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ScoreBoard.Models
{
    public class Game
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public DateTime AddedTime { get; set; }

        public Game(string homeTeam, string awayTeam, int homeScore = 0, int awayScore = 0)
        {
            HomeTeam = new Team(homeTeam, homeScore);
            AwayTeam = new Team(awayTeam, awayScore);
            AddedTime = DateTime.Now; 
        }
    }
}
