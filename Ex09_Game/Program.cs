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
		static void Main(string[] args)
		{
			Map map = new Map(80, 23);
			Player player1 = new Player("Player1", 'P');
			map.AddPlayerAt(1, 1, player1);

			bool running = true;
			while (running)
			{
				ConsoleKeyInfo key = Console.ReadKey();
				switch (key.Key.ToString())
				{
					case "Escape":
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
