using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, Please enter the question you want to solve");
            Console.WriteLine("Question 1: Test if the interval between a number and the next is constant in an array");
            Console.WriteLine("Question 2: Get the absolute difference D from an ordered list of integers");
            Console.WriteLine("Question 3: Compute how many times a letter occurs in the string");
            int question = int.Parse(Console.ReadLine());
            if (question == 1)
            {
                Console.WriteLine("Enter the parameter below");
                Console.WriteLine("Enter the array elements seperated by -");
                Console.WriteLine("Example 1-2-3");
                Console.WriteLine("--------------------------");
                Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvv");

               
                string num = Console.ReadLine();
                string[] a = num.Split('-');
                int[] myInts = Array.ConvertAll(a, s => int.Parse(s));
                Console.Write("The output is: ");
                Console.WriteLine(testforSmilarDifference(myInts));
                Console.ReadKey();
            }
            else if(question == 2)
            {
                Console.WriteLine("Enter the following parameters below");
                Console.WriteLine("Enter the size of the array");

                int arrSize = int.Parse(Console.ReadLine());
                int[] intArr = new int[arrSize];

                Console.WriteLine("Enter the values of the array");
                Console.WriteLine("Hit enter after every input");

                for (int i = 0; i < intArr.Length; i++)
                {
                    intArr[i] = int.Parse(Console.ReadLine());

                }

                Console.WriteLine("Enter the value of K");

                int k = int.Parse(Console.ReadLine());
                int output;
                var inputList = intArr.ToList();
                List<int> newList = performOperation(intArr.ToList());

                List<int> result = newList.Except(intArr.ToList()).ToList();
                if (k > result.Count)
                {
                    output = -1;
                }
                else
                {
                    result = result.OrderBy(a => a).ToList();
                    output = result[k];
                }

                Console.Write("The output is: ");
                Console.WriteLine(output);
                Console.ReadLine();
            }
            else if (question == 3)
            {

                Console.WriteLine("Enter the parameter below");
                Console.WriteLine("Enter the word");
                Console.WriteLine("--------------------------");
                Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvv");
                Console.WriteLine("Example: lawrence");
                string str = Console.ReadLine();
                printCharWithFreq(str);
                Console.ReadKey();
            }
        }

        // function to compute how many times a letter occurs in the stringCompute how many times a letter occurs in the string
        static void printCharWithFreq(String str)
        {
            int SIZE = 26;
            // size of the string 'str' 
            int n = str.Length;
             
            int[] freq = new int[SIZE]; 

            for (int i = 0; i < n; i++)
                freq[str[i] - 'a']++;
             
            for (int i = 0; i < n; i++)
            { 
                if (freq[str[i] - 'a'] != 0)
                {
                    Console.Write(str[i]);
                    Console.Write(freq[str[i] - 'a'] + " ");

                    freq[str[i] - 'a'] = 0;
                }
            }
        }

        //function to test if the interval between a number and the next is constant in an array
        static bool testforSmilarDifference(int[] numbers)
        {
            int k = 0, subAns = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (i == 0)
                {
                    k = differenceCalc(numbers[i], numbers[i + 1]);
                }
                else
                {
                    subAns = differenceCalc(numbers[i], numbers[i + 1]);
                    if (k != subAns)
                        return false;
                }
            }

            return true;

        }
        static int differenceCalc(int a, int b)
        {
            int ans = Math.Abs(a - b);
            return ans;
        }

        //function to get  the absolute difference D from an ordered list of integers
        private static List<int> performOperation(List<int> intList)
        {
            for (int i = 0; i < intList.Count; i++)
            {
                int currentElem = intList[i];
                for (int j = i + 1; j < intList.Count; j++)
                {
                    int absDiff = Math.Abs(currentElem - intList[j]);
                    if (!intList.Contains(absDiff))
                    {
                        intList.Add(absDiff);
                    }
                }
            }
            return intList;
        }

    }
}
