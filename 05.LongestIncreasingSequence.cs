using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Write a program to find all increasing sequences inside an array of integers. 
/// The integers are given on a single line, separated by a space. Print the sequences 
/// in the order of their appearance in the input array, each at a single line. 
/// Separate the sequence elements by a space. Find also the longest increasing sequence 
/// and print it at the last line. If several sequences have the same longest length, print the left-most of them.

class LongestIncreasingSequence
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        List<List<int>> subsets = GetSubsets(numbers);
        List<int> longestSubset = subsets[0];
        for (int i = 0; i < subsets.Count; i++)
        {
            PrintSubset(subsets[i]);
            if (longestSubset.Count < subsets[i].Count)
            {
                longestSubset = subsets[i];
            }
        }
        //PrintSubset(subsets[subsets.Count - 1]);
        Console.Write("Longest: ");
        PrintSubset(longestSubset);
    }

    private static void PrintSubset(List<int> result)
    {
        foreach (int num in result)
        {
            Console.Write("{0} ", num);
        }
        Console.WriteLine();
    }

    static List<List<int>> GetSubsets(int[] set)
    {
        List<List<int>> subsets = new List<List<int>>();
        for (int i = 0, j = 0; j < set.Length; i++, j++)
        {
            subsets.Add(new List<int>());
            subsets[i].Add(set[j]);

            for (; j < set.Length - 1; j++)
            {
                if (set[j] < set[j + 1])
                {
                    subsets[i].Add(set[j + 1]);
                }
                else
                {
                    break;
                }
            }
        }
        return subsets;
    }
}

