using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day10(List<string> input)
		{
			List<int> jolts = new List<int>();
			foreach (var item in input)
			{
				if (int.TryParse(item, out int s))
				{
					jolts.Add(s);
				}
			}
			jolts.Sort();
			List<int> joltDiff = new List<int>();
			int joltage = 0;
			bool canIncrement = true;
			int[] permittedAdapt = new int[]
			{
				1, 2, 3
			};
			while (canIncrement)
			{
				int i;
				for (i = 0; i < permittedAdapt.Length; i++)
				{
					if (jolts.Contains(joltage + permittedAdapt[i]))
					{
						joltage += permittedAdapt[i];
						joltDiff.Add(permittedAdapt[i]);
						break;
					}
				}
				if (i == permittedAdapt.Length)
				{
					canIncrement = false;
				}

			}
			joltage += 3;
			joltDiff.Add(3);
			Console.WriteLine(joltage);
			Console.WriteLine(joltDiff.Count(item => item == 1));
			Console.WriteLine(joltDiff.Count(item => item == 3));
			int targetJolt = joltage;
			Console.WriteLine(joltDiff.Count(item => item == 1) * joltDiff.Count(item => item == 3));
			
			Dictionary<int, long> cache = new Dictionary<int, long>();
			jolts.Add(targetJolt);
			Console.WriteLine(CountPaths(0));
			
			long CountPaths(int jolt)
			{
				if (jolt == targetJolt) return 1;
				long res = 0;
				if (cache.ContainsKey(jolt)) return cache[jolt];
				for (int i = 0; i < permittedAdapt.Length; i++)
				{
					if (jolts.Contains(jolt + permittedAdapt[i]))
					{
						res += CountPaths(jolt + permittedAdapt[i]);
					}
				}
				cache[jolt] = res;
				return res;
			}
		}
	}
}
