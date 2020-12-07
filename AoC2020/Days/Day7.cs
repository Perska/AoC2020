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
			Dictionary<string, int> extra = new Dictionary<string, int>();
			Dictionary<string, ulong> extra2 = new Dictionary<string, ulong>();
			Dictionary<string, ulong> allBags = new Dictionary<string, ulong>();
			foreach (string rule in input)
			{
				if (rule == "") continue;
				string[] part = rule.Replace(".", "").Split(new string[] { " bags contain " }, StringSplitOptions.None);
				rules[part[0]] = part[1].Replace("bags", "bag").Replace(" bag", "").Split(new string[] { ", " }, StringSplitOptions.None).ToList();
			}

			int count = 0;
			foreach (var item in rules)
			{
				if (BagContains(rules, item.Key, "shiny gold"))
				{
					count++;
					extra[item.Key] = 0;
				}
				allBags[item.Key] = 0;
			}
			Console.WriteLine(count);
			Console.WriteLine(CountBags(rules,"shiny gold"));

			/* EXTRA: */
			List<int> bagCounts = new List<int>();
			foreach (var item in extra)
			{
				extra2[item.Key] = CountBags(rules, item.Key, extra2);
			}
			ulong biggestBag = extra2.Max(item => item.Value);
			Console.WriteLine($"\nExtra:\nMax bag count in bags that had a shiny gold bag is {biggestBag} in a {extra2.First(item => item.Value == biggestBag).Key} bag.");
			foreach (var item in allBags)
			{
				extra2[item.Key] = CountBags(rules, item.Key, extra2);
				//Console.WriteLine($"{item.Key}: {extra2[item.Key]} bags");
			}
			biggestBag = extra2.Max(item => item.Value);
			Console.WriteLine($"And max bag count with every bag is {biggestBag} in a {extra2.First(item => item.Value == biggestBag).Key} bag.");
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

		static ulong CountBags(Dictionary<string, List<string>> rules, string bag, Dictionary<string, ulong> cache = null)
		{
			ulong bags = 0;
			if (cache != null && cache.ContainsKey(bag))
			{
				bags = cache[bag];
			}
			else
			{
				foreach (var item in rules[bag])
				{
					if (item == "no other") continue;
					int bagM = item[0] - '0';
					bags += (ulong)bagM + (ulong)bagM * CountBags(rules, item.Substring(2), cache);
				}
				if (cache != null)
				{
					cache[bag] = bags;
				}
			}
			return bags;
		}
	}
}
