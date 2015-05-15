using System;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Write a program to sort an array of numbers and then print them back on the console.
/// The numbers should be entered from the console on a single line, separated by a space.

class SortArrayOfNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        Array.Sort(array);
        foreach (int number in array)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
    }
}

