using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Write a program that reads an array of strings and finds in it all sequences of equal elements 
/// (comparison should be case-insensitive). The input strings are given as a single line, separated by a space. 

class SequencesOfEqualStrings
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string[] stringMatrix = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        Dictionary<string, int> strings = new Dictionary<string, int>();
        for (int i = 0; i < stringMatrix.Length; i++)
        {
            int count = 1;
            if (stringMatrix[i] != null)
            {
                strings.Add(stringMatrix[i], 0);
                for (int j = i + 1; j < stringMatrix.Length; j++)
                {
                    if (stringMatrix[i] == stringMatrix[j])
                    {
                        count++;
                        stringMatrix[j] = null;
                    }
                }
                strings[stringMatrix[i]] = count;
            }
        }
        foreach (string key in strings.Keys)
        {
            for (int i = 0; i < strings[key]; i++)
            {
                Console.Write("{0} ", key);
            }
            Console.WriteLine();
        }
    }
}

