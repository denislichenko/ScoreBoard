using ScoreBoard.Interfaces;
using ScoreBoard.Models;
using ScoreBoard.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreBoard.Services
{
    public class GameService : IGameService
    {
        public void StartGame(string homeTeam, string awayTeam)
        {
            ApplicationData.Games.Add(new Game(homeTeam, awayTeam));
        }

        public void FinishGame(string homeTeam, string awayTeam)
        {
            var gameToRemove = FindGame(homeTeam, awayTeam);

            ApplicationData.Games.Remove(gameToRemove);
        }

        public void UpdateScore(Team homeTeam, Team awayTeam)
        {
            var gameToUpdate = FindGame(homeTeam.Name, awayTeam.Name);

            gameToUpdate.HomeTeam.Score = homeTeam.Score;
            gameToUpdate.AwayTeam.Score = awayTeam.Score;
        }

        public IEnumerable<string> GetSummary()
        {
            return ApplicationData.Games
                .OrderByDescending(x => x.HomeTeam.Score + x.AwayTeam.Score)
                .ThenByDescending(x => x.AddedTime)
                .Select(x => $"{x.HomeTeam.Name} {x.HomeTeam.Score} - {x.AwayTeam.Name} {x.AwayTeam.Score}");
        }

        private Game FindGame(string homeTeam, string awayTeam)
        {
            var gameToRemove = ApplicationData.Games.Find(x => x.HomeTeam.Name == homeTeam &&
                                                               x.AwayTeam.Name == awayTeam);

            if (gameToRemove == null)
                throw new ArgumentException($"Game not found");

            return gameToRemove; 
        } 
    }
}
