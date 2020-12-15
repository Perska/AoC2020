using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day15(List<string> input)
		{
			List<long> numbers = new List<long>();
			Dictionary<long,long> saidNumbers = new Dictionary<long,long>();
			foreach (var item in input[0].Split(','))
			{
				if (item != "" && int.TryParse(item, out int res)) numbers.Add(res);
			}
			long lastNum = -1;
			long turn = 1;
			long firstTime = 0;
			foreach (var item in numbers)
			{
				SayNum(item);
			}
			while (turn <= 2020)
			{
				if (firstTime == 0)
				{
					SayNum(0);
				}
				else
				{
					//Console.WriteLine($"{saidNumbers[lastNum]} - {firstTime} = {saidNumbers[lastNum] - firstTime}!");
					SayNum(saidNumbers[lastNum] - firstTime);
				}
			}
			Console.WriteLine(lastNum);

			while (turn <= 30000000)
			{
				if (firstTime == 0)
				{
					SayNum(0);
				}
				else
				{
					//Console.WriteLine($"{saidNumbers[lastNum]} - {firstTime} = {saidNumbers[lastNum] - firstTime}!");
					SayNum(saidNumbers[lastNum] - firstTime);
				}
			}
			Console.WriteLine(lastNum);

			void SayNum(long num)
			{
				lastNum = num;
				saidNumbers.TryGetValue(num, out firstTime);
				saidNumbers[num] = turn;
				//Console.WriteLine($"said number {num} !");
				turn++;
			}
		}
	}
}
