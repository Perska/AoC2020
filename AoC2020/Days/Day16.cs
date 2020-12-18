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
		static void Day16(List<string> input)
		{
			var rules = new Dictionary<string, (int, int, int, int)>();
			var ruleValid = new Dictionary<string, int[]>();
			var myTicket = new List<int>();
			var otherTickets = new List<List<int>>();
			var ticketBad = new List<List<int>>();
			string[] fields;
			int i;
			for (i = 0; i < input.Count; i++)
			{
				Match match = Regex.Match(input[i], @"([a-z ]+): (\d+)-(\d+) or (\d+)-(\d+)", RegexOptions.Compiled);
				if (match.Success)
				{
					rules[match.Groups[1].Value] = (int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value));
				}
				//rules[]
				if (input[i] == "") break;
			}
			i += 2;
			foreach (var item in input[i].Split(','))
			{
				if (item != "" && int.TryParse(item, out int res)) myTicket.Add(res);
			}
			
			i += 2;
			for (; i < input.Count; i++)
			{
				var list = new List<int>();
				foreach (var item in input[i].Split(','))
				{
					if (item != "" && int.TryParse(item, out int res)) list.Add(res);
				}
				if (list.Count != 0) otherTickets.Add(list);
			}
			
			foreach (var rule in rules)
			{
				ruleValid[rule.Key] = new int[myTicket.Count];
			}

			List<int> badValues = new List<int>();
			foreach (var ticket in otherTickets)
			{
				for (int n = 0; n < ticket.Count; n++)
				{
					int num = ticket[n];
					bool noGood = true;
					foreach (var rule in rules)
					{
						if ((rule.Value.Item1 <= num && num <= rule.Value.Item2) || (rule.Value.Item3 <= num && num <= rule.Value.Item4))
						{
							noGood = false;
						}
					}
					if (noGood)
					{
						badValues.Add(num);
						ticketBad.Add(ticket);
					}
				}
			}
			Console.WriteLine(badValues.Sum(item => item));
			otherTickets.RemoveAll(ticket => ticketBad.Contains(ticket));
			badValues.Clear();
			foreach (var ticket in otherTickets)
			{
				for (int n = 0; n < ticket.Count; n++)
				{
					int num = ticket[n];
					bool noGood = true;
					foreach (var rule in rules)
					{
						if ((rule.Value.Item1 <= num && num <= rule.Value.Item2) || (rule.Value.Item3 <= num && num <= rule.Value.Item4))
						{
							ruleValid[rule.Key][n]++;
							noGood = false;
						}
					}
					if (noGood)
					{
						badValues.Add(num);
						ticketBad.Add(ticket);
					}
				}
			}
			fields = new string[myTicket.Count];
			//ruleValid.Where(item=>item.Value.)
			while (true)
			{
				var singleField = ruleValid.Where(item => item.Value.Count(ok => ok == otherTickets.Count) == 1);
				if (singleField.Count() == 0) break;
				foreach (var rule in singleField)
				{
					int index = Array.FindIndex(rule.Value, item => item == otherTickets.Count);
					fields[index] = rule.Key;
					foreach (var rule2 in ruleValid)
					{
						rule2.Value[index] = 0;
					}
				}
			}
			long departure = 1;
			for (i = 0; i < fields.Length; i++)
			{
				//Console.WriteLine($"{fields[i]}: {myTicket[i]}");
				if (fields[i].StartsWith("departure")) departure *= myTicket[i];
			}
			Console.WriteLine(departure);
		}
	}
}
