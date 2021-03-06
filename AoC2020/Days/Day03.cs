﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day03(List<string> input)
		{
			input.RemoveAll(item => item.Length == 0);
			Console.WriteLine($"Part 1: Found {CountTrees(3, 1)} trees.");

			List<(int,int)> slopes = new List<(int,int)>
			{
				(1, 1),
				(3, 1),
				(5, 1),
				(7, 1),
				(1, 2),
			};

			ulong totalTrees = 0;

			foreach ((int,int) slope in slopes)
			{
				if (totalTrees == 0)
					totalTrees = CountTrees(slope.Item1, slope.Item2);
				else
					totalTrees *= CountTrees(slope.Item1, slope.Item2);
			}
			Console.WriteLine($"Part 2: Multiplied total: {totalTrees}");

			ulong CountTrees(int xSpeed, int ySpeed)
			{
				int x = 0, y = 0;
				ulong trees = 0;
				while (y < input.Count)
				{
					if (input[y][x % input[y].Length] == '#')
					{
						trees++;
					}
					x += xSpeed;
					y += ySpeed;
				}
				return trees;
			}
		}
	}
}
