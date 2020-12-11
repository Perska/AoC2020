using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day11(List<string> input)
		{
			List<string> _seat = new List<string>();
			foreach (var item in input)
			{
				if (item.Length != 0) _seat.Add(item);
			}
			char[][][] seat = new char[_seat.Count][][];
			char[][][] newSeat = new char[_seat.Count][][];
			for (int i = 0; i < _seat.Count; i++)
			{
				seat[i] = new char[_seat[i].Length][];
				newSeat[i] = new char[_seat[i].Length][];
				for (int j = 0; j < _seat[0].Length; j++)
				{
					seat[i][j] = new char[2];
					seat[i][j][0] = _seat[i][j];
					seat[i][j][1] = _seat[i][j];

					newSeat[i][j] = new char[2];
					newSeat[i][j][0] = _seat[i][j];
					newSeat[i][j][1] = _seat[i][j];
				}
			}
			bool didChange = false;
			int run = 0;
			while (true)
			{
				didChange = false;
				for (int i = 0; i < _seat.Count; i++)
				{
					for (int j = 0; j < _seat[0].Length; j++)
					{
						for (int k = 0; k < 2; k++)
						{
							int neighbors = 0;
							if (seat[i][j][k] != '.')
							{
								for (int x = -1; x <= 1; x++)
								{
									for (int y = -1; y <= 1; y++)
									{
										if (x == 0 && y == 0) continue;
										int s = 1;
										while ((0 <= (i + x*s) && (i + x*s) < _seat[0].Length) && (0 <= (j + y*s) && (j + y*s) < _seat.Count))
										{
											if (seat[i + x * s][j + y * s][k] == '#')
											{
												neighbors++;
												break;
											}
											if (seat[i + x * s][j + y * s][k] == 'L')
											{
												break;
											}
											if (k == 0) break;
											s++;
										}
									}
								}
							}
							else
							{
								newSeat[i][j][k] = '.';
								continue;
							}
							if (neighbors >= 4+k && seat[i][j][k] == '#')
							{
								newSeat[i][j][k] = 'L';
								didChange = true;
							}
							else if (neighbors == 0 && seat[i][j][k] == 'L')
							{
								newSeat[i][j][k] = '#';
								didChange = true;
							}
							else
							{
								newSeat[i][j][k] = seat[i][j][k];
							}
						}

					}
				}
				for (int i = 0; i < seat.Length; i++)
				{
					for (int j = 0; j < seat[i].Length; j++)
					{
						seat[i][j][0] = newSeat[i][j][0];
						seat[i][j][1] = newSeat[i][j][1];
					}
				}
				if (!didChange) break;
				run++;
			}
			int seats = 0;
			int seats2 = 0;
			for (int i = 0; i < seat.Length; i++)
			{
				for (int j = 0; j < seat[i].Length; j++)
				{
					if (seat[i][j][0] == '#') seats++;
					if (seat[i][j][1] == '#') seats2++;
				}
			}
			Console.WriteLine(seats);
			Console.WriteLine(seats2);
		}
	}
}
