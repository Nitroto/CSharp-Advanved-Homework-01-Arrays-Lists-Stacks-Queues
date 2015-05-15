using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Write a program that reads N floating-point numbers from the console. Your task is to 
/// separate them in two sets, one containing only the round numbers (e.g. 1, 1.00, etc.) 
/// and the other containing the floating-point numbers with non-zero fraction. Print both 
/// arrays along with their minimum, maximum, sum and average (rounded to two decimal places).


class CategorizeNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double[] userInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
        List<int> roundNumbers = new List<int>();
        List<double> floatingPointNumbers = new List<double>();
        foreach (double number in userInput)
        {
            if (number - (int)number == 0)
            {
                roundNumbers.Add((int)number);
            }
            else
            {
                floatingPointNumbers.Add(number);
            }
        }
        Console.Write("[ ");
        for (int i = 0; i < floatingPointNumbers.Count; i++)
        {
            if (i != (floatingPointNumbers.Count - 1))
            {
                Console.Write("{0}, ", floatingPointNumbers[i]);
            }
            else
            {
                Console.Write("{0} ", floatingPointNumbers[i]);
            }
        }
        Console.WriteLine("] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}", floatingPointNumbers.Min(), floatingPointNumbers.Max(), 
                                                                            floatingPointNumbers.Sum(), floatingPointNumbers.Average());
        Console.Write("[ ");
        for (int i = 0; i < roundNumbers.Count; i++)
        {
            if (i != (roundNumbers.Count - 1))
            {
                Console.Write("{0}, ", roundNumbers[i]);
            }
            else
            {
                Console.Write("{0} ", roundNumbers[i]);
            }
        }
        Console.WriteLine("] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}", roundNumbers.Min(), roundNumbers.Max(),
                                                                            roundNumbers.Sum(), roundNumbers.Average());
    }
}
