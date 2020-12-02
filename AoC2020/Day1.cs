using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day1(List<string> input)
		{
			const int sum = 2020;
			List<int> numbers = new List<int>();
			foreach (string item in input)
			{
				if (int.TryParse(item, out int num))
				{
					numbers.Add(num);
				}
			}

			int i = 0, j = 0;
			bool foundMatch = false;
			for (i = 0; i < numbers.Count; i++)
			{
				for (j = 0; j < numbers.Count; j++)
				{
					if (numbers[i] + numbers[j] == sum)
					{
						foundMatch = true;
						goto found;
					}
				}
			}

		found:
			if (foundMatch)
			{
				Console.WriteLine($"{numbers[i]} * {numbers[j]} = {numbers[i] * numbers[j]}");
			}
			else
			{
				Console.WriteLine($"Could not find a number pair whose sum was {sum}...");
			}

			int k = 0;
			foundMatch = false;
			for (i = 0; i < numbers.Count; i++)
			{
				for (j = 0; j < numbers.Count; j++)
				{
					for (k = 0; k < numbers.Count; k++)
					{
						if (numbers[i] + numbers[j] + numbers[k] == sum)
						{
							foundMatch = true;
							goto foundAgain;
						}
					}
				}
			}


		foundAgain:
			if (foundMatch)
			{
				Console.WriteLine($"{numbers[i]} * {numbers[j]} * {numbers[k]} = {numbers[i] * numbers[j] * numbers[k]}");
			}
			else
			{
				Console.WriteLine($"Could not find a three-number group whose sum was {sum}...");
			}
		}
	}
}
