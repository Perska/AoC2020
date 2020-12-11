using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day05(List<string> input)
		{
			List<Tuple<int, int, int>> passes = new List<Tuple<int, int, int>>();
			Tuple<int, int, int>[] passArr = new Tuple<int, int, int>[1024];

			foreach (string pass in input)
			{
				if (pass.Length < 10) continue;
				int column = 0, row = 0;
				for (int i = 0; i < 7; i++)
				{
					if (pass[i] == 'B') column ^= 1 << (6 - i);
				}
				for (int i = 0; i < 3; i++)
				{
					if (pass[7 + i] == 'R') row ^= 1 << (2 - i);
				}
				passes.Add(new Tuple<int, int, int>(column, row, column * 8 + row));
				//Console.WriteLine($"{column} {row} {column * 8 + row}");
			}
			int minPass = passes.Min(pass => pass.Item3), maxPass = passes.Max(pass => pass.Item3);
			Console.WriteLine($"Part 1: {maxPass}");

			foreach (var pass in passes)
			{
				passArr[pass.Item3] = pass;
			}
			for (int i = minPass; i <= maxPass; i++)
			{
				if (passArr[i] == null) Console.WriteLine($"Part 2: {i}");
			}
		}
	}
}
