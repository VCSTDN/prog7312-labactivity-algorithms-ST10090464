using System;
using System;
            using System.Collections.Generic;
namespace Prog_Ice3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //a)Create a recursive method which prints all subsets of a given set of N words.
            //Example input: words = {“Code”, “Sleep”, “Repeat”}
            //Example output: (Code), (Sleep), (Repeat), (Code Sleep), (Code Repeat),(Repeat Sleep), (Code Sleep Repeat) 
            // recursive string processing function
                     
            string[] words = { "Nigga", "Black", "African" };
            PrintSubsets(words);
            
            static void PrintSubsets(string[] words)
            {
                List<string> subset = new List<string>();
                GenerateSubsets(words, subset, 0);
            }

            static void GenerateSubsets(string[] words, List<string> subset, int index)
            {
                if (index == words.Length)
                {
                    // Print the current subset
                    Console.Write("(");
                    for (int i = 0; i < subset.Count; i++)
                    {
                        Console.Write(subset[i]);
                        if (i < subset.Count - 1)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.Write(")");
                    Console.WriteLine();
                    return;
                }

                // Exclude the current word
                GenerateSubsets(words, subset, index + 1);

                // Include the current word
                subset.Add(words[index]);
                GenerateSubsets(words, subset, index + 1);

                // Backtrack
                subset.RemoveAt(subset.Count - 1);
            }
        }      
    }


    //b)Create a method that will removes all negative numbers from an array of elements, then return a new array of elements.
    //Example: array = { 19, -10, 12, -6, -3, 34, -2, 5} New array = { 19, 12, 34, 5 }
    class RemoveNegatives
    {
        static void Main()
        {
            int[] array = { 19, -10, 12, -6, -3, 34, -2, 5 };
            int[] newArray = RemoveNegativeNumbers(array);

            Console.WriteLine("Original array: " + string.Join(", ", array));
            Console.WriteLine("New array: " + string.Join(", ", newArray));
        }

        static int[] RemoveNegativeNumbers(int[] array)
        {
            List<int> positiveNumbers = new List<int>();

            foreach (int number in array)
            {
                if (number >= 0)
                {
                    positiveNumbers.Add(number);
                }
            }

            return positiveNumbers.ToArray();
        }
    }
    //c)Create a method that will store 15 random numbers(in the range [0…10]) and display how many times each of the elements occurs. 
    //Example: array = { 3, 4, 4, 2, 3, 3, 4, 3, 2,4,4,3,2,4,3}
    //Output:2 => 3 time
    //3 => 6 times
    //4 => 6 times
class RandomNumberCounter
    {
        static void Main()
        {
            int[] array = GenerateRandomNumbers(15, 0, 10);
            CountAndDisplayOccurrences(array);
        }

        static int[] GenerateRandomNumbers(int count, int min, int max)
        {
            Random rand = new Random();
            int[] randomNumbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                randomNumbers[i] = rand.Next(min, max + 1); // Generate a random number in [min, max] range
            }

            return randomNumbers;
        }

        static void CountAndDisplayOccurrences(int[] array)
        {
            Dictionary<int, int> occurrences = new Dictionary<int, int>();

            foreach (int number in array)
            {
                if (occurrences.ContainsKey(number))
                {
                    occurrences[number]++;
                }
                else
                {
                    occurrences[number] = 1;
                }
            }

            foreach (var kvp in occurrences)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value} times");
            }
        }
    }

    //d)	Create a method that will generate random numbers between 10 and 25.
    //The method should generate 8 unique(no duplicates) numbers for both odd and even numbers.
    //Store odd and even numbers on separate lists, the method should return the two lists.
 

class RandomNumberGenerator
    {
        static void Main()
        {
            Tuple<List<int>, List<int>> result = GenerateUniqueEvenAndOddNumbers(10, 25, 8);
            List<int> evenNumbers = result.Item1;
            List<int> oddNumbers = result.Item2;

            Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));
            Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));
        }

        static Tuple<List<int>, List<int>> GenerateUniqueEvenAndOddNumbers(int min, int max, int count)
        {
            Random rand = new Random();
            HashSet<int> uniqueEvenNumbers = new HashSet<int>();
            HashSet<int> uniqueOddNumbers = new HashSet<int>();

            while (uniqueEvenNumbers.Count < count || uniqueOddNumbers.Count < count)
            {
                int randomNumber = rand.Next(min, max + 1);

                if (randomNumber % 2 == 0 && uniqueEvenNumbers.Count < count)
                {
                    uniqueEvenNumbers.Add(randomNumber);
                }
                else if (randomNumber % 2 != 0 && uniqueOddNumbers.Count < count)
                {
                    uniqueOddNumbers.Add(randomNumber);
                }
            }

            return new Tuple<List<int>, List<int>>(new List<int>(uniqueEvenNumbers), new List<int>(uniqueOddNumbers));
        }
    }

}
