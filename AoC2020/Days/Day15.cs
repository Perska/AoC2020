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
			List<int> numbers = new List<int>();
			Dictionary<int,int> saidNumbers = new Dictionary<int,int>();
			foreach (var item in input[0].Split(','))
			{
				if (item != "" && int.TryParse(item, out int res)) numbers.Add(res);
			}
			int lastNum = -1;
			int turn = 1;
			int firstTime = 0;
			foreach (var item in numbers)
			{
				SayNum(item);
			}
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
				if (turn == 2021) Console.WriteLine(lastNum);
			}
			void SayNum(int num)
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
