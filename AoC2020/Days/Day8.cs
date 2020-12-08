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
		class Opcode
		{
			public string name;
			public int value;
			public int runs;
			public int pos;

			public Opcode(string s, int v, int r, int p)
			{
				name = s;
				value = v;
				runs = r;
				pos = p;
			}

			public override string ToString()
			{
				return $"{name} {value} x{runs}";
			}
		}

		static void Day8(List<string> input)
		{
			List<Opcode> PRG = new List<Opcode>();


			foreach (string item in input)
			{
				string[] split = item.Split(' ');
				if (split.Length != 2) continue;
				PRG.Add(new Opcode(split[0], int.Parse(split[1]), 0, PRG.Count));
			}


			int acc = 0;
			int ctr = 0;
			int oldCtr = 0;

			RunCode();
			Console.WriteLine(acc);

			for (int i = 0; i < PRG.Count; i++)
			{
				if (PRG[i].name == "jmp" || PRG[i].name == "nop")
				{
					PRG[i].name = PRG[i].name == "jmp" ? "nop" : "jmp";
					if (!RunCode())
					{
						Console.WriteLine($"Program ends when opcode {i} is swapped");
						//Console.WriteLine(acc);
						break;
					}
					Console.WriteLine(acc);
					PRG[i].name = PRG[i].name == "jmp" ? "nop" : "jmp";
				}
			}
			Console.WriteLine(acc);
			;
			bool RunCode()
			{
				ctr = 0;
				oldCtr = 0;
				acc = 0;
				foreach (var item in PRG)
				{
					item.runs = 0;
				}
				while (ctr < PRG.Count)
				{
					PRG[ctr].runs++;
					if (PRG[ctr].runs == 2)
					{
						return true;
					}
					oldCtr = ctr;
					var opcode = PRG[ctr];
					switch (opcode.name)
					{
						case "nop":
							break;
						case "acc":
							acc += opcode.value;
							break;
						case "jmp":
							ctr += opcode.value - 1;
							break;
						default:
							break;
					}
					ctr++;

				}
				return false;
			}
		}
	}
}
