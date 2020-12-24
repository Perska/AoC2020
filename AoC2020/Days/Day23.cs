using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
	partial class Program
	{
		static void Day23(List<string> input)
		{
			LinkedList<int> cups = new LinkedList<int>();
			LinkedList<int> cups2 = new LinkedList<int>();
			LinkedListNode<int>[] nodeLoc = new LinkedListNode<int>[int.Parse(input[0].Max(item => item - '0').ToString())];
			LinkedListNode<int>[] nodeLoc2 = new LinkedListNode<int>[1000000];
			for (int i = 0; i < input[0].Length; i++)
			{
				int num = int.Parse(input[0][i].ToString());
				nodeLoc[num - 1] = cups.AddLast(num);
				nodeLoc2[num - 1] = cups2.AddLast(num);
			}
			int moreCup = cups.Max() + 1;
			while (moreCup <= 1000000)
			{
				nodeLoc2[moreCup - 1] = cups2.AddLast(moreCup);
				moreCup++;
			}
			var thing = cups2.Reverse().ToList();

			ShuffleCups(cups, nodeLoc, 100);

			
			LinkedListNode<int> index = nodeLoc[0];
			for (int i = 1; i < cups.Count; i++)
			{
				index = index.Next ?? cups.First;
				Console.Write(index.Value);
			}
			Console.WriteLine();

			ShuffleCups(cups2, nodeLoc2, 10000000);
			index = nodeLoc2[0];
			long product = 1;
			for (int i = 0; i < 2; i++)
			{
				index = index.Next ?? cups.First;
				product *= index.Value;
			}
			Console.WriteLine(product);
		}

		static void ShuffleCups(LinkedList<int> cups, LinkedListNode<int>[] nodeLoc, int moves)
		{
			LinkedListNode<int> index = cups.First;
			Stack<int> removed = new Stack<int>();
			int isInMax = cups.Max();
			int currentCup = index.Value;
			for (int move = 0; move < moves; move++)
			{
				currentCup = index.Value;
				for (int i = 0; i < 3; i++)
				{
					int num = (index.Next ?? cups.First).Value;
					removed.Push(num);
					nodeLoc[num - 1] = null;
					cups.Remove(index.Next ?? cups.First);
				}
				int target = currentCup - 1;
				if (target < 1)
				{
					target = isInMax;
				}
				while (nodeLoc[target - 1] == null)
				{
					target--;
					if (target < 1)
					{
						target = isInMax;
					}
				}
				LinkedListNode<int> index2 = nodeLoc[target - 1];
				for (int i = 0; i < 3; i++)
				{
					int num = removed.Pop();
					nodeLoc[num - 1] = cups.AddAfter(index2, num);
				}
				index = index.Next ?? cups.First;
			}
		}
		
	}
}
