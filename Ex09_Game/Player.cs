using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09_Game
{
	class Player
	{
		public char DisplayedChar;
		public string Name;
		public int Lives;

		public int PosX;
		public int PosY;


		public Player(string name, char displayedchar)
		{
			Lives = 1;
			Name = name;
			DisplayedChar = displayedchar;
		}
		public void Hit()
		{
			Lives--;
		}
		
	}
}
