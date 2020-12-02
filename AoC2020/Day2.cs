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
		static void Day2(List<string> input)
		{
			List<string> validPasswords = new List<string>();
			List<string> validPasswords2 = new List<string>();
			foreach (string password in input)
			{
				Match match = Regex.Match(password, "([0-9]+)+-([0-9]+) (.): (.+)", RegexOptions.Compiled);
				if (match.Success)
				{
					int count = match.Groups[4].Value.Count(item => item.ToString() == match.Groups[3].Value);
					if (int.Parse(match.Groups[1].Value) <= count && count <= int.Parse(match.Groups[2].Value))
					{
						//Console.WriteLine($"{password} is valid, has {count} of '{match.Groups[3]}'");
						validPasswords.Add(password);
					}
					else
					{
						//Console.WriteLine($"{password} is not valid, has {count} of '{match.Groups[3]}'");
					}
					if ((match.Groups[4].Value[int.Parse(match.Groups[1].Value) - 1].ToString() == match.Groups[3].Value)
						!= (match.Groups[4].Value[int.Parse(match.Groups[2].Value) - 1].ToString() == match.Groups[3].Value))
					{
						//Console.WriteLine($"{password} is valid, has {count} of '{match.Groups[3]}'");
						validPasswords2.Add(password);
					}
					else
					{
						//Console.WriteLine($"{password} is not valid, has {count} of '{match.Groups[3]}'");
					}
				}
				else
				{
					Console.WriteLine($"Something went wrong while parsing... {password}");
				}
			}
			Console.WriteLine($"Valid passwords: {validPasswords.Count}");
			Console.WriteLine($"Valid passwords (V2): {validPasswords2.Count}");
			//([0-9])+-([0-9]+) ([a-z]): (.+$)
		}
	}
}
