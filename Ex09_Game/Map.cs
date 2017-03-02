﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09_Game
{
	class Map
	{
		public Player[,] MapArray { get; private set; }
		public Map(int x, int y)
		{
			MapArray = new Player[x, y];
		}
		public void AddPlayerAt(int x, int y, Player player)
		{
			if(MapArray[x,y] == null)
			{
				MapArray[x, y] = player;
				player.PosX = x;
				player.PosY = y;
			}
			DrawMap();
		}

		public void DrawMap()
		{
			Console.CursorVisible = false;
			char c;
			for (int y = 0; y < MapArray.GetLength(1); y++)
			{
				for (int x = 0; x < MapArray.GetLength(0); x++)
				{
					c = 'X';
					if (MapArray[x, y] != null) c = MapArray[x, y].DisplayedChar;
					Console.SetCursorPosition(x, y);
					Console.Write(c);
				}
			}
		}

		public void Move(Player player, int xOffset, int yOffset)
		{
			int FromX = player.PosX;
			int FromY = player.PosY;
			int ToX = player.PosX + xOffset;
			int ToY = player.PosY + yOffset;
			if(ToX >= 0 && ToY >= 0 && ToX < MapArray.GetLength(0) && ToY < MapArray.GetLength(1))
			{
				if (MapArray[ToX, ToY] == null)
				{
					MapArray[ToX, ToY] = MapArray[FromX, FromY];
					MapArray[FromX, FromY] = null;
					Console.SetCursorPosition(FromX, FromY);
					Console.Write('X');
					Console.SetCursorPosition(ToX, ToY);
					Console.Write(MapArray[ToX, ToY].DisplayedChar);
					player.PosX = ToX;
					player.PosY = ToY;
				}
			}
		}
		/*
		public void Move(int FromX, int FromY, int ToX, int ToY)
		{
			if (MapArray[FromX, FromY] != null && MapArray[ToX, ToY] == null)
			{
				MapArray[ToX, ToY] = MapArray[FromX, FromY];
				MapArray[FromX, FromY] = null;
				Console.SetCursorPosition(FromX, FromY);
				Console.Write(' ');
				Console.SetCursorPosition(ToX, ToY);
				Console.Write(MapArray[ToX, ToY].DisplayedChar);
			}
		}
		*/

		public void Attack(int FromX, int FromY, int ToX, int ToY)
		{
			if (MapArray[FromX, FromY] != null && MapArray[ToX, ToY] != null)
			{
				MapArray[ToX, ToY].Hit();
				if (MapArray[ToX, ToY].Lives <= 0)
				{
					MapArray[ToX, ToY] = null;
					Console.SetCursorPosition(ToX, ToY);
					Console.Write(' ');
				}
			}
		}

	}
}