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
		static void Day21(List<string> input)
		{
			List<string> ingredients = new List<string>();
			List<string> allergens = new List<string>();
			Dictionary<string, int> allergenCount = new Dictionary<string, int>();
			Dictionary<string, Dictionary<string, int>> listings = new Dictionary<string, Dictionary<string, int>>();
			Regex regex = new Regex(@"(.*) \(contains (.*)\)", RegexOptions.Compiled | RegexOptions.ECMAScript);
			foreach (var item in input)
			{
				Match match = regex.Match(item);
				if (match.Success)
				{
					var ingredientPart = match.Groups[1].Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					var allergenPart = match.Groups[2].Value.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
					foreach (var allerg in allergenPart)
					{
						foreach (var ingred in ingredientPart)
						{
							if (!listings.ContainsKey(ingred)) listings[ingred] = new Dictionary<string, int>();
							if (!listings[ingred].ContainsKey(allerg)) listings[ingred][allerg] = 0;
							listings[ingred][allerg]++;
						}
						if (!allergenCount.ContainsKey(allerg)) allergenCount[allerg] = 0;
						allergenCount[allerg]++;
					}
					ingredients.AddRange(ingredientPart);
					allergens.AddRange(allergenPart);
				}
			}
			//ingredients = ingredients.Distinct().ToList();
			//allergens =     allergens.Distinct().ToList();

			Dictionary<string, string> ingredientAllergen = new Dictionary<string, string>();
			//var l = listings.ToList().OrderBy(item => item.Value.Count(sub => sub.Value == allergenCount[sub.Key]));

			while (true)
			{
				var singleField = listings.Where(item => item.Value.Count(ok => ok.Value == allergenCount[ok.Key]) == 1);
				if (singleField.Count() == 0) break;
				foreach (var rule in singleField)
				{
					/*foreach (var item in listings)
					{
						foreach (var item2 in item.Value)
						{
							if (item2.Value==true) allerg = item.Key
						}
					}*/
					string allerg = rule.Value.First(item => item.Value == allergenCount[item.Key]).Key;
					ingredientAllergen[rule.Key] = allerg;
					foreach (var rule2 in listings)
					{
						rule2.Value[allerg] = 0;
					}
				}
			}
			int count = 0;
			foreach (var item in ingredients)
			{
				if (!ingredientAllergen.ContainsKey(item)) count++;
			}
			Console.WriteLine($"Part 1: {count}");
			string danger = "";
			foreach (var item in ingredientAllergen.OrderBy(item => item.Value))
			{
				danger += item.Key + ",";
			}
			danger = danger.Substring(0, danger.Length - 1);
			Console.WriteLine(danger);
			;
		}
	}
}
