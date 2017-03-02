using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex09_Game
{
	public class PowerUpSpawner
	{
		bool spawning;
		public void Start()
		{
			spawning = true;
			Thread.Sleep(2000);
			while (spawning)
			{
				Player p = new Player("POWERUP", 'O', ConsoleColor.Yellow);
				Random rand = new Random();
				Program.map.AddPlayerAt(rand.Next(0, Program.map.MapArray.GetLength(0)), rand.Next(0, Program.map.MapArray.GetLength(1)), p);
				Thread.Sleep(2000);
			}
		}

		public void Stop()
		{
			spawning = false;
		}
	}
}
