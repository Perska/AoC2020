using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day3(List<string> input)
		{
			Console.WriteLine($"Part 1: Found {CountTrees(3, 1)} trees.");

			List<Tuple<int, int>> slopes = new List<Tuple<int, int>>
			{
				new Tuple<int, int>(1, 1),
				new Tuple<int, int>(3, 1),
				new Tuple<int, int>(5, 1),
				new Tuple<int, int>(7, 1),
				new Tuple<int, int>(1, 2),
			};

			ulong totalTrees = 0;

			foreach (Tuple<int,int> slope in slopes)
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
