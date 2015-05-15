using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Modify the program you wrote for the previous problem to print the results in the following way: each line should 
/// contain the operands(numbers that form the desired sum) in ascending order; the lines containing fewer operands 
/// should be printed before those with more operands; when two lines have the same number of operands, the one containing 
/// the smallest operand should be printed first.If two or more lines contain the same number of operands and have the 
/// same smallest operand, the order of printing is not important.

class SortedSubsetSums
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        int[] userInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        var subsets = GetSubsets(userInput);
        List<List<int>> goodSubsets = new List<List<int>>();
        foreach (var set in subsets)
        {
            if (set.Sum() == n)
            {
                goodSubsets.Add(set);
            }
        }
        for (int i = 0; i < goodSubsets.Count - 1; i++)
        {
            for (int j = 1; j < goodSubsets.Count - i; j++)
            {
                if (goodSubsets[i].Count == goodSubsets[i + j].Count)
                {
                    List<int> temp1 = goodSubsets[i];
                    List<int> temp2 = goodSubsets[i + j];
                    temp1.Sort();
                    temp2.Sort();
                    int countSameElements = 0;
                    for (int k = 0; k < goodSubsets[i].Count; k++)
                    {
                        if (temp1[k] == temp2[k])
                        {
                            countSameElements++;
                        }
                    }
                    if (countSameElements == goodSubsets[i].Count)
                    {
                        goodSubsets.Remove(goodSubsets[i + j]);
                    }
                }
            }
        }
        foreach (var subset in goodSubsets)
        {
            subset.Sort();
        }
        List<List<int>> sortedSubsets = goodSubsets.OrderBy(c => c.Count).ThenBy(o => o[0]).ToList();
        foreach (var set in sortedSubsets)
        {
            PrintResult(set);
        }

        if (goodSubsets.Count == 0)
        {
            Console.WriteLine("No matching subsets.");
        }
    }

    private static void PrintResult(List<int> set)
    {
        for (int i = 0; i < set.Count; i++)
        {
            if (i != set.Count - 1)
            {
                Console.Write("{0} + ", set[i]);
            }
            else
            {
                Console.Write("{0} = {1}", set[i], set.Sum());
            }
        }
        Console.WriteLine();
    }

    static List<List<T>> GetSubsets<T>(IEnumerable<T> Set)
    {
        var set = Set.ToList<T>();
        // Init list
        List<List<T>> subsets = new List<List<T>>();
        subsets.Add(new List<T>()); // add the empty set
        // Loop over individual elements
        for (int i = 1; i < set.Count; i++)
        {
            subsets.Add(new List<T>() { set[i - 1] });
            List<List<T>> newSubsets = new List<List<T>>();
            // Loop over existing subsets
            for (int j = 0; j < subsets.Count; j++)
            {
                var newSubset = new List<T>();
                foreach (var temp in subsets[j])
                {
                    newSubset.Add(temp);
                }
                newSubset.Add(set[i]);
                newSubsets.Add(newSubset);
            }
            subsets.AddRange(newSubsets);
        }
        // Add in the last element
        subsets.Add(new List<T>() { set[set.Count - 1] });
        //subsets.Sort();
        return subsets;
    }
}