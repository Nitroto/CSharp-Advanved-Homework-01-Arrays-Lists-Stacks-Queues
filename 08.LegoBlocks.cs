using System;
using System.Globalization;
using System.Linq;
using System.Threading;

/// You are given two jagged arrays.Each array represents a Lego block containing integers. 
/// Your task is first to reverse the second jagged array and then check if it would fit perfectly in the first jagged array. 

class LegoBlocks
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        int[][] firstArray = EnterArray(n);
        int[][] secondArray = EnterArray(n);
        int[][] resultArray = MergeArrays(n, firstArray, secondArray);
        if (CanBeAssembled(firstArray, secondArray))
        {
            PrintMatrix(resultArray);
        }
        else
        {
            PrintCellsCount(resultArray);
        }
    }
    private static void PrintMatrix(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("[");
            for (int j = 0; j<array[i].Length;j++)
            {
                if (j != array[i].Length - 1)
                {
                    Console.Write("{0}, ", array[i][j]);
                }
                else
                {
                    Console.Write("{0}", array[i][j]);
                }
            }
            Console.WriteLine("]");
        }
    }

    private static void PrintCellsCount(int[][] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                count++;
            }
        }
        Console.WriteLine("The total number of cells is: {0}", count);
    }

    private static bool CanBeAssembled(int[][] first, int[][] second)
    {
        int prevElement = first[0].Length + second[0].Length;
        for (int i = 1; i < first.Length; i++)
        {
            int currentElement = first[i].Length + second[i].Length;
            if (prevElement != currentElement)
            {
                return false;
            }
            prevElement = currentElement;
        }
        return true;
    }

    private static int[][] MergeArrays(int n, int[][] first, int[][] second)
    {
        int[][] mergedArray = new int[n][];
        for (int i = 0; i < n; i++)
        {
            Array.Reverse(second[i]);
            string firstMatrix = string.Join(" ", first[i].Select(p => p.ToString()).ToArray());
            string secondMatrix = string.Join(" ", second[i].Select(p => p.ToString()).ToArray());
            string result = firstMatrix + " " + secondMatrix;
            mergedArray[i] = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        }
        return mergedArray;
    }

    private static int[][] EnterArray(int n)
    {
        int[][] jaggedArray = new int[n][];
        for (int i = 0; i < n; i++)
        {
            jaggedArray[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        }
        return jaggedArray;
    }
}
