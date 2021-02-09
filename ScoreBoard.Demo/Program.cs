using ScoreBoard.Models;
using ScoreBoard.Services;
using System;

namespace ScoreBoard.Demo
{
    class Program
    {
        private readonly static GameService gameService = new GameService(); 
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("\nList of operations:\n" +
                                          "1 - Start Game\n" +
                                          "2 - Finish Game\n" +
                                          "3 - Update Game\n" +
                                          "4 - Get Summary\n\n" +
                                          "Input operation code: ");

                var operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1: StartOperation(); break;
                    case 2: FinishOperation(); break;
                    case 3: UpdateOperation(); break;
                    case 4: GetSummaryOperation(); break;
                }
            }   
        }

        static void StartOperation()
        {
            string homeTeam, awayTeam;
            InputTeamNames(out homeTeam, out awayTeam); 

            gameService.StartGame(homeTeam, awayTeam); 
        }

        static void FinishOperation()
        {
            string homeTeam, awayTeam;
            InputTeamNames(out homeTeam, out awayTeam);

            gameService.FinishGame(homeTeam, awayTeam);
        }

        static void UpdateOperation()
        {
            string homeTeam, awayTeam;
            InputTeamNames(out homeTeam, out awayTeam);

            Console.Write("Input score 1: ");
            var score1 = int.Parse(Console.ReadLine());

            Console.Write("Input score 2: ");
            var score2 = int.Parse(Console.ReadLine()); 

            gameService.UpdateScore(
                new Team(homeTeam, score1),
                new Team(awayTeam, score2));
        }

        static void GetSummaryOperation()
        {
            var summary = gameService.GetSummary();
            foreach (var line in summary)
                Console.WriteLine(line); 
        }

        static void InputTeamNames(out string homeTeam, out string awayTeam)
        {
            Console.Write("Home team: ");
            homeTeam = Console.ReadLine();

            Console.Write("Away team: ");
            awayTeam = Console.ReadLine();
        }
    }
}
