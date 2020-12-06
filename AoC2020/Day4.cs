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
		static void Day4(List<string> input)
		{
			Dictionary<string,string> fields = new Dictionary<string, string>();
			List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
			string[] requiredFields = new string[]
			{
				"byr",
				"iyr",
				"eyr",
				"hgt",
				"hcl",
				"ecl",
				"pid",
			};
			bool[] correct = new bool[requiredFields.Length];
			int validPassports = 0;
			foreach (string line in input)
			{
				if (line == "")
				{
					for (int i = 0; i < requiredFields.Length; i++)
					{
						if (fields.Keys.Contains(requiredFields[i])) correct[i] = true;
					}
					if (!correct.Contains(false))
					{
						validPassports++;
						passports.Add(fields);
					}
					correct = new bool[requiredFields.Length];
					fields = new Dictionary<string, string>();
				}
				else
				{
					foreach (string item in line.Split(' '))
					{
						fields.Add(item.Split(':')[0], item.Split(':')[1]);
					}
				}
			}

			Console.WriteLine($"{validPassports}");

			var aaa = passports.Where(passport =>
					  int.Parse(passport["byr"]) >= 1920 &&
					  int.Parse(passport["byr"]) <= 2002 &&
					  int.Parse(passport["iyr"]) >= 2010 &&
					  int.Parse(passport["iyr"]) <= 2020 &&
					  int.Parse(passport["eyr"]) >= 2020 &&
					  int.Parse(passport["eyr"]) <= 2030 &&
					  ((passport["hgt"].Contains("cm") && (int.Parse(passport["hgt"].Trim('c', 'm')) >= 150 && int.Parse(passport["hgt"].Trim('c', 'm')) <= 193)) ||
					  (passport["hgt"].Contains("in") && (int.Parse(passport["hgt"].Trim('i', 'n')) >= 59 && int.Parse(passport["hgt"].Trim('i', 'n')) <= 76))) &&
					  Regex.IsMatch(passport["hcl"], "^#[a-z0-9]{6}$") &&
					  new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(passport["ecl"]) &&
					  Regex.IsMatch(passport["pid"], "^[0-9]{9}$")
					  );

			Console.WriteLine($"{aaa.Count()}");
		}
	}
}
