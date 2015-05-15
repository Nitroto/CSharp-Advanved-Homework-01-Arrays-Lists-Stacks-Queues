using System;
using System.Globalization;
using System.Threading;

/// George likes math. Recently he discovered an interesting property of the Pythagorean Theorem: 
/// there are infinite number of triplets of integers a, b and c (a ≤ b), such that a^2 + b^2 = c^2. 
/// Write a program to help George find all such triplets (called Pythagorean numbers) among a set of integer numbers.

class PythagoreanNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        bool noAnswer = true;
        for (int a = 0; a < numbers.Length; a++)
        {
            for (int b = 0; b < numbers.Length; b++)
            {
                if (numbers[a] <= numbers[b])
                {
                    for (int c = 0; c < numbers.Length; c++)
                    {
                        if (((numbers[a] * numbers[a]) + (numbers[b] * numbers[b])) == (numbers[c] * numbers[c]))
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", numbers[a], numbers[b], numbers[c]);
                            noAnswer = false;
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
