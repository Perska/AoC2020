using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		public delegate void DayProgram(List<string> input);

		public static List<DayProgram> days = new List<DayProgram>
		{
			Day01, Day02, Day03, Day04, Day05, Day06, Day07,
			Day08, Day09, Day10, Day11, Day12, Day13, Day14,
			Day15, Day16, Day17, Day18, Day19, Day20, Day21
		};

		static void Main()
		{
			bool keepGoing = true;

			//Console.WriteLine(SuperReadLine());
			while (keepGoing)
			{
				Console.WriteLine("Enter the day you want to run the program for (enter 0 to stop)");
				if (int.TryParse(Console.ReadLine(), out int day))
				{
					DayProgram program = null;
					if (day == 0)
					{
						keepGoing = false;
					}
					else if (1 <= day && day <= days.Count)
					{
						program = days[day - 1];
					}
					else
					{
						Console.WriteLine($"Program for Day {day} is not implemented.");
					}

					if (program != null)
					{
						List<string> input = new List<string>();
						Console.WriteLine("Please enter the program input. Once done, enter \"end\"\n(hint, right-click the window top bar for pasting)");
						while (true)
						{
							string line = day == 21 ? SuperReadLine() : Console.ReadLine();
							if (line.ToLowerInvariant().StartsWith("end")) break;
							input.Add(line);
						}
						//input.RemoveAll(item => item.Length == 0);
						if (input.LastOrDefault() != "")
						{
							input.Add("");
						}
						program(input);
					}
				}
				else
				{
					Console.WriteLine("Not a valid number");
				}
				Console.WriteLine();
			}
		}

		static string SuperReadLine()
		{
			char key;
			StringBuilder input = new StringBuilder();
			int x = Console.CursorLeft, y = Console.CursorTop;
			while ((key = Console.ReadKey(true).KeyChar) != 13)
			{
				if (key == 8 && input.Length > 0)
				{
					input.Remove(input.Length - 1, 1);
				}
				else if (key != 8)
				{
					input.Append(key);
				}
				if (key == 8)
				{
					Console.SetCursorPosition((x + Math.Max(input.Length - 1, 0)) % Console.BufferWidth, y + (x + Math.Max(input.Length - 1, 0)) / Console.BufferWidth);
					Console.Write(input.ToString().LastOrDefault().ToString() + '\0');
					Console.SetCursorPosition((x + input.Length) % Console.BufferWidth, y + (x + input.Length) / Console.BufferWidth);
				}
				else
				{
					Console.Write(key);
					//Console.SetCursorPosition((x + input.Length) % Console.BufferWidth, y + (x + input.Length) / Console.BufferWidth);
				}
			}
			Console.SetCursorPosition(0, y + (x + input.Length) / Console.BufferWidth + 1);
			return input.ToString();
		}
	}
}
