using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	/// <summary>
	/// This class contains code not written by me.
	/// </summary>
	static class HelpF
	{
		/// <summary>
		/// Get all the combinations of replacing a character in a string.
		/// Modified to replace X with 1 or 0 instead of 0 with 0 or o.
		/// https://stackoverflow.com/a/28819490
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static IEnumerable<string> Combinations(string input)
		{
			int firstZero = input.IndexOf('X');   // Get index of first '0'
			if (firstZero == -1)      // Base case: no further combinations
				return new string[] { input };

			string prefix = input.Substring(0, firstZero);    // Substring preceding '0'
			string suffix = input.Substring(firstZero + 1);   // Substring succeeding '0'
															  // e.g. Suppose input was "fr0d00"
															  //      Prefix is "fr"; suffix is "d00"

			// Recursion: Generate all combinations of suffix
			// e.g. "d00", "d0o", "do0", "doo"
			var recursiveCombinations = Combinations(suffix);

			// Return sequence in which each string is a concatenation of the
			// prefix, either '0' or 'o', and one of the recursively-found suffixes
			return
				from chr in "01"  // char sequence equivalent to: new [] { '0', 'o' }
				from recSuffix in recursiveCombinations
				select prefix + chr + recSuffix;
		}

		/// <summary>
		/// Rotates an array by 90 degrees.
		/// Modified to be generic and automatically get the array dimension size.
		/// https://stackoverflow.com/a/42535
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="matrix"></param>
		/// <returns></returns>
		public static T[,] RotateMatrix<T>(T[,] matrix)
		{
			int n = matrix.GetLength(0);
			if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException();
			T[,] ret = new T[n, n];

			for (int i = 0; i < n; ++i)
			{
				for (int j = 0; j < n; ++j)
				{
					ret[j, i] = matrix[i, n - j - 1];
				}
			}

			return ret;
		}
	}
}