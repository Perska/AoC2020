﻿using System;
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
			Day1, Day2, Day3, Day4, Day5, Day6
		};

		static void Main()
		{
			bool keepGoing = true;


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
							string line = Console.ReadLine();
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
	}
}
