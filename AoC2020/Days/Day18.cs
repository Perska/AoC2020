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
		static void Day18(List<string> input)
		{
			long sum = 0;
			long superSum = 0;
			foreach (var item in input)
			{
				if (item != "")
				{
					sum += long.Parse(Maths(item));
					superSum += long.Parse(SuperMaths(item));
				}
			}
			Console.WriteLine(sum);
			Console.WriteLine(superSum);
			/*Console.WriteLine(Maths("1 + 2 * 3 + 4 * 5 + 6"));
			Console.WriteLine(Maths("1 + (2 * 3) + (4 * (5 + 6))"));*/
		}

		static string Maths(string how)
		{
			const string reg = @"(\d+) *([\+\*]) *(\d+)";
			Regex regex = new Regex(reg, RegexOptions.Compiled);
			while (true)
			{
				if (how.Contains("("))
				{
					int leftP = how.IndexOf('(');
					int rightP = -1;
					int level = 0;
					for (int i = leftP; i < how.Length; i++)
					{
						if (how[i] == '(')
						{
							level++;
						}
						else if (how[i] == ')')
						{
							level--;
						}
						if (level == 0)
						{
							rightP = i;
							break;
						}
					}
					if (rightP != -1 && level == 0)
					{
						string rep = Maths(how.Substring(leftP + 1, rightP - leftP - 1));
						how = how.Substring(0, leftP) + rep + how.Substring(rightP + 1);
						;
					}
				}
				else
				{

					Match match = regex.Match(how);
					if (match.Success)
					{
						long res = 0;
						switch (match.Groups[2].Value)
						{
							case "+":
								res = long.Parse(match.Groups[1].Value) + long.Parse(match.Groups[3].Value);
								break;
							case "*":
								res = long.Parse(match.Groups[1].Value) * long.Parse(match.Groups[3].Value);
								break;
							default:
								break;
						}
						how = regex.Replace(how, res.ToString(), 1);
					}
					else
					{
						break;
					}
				}
			}
			return how;
		}


		static string SuperMaths(string how)
		{
			const string reg = @"(\d+) *([\+]) *(\d+)";
			const string reg2 = @"(\d+) *([\*]) *(\d+)";
			Regex regex = new Regex(reg, RegexOptions.Compiled);
			Regex regex2 = new Regex(reg2, RegexOptions.Compiled);
			while (true)
			{
				if (how.Contains("("))
				{
					int leftP = how.IndexOf('(');
					int rightP = -1;
					int level = 0;
					for (int i = leftP; i < how.Length; i++)
					{
						if (how[i] == '(')
						{
							level++;
						}
						else if (how[i] == ')')
						{
							level--;
						}
						if (level == 0)
						{
							rightP = i;
							break;
						}
					}
					if (rightP != -1 && level == 0)
					{
						string rep = SuperMaths(how.Substring(leftP + 1, rightP - leftP - 1));
						how = how.Substring(0, leftP) + rep + how.Substring(rightP + 1);
					}
				}
				else
				{

					Match match = regex.Match(how);
					Match match2 = regex2.Match(how);
					if (match.Success)
					{
						long res = 0;
						switch (match.Groups[2].Value)
						{
							case "+":
								res = long.Parse(match.Groups[1].Value) + long.Parse(match.Groups[3].Value);
								break;
							default:
								break;
						}
						how = regex.Replace(how, res.ToString(), 1);
					}
					else if (match2.Success)
					{
						long res = 0;
						switch (match2.Groups[2].Value)
						{
							case "*":
								res = long.Parse(match2.Groups[1].Value) * long.Parse(match2.Groups[3].Value);
								break;
							default:
								break;
						}
						how = regex2.Replace(how, res.ToString(), 1);
					}
					else
					{
						break;
					}
				}
			}
			return how;
		}
	}
}