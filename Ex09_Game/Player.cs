using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex09_Game
{
	class Player
	{
		public char DisplayedChar;
		public string Name;
		public int Lives;
		public ConsoleColor Color;

		public int PosX;
		public int PosY;

		bool isAI;
		object AI = new object();

		public Player(string name, char displayedchar, ConsoleColor color)
		{
			Lives = 1;
			Name = name;
			DisplayedChar = displayedchar;
			Color = color;
		}
		public void Hit()
		{
			Lives--;
			if(Lives <= 0)
			{
				Console.SetCursorPosition(0, Program.map.MapArray.GetLength(1));
				Console.WriteLine(Name + " has died!");
				Console.SetCursorPosition(PosX, PosY);
				Console.ForegroundColor = Color;
				Console.Write('X');
			}
		}


		public void StartAI()
		{
			if (isAI == false)
			{
				lock (AI)
				{
					isAI = true;
					Random rand = new Random();
					Player p = null;
					bool found = false;
					for (int y = 0; y < Program.map.MapArray.GetLength(1); y++)
					{
						for (int x = 0; x < Program.map.MapArray.GetLength(0); x++)
						{
							if (Program.map.MapArray[x, y] != null && (x != PosX || y != PosY))
							{
								p = Program.map.MapArray[x, y];
								found = true;
								break;
							}
						}
						if (found) break;
					}
					while (isAI)
					{
						Thread.Sleep(500);
						if(p != null){
							int moveX = Math.Max(Math.Min(p.PosX - PosX, 1), -1);
							int moveY = Math.Max(Math.Min(p.PosY - PosY, 1), -1);
							Program.map.Move(this, moveX, moveY);
						}
					}
				}
			}
		}

		public void StopAI()
		{
			isAI = false;
		}

		
	}
}
