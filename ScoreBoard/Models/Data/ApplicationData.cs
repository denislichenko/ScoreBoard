using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreBoard.Models.Data
{
	public static class ApplicationData
	{
		public static List<Game> Games = new List<Game>()
		{
			new Game("Mexico", "Canada", 0, 5),
			new Game("Spain", "Brazil", 10, 2),
			new Game("Germany", "France", 2, 2),
			new Game("Uruguay", "Italy", 6, 6),
			new Game("Argentina", "Australia", 3, 1)
		};
	}
}