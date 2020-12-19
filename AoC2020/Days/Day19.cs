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
		static void Day19(List<string> input)
		{
			Dictionary<int, string> rules = new Dictionary<int, string>();
			List<string> msg = new List<string>();

			foreach (var item in input)
			{
				if (item != "" && item.Contains(":"))
				{
					rules[int.Parse(item.Split(':')[0])] = item.Split(':')[1].Substring(1);
				}
				else if (item != "")
				{
					msg.Add(item);
				}
			}

			string rule = rules[0];
			Regex regex = new Regex(@"\d+", RegexOptions.Compiled);
			while (true)
			{
				Match match = regex.Match(rule);
				if (match.Success)
				{
					string thing = rules[int.Parse(match.Value)];
					if (thing.Contains("\""))
					{
						thing = thing.Substring(1, thing.Length - 2);
					}
					else
					{
						thing = "(" + thing + ")";
					}
					rule = regex.Replace(rule, thing, 1);
				}
				else
				{
					break;
				}
				//Console.WriteLine(rule);
			}
			rule = rule.Replace(" ", "");
			//Console.WriteLine(rule);
			int valid = 0;
			foreach (var item in msg)
			{
				if (Regex.IsMatch(item, "^" + rule + "$")) valid++;
			}
			Console.WriteLine(valid);


			rules[8] = "42 | 42 (42 | 42 (42 | 42 (42 | 42 (42 | 42 (42 | 42 (42 | 42 (42 | 42 (42 | 42 (42 | 42 (42))))))))))";
			rules[11] = "42 31 | 42 (42 31 | 42 (42 31 | 42 (42 31 | 42 (42 31 | 42 (42 31 | 42 (42 31 | 42 (42 31 | 42 (42 31 | 42 (42 31 | 42 (42 31 | 42 31) 31) 31) 31) 31) 31) 31) 31) 31) 31) 31";

			rule = rules[0];
			while (true)
			{
				Match match = regex.Match(rule);
				if (match.Success)
				{
					string thing = rules[int.Parse(match.Value)];

					if (thing.Contains("\""))
					{
						thing = thing.Substring(1, thing.Length - 2);
					}
					else
					{
						thing = "(" + thing + ")";
					}
					rule = regex.Replace(rule, thing, 1);
				}
				else
				{
					break;
				}
				//Console.WriteLine(rule);
			}
			rule = rule.Replace(" ", "");
			//Console.WriteLine(rule);
			valid = 0;
			foreach (var item in msg)
			{
				if (Regex.IsMatch(item, "^" + rule + "$")) valid++;
			}
			Console.WriteLine(valid);


			/*rulesParsed[0] = ValidMessages(0);
			;

			foreach (var item in rulesParsed[0])
			{
				Console.WriteLine(item);
			}*/
			/*List<string> ValidMessages(int ID)
			{
				List<string> accept = new List<string>();
				string rule = rules[ID];
				if (rulesParsed.ContainsKey(ID))
				{
					return rulesParsed[ID];
				}
				if (rule.StartsWith("\""))
				{
					accept.Add(rules[ID].Split('"')[1]);
				}
				else
				{
					string[] subrule = rule.Split('|');
					foreach (string item in subrule)
					{
						string aaa = "";
						string[] subsubrule = item.Split(' ');
						foreach (string subitem in subsubrule)
						{
							if (subitem != "")
							{
								foreach (var piece in ValidMessages(int.Parse(subitem)))
								{
									aaa += piece;

								}

							}
						}
						accept.Add(aaa);
					}
				}
				rulesParsed[ID] = accept;
				return accept;
			}*/
		}
	}
}
