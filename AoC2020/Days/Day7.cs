using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day7(List<string> input)
		{
			Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();
			foreach (string rule in input)
			{
				if (rule == "") continue;
				string[] part = rule.Replace(".", "").Split(new string[] { " bags contain " }, StringSplitOptions.None);
				rules[part[0]] = part[1].Replace("bags", "bag").Replace(" bag", "").Split(new string[] { ", " }, StringSplitOptions.None).ToList();
			}

			int count = 0;
			foreach (var item in rules)
			{
				if (BagContains(rules, item.Key, "shiny gold")) count++;
			}
			Console.WriteLine(count);
			Console.WriteLine(CountBags(rules,"shiny gold"));
		}

		static bool BagContains(Dictionary<string, List<string>> rules, string bag, string targetBag)
		{
			if (rules[bag].Where(item => item.Contains(targetBag)).Count() != 0) return true;
			foreach (var item in rules[bag])
			{
				if (item == "no other") continue;
				if (BagContains(rules, item.Substring(2), targetBag)) return true;
			}
			return false;
		}

		static int CountBags(Dictionary<string, List<string>> rules, string bag)
		{
			int bags = 0;
			foreach (var item in rules[bag])
			{
				if (item == "no other") continue;
				int bagM = item[0] - '0';
				bags+=bagM;
				for (int i = 0; i < bagM; i++)
				{
					bags += CountBags(rules, item.Substring(2));
				}
			}
			return bags;
		}
	}
}
