using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex09_Game
{
	class Program
	{
		public static Map map;
		static void Main(string[] args)
		{
			map = new Map(80, 23);
			Player player1 = new Player("Player 1", 'P', ConsoleColor.Cyan);
			map.AddPlayerAt(10, 10, player1);

			Player player2AI = new Player("Player 2", 'E', ConsoleColor.Red);
			map.AddPlayerAt(70, 10, player2AI);
			Thread AIthread = new Thread(new ThreadStart(player2AI.StartAI));
			AIthread.Start();

			bool running = true;
			while (running)
			{
				ConsoleKeyInfo key = Console.ReadKey(true);
				switch (key.Key.ToString())
				{
					case "Escape":
						player2AI.StopAI();
						running = false;
						break;
					case "UpArrow":
						map.Move(player1, 0, -1);
						break;
					case "DownArrow":
						map.Move(player1, 0, 1);
						break;
					case "LeftArrow":
						map.Move(player1, -1, 0);
						break;
					case "RightArrow":
						map.Move(player1, 1, 0);
						break;
				}
			}
		}
	}
}
