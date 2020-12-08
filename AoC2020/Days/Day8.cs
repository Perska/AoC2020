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
		class VirtualMachine
		{
			public int pc;
			public int oldPc;
			public int acc;
			public List<Opcode> PRG;

			/// <summary>
			/// Run the vm for a single op code.
			/// Returns true if the program counter fails to run due to there not being more code.
			/// </summary>
			/// <returns>If true, single step was cancelled because pc >= PRG.count</returns>
			public bool SingleStep()
			{
				if (pc >= PRG.Count) return true;
				PRG[pc].runs++;
				oldPc = pc;
				var opcode = PRG[pc];
				switch (opcode.name)
				{
					case "nop":
						break;
					case "acc":
						acc += opcode.value;
						break;
					case "jmp":
						pc += opcode.value - 1;
						break;
					default:
						break;
				}
				pc++;
				return false;
			}

			public bool RunUntil(int repeat)
			{
				if (repeat < 2) repeat = 2;
				foreach (var item in PRG)
				{
					item.runs = 0;
				}
				while (pc < PRG.Count)
				{
					if (PRG[pc].runs + 1 == repeat)
					{
						return true;
					}
					SingleStep();
				}
				return false;
			}

			public VirtualMachine(List<string> code)
			{
				PRG = new List<Opcode>();
				foreach (string item in code)
				{
					string[] split = item.Split(' ');
					if (split.Length != 2) continue;
					PRG.Add(new Opcode(split[0], int.Parse(split[1]), 0, PRG.Count));
				}
			}

			public void Reset()
			{
				pc = 0;
				oldPc = 0;
				acc = 0;
				foreach (var opcode in PRG)
				{
					opcode.runs = 0;
				}
			}
		}

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
			VirtualMachine vm = new VirtualMachine(input);

			vm.RunUntil(2);
			Console.WriteLine($"Accumulator just before repeating an instruction: {vm.acc}");

			for (int i = 0; i < vm.PRG.Count; i++)
			{
				if (vm.PRG[i].name == "jmp" || vm.PRG[i].name == "nop")
				{
					vm.PRG[i].name = vm.PRG[i].name == "jmp" ? "nop" : "jmp";
					vm.Reset();
					if (!vm.RunUntil(2))
					{
						Console.WriteLine($"Program ends when opcode {i} is swapped");
						Console.WriteLine($"Accumulator: {vm.acc}");
						break;
					}
					//Console.WriteLine(acc);
					vm.PRG[i].name = vm.PRG[i].name == "jmp" ? "nop" : "jmp";
				}
			}
			//Console.WriteLine(acc);
			;
			
		}
	}
}
