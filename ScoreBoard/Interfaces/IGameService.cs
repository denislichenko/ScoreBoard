using ScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreBoard.Interfaces
{
    interface IGameService
    {
        void StartGame(string homeTeam, string awayTeam);
        void FinishGame(string homeTeam, string awayTeam);
        void UpdateScore(Team homeTeam, Team awayTeam);
        IList<string> GetSummary();
    }
}
