using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day13(List<string> input)
		{
			long earliest = int.Parse(input[0]);
			List<int> buses = new List<int>();
			foreach (var item in input[1].Split(','))
			{
				if (item == "x")
				{
					buses.Add(-1);
					continue;
				}

				buses.Add(int.Parse(item));
			}
			long waited = 0;
			int id = 0;
			while ((id = busOK()) == 0)
			{
				waited++;
			}

			Console.WriteLine($"{waited} x {id} = {waited * id}");
			waited = 0;
			long prod = 1;
			for (int i = 0; i < buses.Count; i++)
			{
				while ((waited + i) % buses[i] > 0)
				{
					waited += prod;
				}
				prod *= Math.Abs(buses[i]);

			}
			Console.WriteLine($"{waited}");
			
			int busOK()
			{
				for (int i = 0; i < buses.Count; i++)
				{
					if (buses[i] == -1) continue;
					if (((earliest + waited) % buses[i]) == 0) return buses[i];
				}
				return 0;
			}
		}
	}
}
