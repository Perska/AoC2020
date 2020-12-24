using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day24(List<string> input)
		{
			Dictionary<(int X, int Y), bool> grid = new Dictionary<(int X, int Y), bool>();
			Dictionary<(int X, int Y), bool> grid2 = new Dictionary<(int X, int Y), bool>();
			foreach (var item in input)
			{
				if (item != "")
				{
					int X = 0, Y = 0;
					string move = item;
					while (move.Length > 0)
					{
						if (Eat(ref move, "e"))
						{
							X++;
						}
						else if (Eat(ref move, "se"))
						{
							X++;
							Y++;
						}
						else if (Eat(ref move, "sw"))
						{
							Y++;
						}
						else if (Eat(ref move, "w"))
						{
							X--;
						}
						else if (Eat(ref move, "nw"))
						{
							X--;
							Y--;
						}
						else if (Eat(ref move, "ne"))
						{
							Y--;
						}
						else
						{
							throw new Exception();
						}
					}
					FlipPanel(grid, X, Y);
				}
			}
			

			Console.WriteLine(grid.Count(item => item.Value == true));

			for (int i = 0; i < 100; i++)
			{
				List<(int X, int Y)> flipped = grid.Keys.ToList();

				foreach (var tile in flipped)
				{
					foreach (var neighbour in Neighbours(tile.X, tile.Y, true))
					{
						IEnumerable<(int X, int Y)> neighbours = Neighbours(neighbour.X, neighbour.Y);
						int activeNeighbours = neighbours.Count(item => grid.ContainsKey(item));
						bool currentLit = grid.TryGetValue(neighbour, out bool res);
						if (currentLit)
						{
							if (activeNeighbours != 0 && activeNeighbours < 3)
							{
								grid2[neighbour] = true;
							}
						}
						else
						{
							if (activeNeighbours == 2)
							{
								grid2[neighbour] = true;
							}
						}
					}
				}
				grid.Clear();
				(grid, grid2) = (grid2, grid);
			}

			Console.WriteLine(grid.Count(item => item.Value == true));
		}

		static IEnumerable<(int X, int Y)> Neighbours(int X, int Y, bool self = false)
		{
			if (self) yield return (X, Y);
			yield return (X + 1, Y);
			yield return (X + 1, Y + 1);
			yield return (X, Y + 1);
			yield return (X - 1, Y);
			yield return (X - 1, Y - 1);
			yield return (X, Y - 1);
		}

		static void FlipPanel(Dictionary<(int X, int Y), bool> grid, int X, int Y)
		{
			grid.TryGetValue((X, Y), out bool flip);
			if (flip)
			{
				grid.Remove((X, Y));
			}
			else
			{
				grid[(X, Y)] = true;
			}
		}

		static bool Eat(ref string str, string eat)
		{
			if (str.StartsWith(eat))
			{
				str = str.Substring(eat.Length);
				return true;
			}
			return false;
		}
	}
}
