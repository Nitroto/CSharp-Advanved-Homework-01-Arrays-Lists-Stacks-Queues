using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Write a program that reads from the console a number N and an array of integers given on a single line. 
/// Your task is to find all subsets within the array which have a sum equal to N and print them on the console 
/// (the order of printing is not important). Find only the unique subsets by filtering out repeating numbers 
/// first. In case there aren't any subsets with the desired sum, print "No matching subsets."

class SubsetSums
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
        if (goodSubsets.Count > 1)
        {
            foreach (var set in goodSubsets)
            {
                PrintResult(set);
            }
        }
        else
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