using ScoreBoard.Models;
using ScoreBoard.Models.Data;
using ScoreBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ScoreBoard.Tests
{
    public class GameServiceTests
    {
       
        [Fact]
        public void StartGameTest()
        {
            var service = new GameService();
            var games = ApplicationData.Games;
            var gamesCount = games.Count;
            var homeTeam = new Team("Test1", 0);
            var awayTeam = new Team("Test2", 0);

            service.StartGame(homeTeam.Name, awayTeam.Name);

            Assert.Equal(gamesCount + 1, games.Count);
            Assert.Equal(homeTeam, games.Last().HomeTeam);
            Assert.Equal(awayTeam, games.Last().AwayTeam);
        }

        [Fact]
        public void FinishGameTest()
        {
            var service = new GameService();
            var games = ApplicationData.Games;
            var gamesCount = games.Count;
            var homeTeam = new Team("Test3", 0);
            var awayTeam = new Team("Test4", 0);

            service.StartGame(homeTeam.Name, awayTeam.Name);

            Assert.Equal(gamesCount + 1, games.Count);
            Assert.Equal(homeTeam, games.Last().HomeTeam);
            Assert.Equal(awayTeam, games.Last().AwayTeam);

            service.FinishGame(homeTeam.Name, awayTeam.Name);

            Assert.Equal(gamesCount, games.Count);
            Assert.Null(games.FirstOrDefault(x => x.HomeTeam.Name == homeTeam.Name));
            Assert.Null(games.FirstOrDefault(x => x.AwayTeam.Name == awayTeam.Name));
        }

        [Fact]
        public void UpdateScoreTest()
        {
            var service = new GameService();
            var games = ApplicationData.Games;
            var gamesCount = games.Count;
            var homeTeam = new Team("Test5", 0);
            var awayTeam = new Team("Test6", 0);

            service.StartGame(homeTeam.Name, awayTeam.Name);

            homeTeam.Score = 5;
            awayTeam.Score = 3; 

            service.UpdateScore(homeTeam, awayTeam);

            var resultGame = games.First(x => x.HomeTeam.Name == homeTeam.Name &&
                                              x.AwayTeam.Name == awayTeam.Name);

            Assert.Equal(5, resultGame.HomeTeam.Score);
            Assert.Equal(3, resultGame.AwayTeam.Score);
        }

        [Fact]
        public void GetSummary()
        {
            var service = new GameService();
            var games = ApplicationData.Games;
            var expectedResult = ApplicationData.Games.OrderBy(x => x.HomeTeam.Score + x.AwayTeam.Score)
                                                .ThenBy(x => x.AddedTime)
                                                .Select(x => $"{x.HomeTeam.Name} {x.HomeTeam.Score} - {x.AwayTeam.Name} {x.AwayTeam.Score}")
                                                .ToList();

            var actualResult = service.GetSummary();

            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
