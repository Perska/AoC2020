using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day09(List<string> input)
		{
			List<long> numbers = new List<long>();
			foreach (var item in input)
			{
				if (int.TryParse(item, out int res))
				{
					numbers.Add(res);
				}
			}
			int prev = 25;
			long target = 0;
			for (int k = prev; k < numbers.Count; k++)
			{
				int i = k - prev, j = k - prev;
				bool foundMatch = false;
				long targetSum = numbers[k];
				for (i = k - prev; i < k; i++)
				{
					for (j = k - prev; j < k; j++)
					{
						if (numbers[i] + numbers[j] == targetSum)
						{
							foundMatch = true;
							goto found;
						}
					}
				}
			found:
				if (!foundMatch)
				{
					Console.WriteLine($"index {k} is bad: {numbers[k]}");
					target = numbers[k];
					break;
				}
			}
			
			for (int i = 0; i < numbers.Count; i++)
			{
				long sum = 0;
				int j = 0;
				while (sum < target)
				{
					sum += numbers[i + j];
					j++;
				}
				if (sum == target && j > 1)
				{
					var range = numbers.GetRange(i, j + 1);
					Console.WriteLine($"{range.Min()} + {range.Max()} = {range.Min() + range.Max()}");
					break;
				}
			}
			
		}
	}
}
