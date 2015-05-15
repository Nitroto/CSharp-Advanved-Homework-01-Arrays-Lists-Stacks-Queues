using System;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Write a program to sort an array of numbers and then print them back on the console. The numbers should be entered from 
/// the console on a single line, separated by a space. Refer to the examples for problem 1.
/// Note: Do not use the built-in sorting method, you should write your own.Use the selection sort algorithm. 
/// Hint: To understand the sorting process better you may use a visual aid, e.g.Visualgo.

class SortArrayOfNumbersUsingBubbleSort
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a)).ToArray();
        int min, tmp;
        for (int i = 0; i < array.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }
            tmp = array[min];
            array[min] = array[i];
            array[i] = tmp;
        }
        foreach (int number in array)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
    }
}
