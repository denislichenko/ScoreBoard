using ScoreBoard.Interfaces;
using ScoreBoard.Models;
using ScoreBoard.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreBoard.Services
{
    public class GameService : IGameService
    {
        public void FinishGame(string homeTeam, string awayTeam)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetSummary()
        {
            throw new NotImplementedException();
        }

        public void StartGame(string homeTeam, string awayTeam)
        {
            throw new NotImplementedException();
        }

        public void UpdateScore(Team homeTeam, Team awayTeam)
        {
            throw new NotImplementedException();
        }
    }
}
