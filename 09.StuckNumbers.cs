using System;
using System.Globalization;
using System.Linq;
using System.Threading;

/// You are given n numbers. Write a program to find among these numbers all sets of 4 numbers 
/// {a, b, c, d}, such that a|b == c|d, where a ≠ b ≠ c ≠ d. Assume that "a|b" means to append the 
/// number b after a. We call these numbers {a, b, c, d} stuck numbers: if we append a and b, we get 
/// the same result as if we appended c and d. Note that the numbers a, b, c and d should be distinct (a ≠ b ≠ c ≠ d).

class StuckNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        bool noAnswer = true;
        for (int a = 0; a < n; a++)
        {
            for (int b = 0; b < n; b++)
            {

                for (int c = 0; c < n; c++)
                {
                    for (int d = 0; d < n; d++)
                    {
                        int numA = numbers[a];
                        int numB = numbers[b];
                        int numC = numbers[c];
                        int numD = numbers[d];
                        if (numA != numB && numA != numC && numB != numC && numA != numD && numB != numD && numC != numD)
                        {
                            string firstNumber = "" + numA + numB;
                            string secondNumber = "" + numC + numD;
                            if (firstNumber.Equals(secondNumber))
                            {
                                noAnswer = false;
                                Console.WriteLine("{0}|{1}=={2}|{3}", numA, numB, numC, numD);
                            }
                        }
                    }
                }
            }
        }
        if (noAnswer)
        {
            Console.WriteLine("No");
        }
    }
}
