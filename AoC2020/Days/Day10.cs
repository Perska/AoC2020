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
			Console.WriteLine(joltDiff.Count(item => item == 1) * joltDiff.Count(item => item == 3));


			Console.WriteLine("Screw this, I'm out!");
			/*joltage = 0;
			canIncrement = true;

			List<int> tree = new List<int>();
			for (int k = 0; k < jolts.Count; k++)
			{
				List<int> perTree = new List<int>();
				int i;
				for (i = 0; i < permittedAdapt.Length; i++)
				{
					if (k == 0)
					{
						if (jolts.Contains(joltage + permittedAdapt[i]))
						{
							joltage += permittedAdapt[i];
							perTree.Add(joltage);
							if (i == permittedAdapt.Length - 1) break;
						}
					}
					else
					{
						for (int j = 0; j < tree.Count; j++)
						{
							joltage = tree[j];
							
							if (jolts.Contains(joltage + permittedAdapt[i]))
							{
								joltage += permittedAdapt[i];
								perTree.Add(joltage);
								if (i == permittedAdapt.Length - 1) break;
							}
						}
					}
				}
				tree.AddRange(perTree);
			}
			Console.WriteLine(tree.Count)
			;
			Console.ReadLine();
			;*/
		}
	}
}
