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
            var gameToRemove = ApplicationData.Games.Find(x => x.HomeTeam.Name == homeTeam &&
                                                               x.AwayTeam.Name == awayTeam);

            if (gameToRemove == null)
                throw new ArgumentException($"Game not found");

            ApplicationData.Games.Remove(gameToRemove);
        }

        public void UpdateScore(Team homeTeam, Team awayTeam)
        {
            var gameToUpdate = ApplicationData.Games.Find(x => x.HomeTeam.Name == homeTeam.Name &&
                                                               x.AwayTeam.Name == awayTeam.Name);

            if (gameToUpdate == null)
                throw new ArgumentException($"Game not found");

            gameToUpdate.HomeTeam.Score = homeTeam.Score;
            gameToUpdate.AwayTeam.Score = awayTeam.Score;
        }

        public IEnumerable<string> GetSummary()
        {
            return ApplicationData.Games
                .OrderBy(x => x.HomeTeam.Score + x.AwayTeam.Score)
                .ThenBy(x => x.AddedTime)
                .Select(x => $"{x.HomeTeam.Name} {x.HomeTeam.Score} - {x.AwayTeam.Name} {x.AwayTeam.Score}");
        }
    }
}
