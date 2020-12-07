using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day6(List<string> input)
		{
			int[] answered = new int[26];
			int sums = 0, sums2 = 0, ppl = 0;
			foreach (var item in input)
			{
				if (item.Length == 0 && ppl != 0)
				{
					sums += answered.Count(i => i != 0);
					sums2 += answered.Count(i => i == ppl);
					answered = new int[26];
					ppl = 0;
					continue;
				}
				for (int i = 0; i < item.Length; i++)
				{
					answered[item[i] - 'a']++;
				}
				ppl++;
			}

			Console.WriteLine(sums);
			Console.WriteLine(sums2);
		}
	}
}
