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

            var actualGame = games.Last(); 

            Assert.Equal(gamesCount + 1, games.Count);
            Assert.Equal(homeTeam.Name, actualGame.HomeTeam.Name);
            Assert.Equal(awayTeam.Name, actualGame.AwayTeam.Name);
            Assert.Equal(homeTeam.Score, actualGame.HomeTeam.Score);
            Assert.Equal(awayTeam.Score, actualGame.AwayTeam.Score);
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
            Assert.Equal(homeTeam.Name, games.Last().HomeTeam.Name);
            Assert.Equal(awayTeam.Name, games.Last().AwayTeam.Name);

            service.FinishGame(homeTeam.Name, awayTeam.Name);

            Assert.Equal(gamesCount, games.Count);
            Assert.Null(games.FirstOrDefault(x => x.HomeTeam.Name == homeTeam.Name));
            Assert.Null(games.FirstOrDefault(x => x.AwayTeam.Name == awayTeam.Name));
        }

        [Fact]
        public void FinishNotStartedTest()
        {
            var service = new GameService();
            var homeTeam = new Team("Test5", 0);
            var awayTeam = new Team("Test6", 0);

            var ex = Assert.Throws<ArgumentException>(() => service.FinishGame(homeTeam.Name, awayTeam.Name));
            Assert.Equal("Game not found", ex.Message); 
        }

        [Fact]
        public void UpdateScoreTest()
        {
            var service = new GameService();
            var games = ApplicationData.Games;
            var gamesCount = games.Count;
            var homeTeam = new Team("Test5", 5);
            var awayTeam = new Team("Test6", 3);

            service.StartGame(homeTeam.Name, awayTeam.Name);
            service.UpdateScore(homeTeam, awayTeam);

            var actualGame = games.First(x => x.HomeTeam.Name == homeTeam.Name &&
                                              x.AwayTeam.Name == awayTeam.Name);

            Assert.Equal(5, actualGame.HomeTeam.Score);
            Assert.Equal(3, actualGame.AwayTeam.Score);
        }

        [Fact]
        public void UpdateNotExistedTest()
        {
            var service = new GameService();
            var homeTeam = new Team("Test7", 5);
            var awayTeam = new Team("Test8", 3);

            var ex = Assert.Throws<ArgumentException>(() => service.UpdateScore(homeTeam, awayTeam));
            Assert.Equal("Game not found", ex.Message);
        }

        [Fact]
        public void GetSummary()
        {
            var service = new GameService();
            var games = ApplicationData.Games;
            var expectedResult = ApplicationData.Games.OrderBy(x => x.HomeTeam.Score + x.AwayTeam.Score)
                                                .ThenBy(x => x.AddedTime)
                                                .Select(x => $"{x.HomeTeam.Name} {x.HomeTeam.Score} - {x.AwayTeam.Name} {x.AwayTeam.Score}");

            var actualResult = service.GetSummary();

            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
