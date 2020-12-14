using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AoC2020
{
	partial class Program
	{
		static void Day14(List<string> input)
		{
			Dictionary<long, long> mem = new Dictionary<long, long>();
			Dictionary<long, long> mem2 = new Dictionary<long, long>();
			long ormask = 0;
			long andmask = 0;
			string mask = "";
			foreach (var item in input)
			{
				if (item.StartsWith("mask"))
				{
					mask = item.Substring(7);
					ormask = Convert.ToInt64(mask.Replace('X', '0'), 2);
					andmask = Convert.ToInt64(mask.Substring(7).Replace('1', '0').Replace('X', '1'), 2);
				}
				else
				{
					Match match = Regex.Match(item, @"mem\[(\d+)] = (\d+)");
					if (match.Success)
					{
						//Console.WriteLine($"{match.Groups[1]} = {match.Groups[2]}");
						mem[long.Parse(match.Groups[1].Value)] = (long.Parse(match.Groups[2].Value) & andmask) | ormask;
						write2mem2(long.Parse(match.Groups[1].Value), long.Parse(match.Groups[2].Value));
						//Console.WriteLine((long.Parse(match.Groups[2].Value) & andmask) | ormask);
					}
				}

			}

			void write2mem2(long addr, long value)
			{
				string targ = Convert.ToString(addr, 2).PadLeft(36, '0');
				string targ2 = "";
				for (int i = 0; i < 36; i++)
				{
					if (mask[i] != '0') targ2 += mask[i];
					else targ2 += targ[i];
				}

				foreach (var item in HelpF.Combinations(targ2))
				{
					mem2[Convert.ToInt64(item, 2)] = value;
				}

				//Console.WriteLine(targ2);
			}
			Console.WriteLine(mem.Sum(item => item.Value));
			Console.WriteLine(mem2.Sum(item => item.Value));
		}
	}
}
