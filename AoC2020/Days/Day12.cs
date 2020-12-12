using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day12(List<string> input)
		{
			int x = 0, y = 0;
			int x2 = 0, y2 = 0;
			int x3 = 10, y3 = -1;
			int rot = 0, rot2 = 0;
			foreach (var item in input)
			{
				if (item != "")
				{
					rot2 = 0;
					switch (item[0])
					{
						case 'N':
							y -= num(item);
							y3 -= num(item);
							break;
						case 'E':
							x += num(item);
							x3 += num(item);
							break;
						case 'S':
							y += num(item);
							y3 += num(item);
							break;
						case 'W':
							x -= num(item);
							x3 -= num(item);
							break;
						case 'L':
							rot = (rot + 4 - (num(item) / 90)) % 4;
							rot2 = (4 - (num(item) / 90)) % 4;
							break;
						case 'R':
							rot = (rot + (num(item) / 90)) % 4;
							rot2 = ((num(item) / 90)) % 4;
							break;
						case 'F':
							if (rot == 0)
							{
								x += num(item);
							}
							else if (rot == 1)
							{
								y += num(item);
							}
							else if (rot == 2)
							{
								x -= num(item);
							}
							else if (rot == 3)
							{
								y -= num(item);
							}
							x2 += x3 * num(item);
							y2 += y3 * num(item);
							break;
						default:
							break;
					}

					for (int i = 0; i < rot2; i++)
					{
						int ox = x3;
						x3 = -y3;
						y3 = ox;
					}
				}
			}

			Console.WriteLine($"{Math.Abs(x) + Math.Abs(y)}");
			Console.WriteLine($"{Math.Abs(x2) + Math.Abs(y2)}");

			int num(string it)
			{
				return int.Parse(it.Substring(1));
			}
		}
	}
}
