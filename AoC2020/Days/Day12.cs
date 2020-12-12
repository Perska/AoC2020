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
			int x = 0, y = 0, rot = 0;
			// 0 : east
			foreach (var item in input)
			{
				if (item != "")
				{
					switch (item[0])
					{
						case 'N':
							y -= num(item);
							break;
						case 'E':
							x += num(item);
							break;
						case 'S':
							y += num(item);
							break;
						case 'W':
							x -= num(item);
							break;
						case 'L':
							rot = (rot + 4 - (num(item) / 90)) % 4;
							break;
						case 'R':
							rot = (rot + (num(item) / 90)) % 4;
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
							break;
						default:
							break;
					}
				}
			}

			Console.WriteLine($"{Math.Abs(x) + Math.Abs(y)}");

			x = 0;
			y = 0;
			rot = 0;
			int x2 = 10, y2 = -1;

			foreach (var item in input)
			{
				if (item != "")
				{
					rot = 0;
					switch (item[0])
					{
						case 'N':
							y2 -= num(item);
							break;
						case 'E':
							x2 += num(item);
							break;
						case 'S':
							y2 += num(item);
							break;
						case 'W':
							x2 -= num(item);
							break;
						case 'L':
							rot = (4 - (num(item) / 90)) % 4;
							break;
						case 'R':
							rot = ((num(item) / 90)) % 4;
							break;
						case 'F':
							x += x2 * num(item);
							y += y2 * num(item);
							break;
						default:
							break;
					}
					for (int i = 0; i < rot; i++)
					{
						int ox = x2;
						x2 = -y2;
						y2 = ox;
					}
				}

			}


			Console.WriteLine($"{Math.Abs(x) + Math.Abs(y)}");

			int num(string it)
			{
				return int.Parse(it.Substring(1));
			}
		}
	}
}
