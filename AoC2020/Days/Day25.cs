using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day25(List<string> input)
		{
			if (input.Count < 2)
			{
				Console.WriteLine("Input too short!");
				return;
			}
			int cardKey = int.Parse(input[0]);
			int doorKey = int.Parse(input[1]);

			int cardLoopSize = UnTransformSubject(7, cardKey);
			int doorLoopSize = UnTransformSubject(7, doorKey);

			long encKey = TransformSubject(doorKey, cardLoopSize);
			Console.WriteLine(encKey);

		}
		static long TransformSubject(long subject, int loopSize)
		{
			long value = 1;
			for (int i = 0; i < loopSize; i++)
			{
				value *= subject;
				value %= 20201227;
			}
			return value;
		}
		static int UnTransformSubject(long subject, int target)
		{
			long value = 1;
			int loops = 0;
			while (value != target)
			{
				value *= subject;
				value %= 20201227;
				loops++;
			}
			return loops;
		}
	}
}
