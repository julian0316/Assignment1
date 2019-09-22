using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Problem 1 : SELF DIVIDING NUMBER
             * Looking for self dividing number among a range of numbers
             */
            Console.WriteLine("--SELF DIVIDING NUMBER--");
            selfDividingNumbers(120, 140);
            Console.WriteLine("--------------------------");
            Console.WriteLine();


            /* Problem 2: PRINT SERIES
             * Print the following series till n terms:
             * * 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6 …. n terms
             */
            Console.WriteLine("--PRINT SERIES--");
            printSeries(5);
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            /* Problem 3 : INVERTED TRIANGLE
             * Print an inverted triangle using *
             */
            Console.WriteLine("--INVERTED TRIANGLE--");
            printTriangle(5);
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            /* Problem 4 :JEWEL IN THE STONE
             * Given the sorted array J representing distinct Jewels and S representing distict S, 
             * objective is to find Jewel in the Stones.
             */
            Console.WriteLine("--JEWEL IN THE STONE--");
            int[] J = { 1, 3 };
            int[] S = { 1, 3, 3, 2, 2, 2, 2, 2 };
            Console.WriteLine("Number of Jewels in the Stones are " + numJewelsInStones(J, S));
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            /* Problem 5 :  LARGEST COMMON SUB ARRAY
             * Objective for the following illustration comprises of finding the largest common sub-array
             * given two arrays.
             */
            Console.WriteLine("--LARGEST COMMON SUB ARRAY--");
            int[] a = { 1, 2, 5, 6, 7, 8, 9 };
            int[] b = { 1, 2, 3, 4, 5 };
            int[] lcsa = getLargestCommonSubArray(a, b);
            foreach (int num in lcsa) Console.Write(num + " ");

            Console.WriteLine("--------------------------");
            Console.WriteLine();

            /* Problem 6 : SOLVE PUZZLE
             * Objective for the follwoing illustration is to solve the alphametic puzzle.
             */
            Console.WriteLine("--SOLVE PUZZLE--");
            Console.WriteLine("Please enter the strings, operator and result in the //string1OPERATORstring2=result // format, where OPERATOR could be '+-/*%' ::");
            Puzzles c = new Puzzles(Console.ReadLine());
            c.solvePuzzle();
            Console.WriteLine("--------------------------");
            Console.WriteLine();
        }

        /*
         * summary      : This method prints all the self-dividing numbers between x and y. 
         * A self-dividing number is a number that is divisible by every digit it contains.
         * 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0 and 128 % 8 == 0
         * For example 1, 22 will print all the self.-dividing numbers between 1 and 22 i.e. 
         * 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22
         */
            public static void selfDividingNumbers(int x, int y)
        {
            try
            {
                Console.WriteLine("Following are the numbers between " + x + " and " + y + " are : ");
                for (int num = x; num < y + 1; num++)
                {
                    bool k = true;
                    int i = num;
                    while (i > 0)
                    {

                        // Taking the digit of the 
                        // number into var 'digit'. 
                        int digit = i % 10;

                        if ((isSelfDividing(i, digit)) == false)
                        {
                            k = false;
                            break;
                        }

                        i /= 10;
                    }
                    if (k is true)
                        Console.WriteLine(num);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        /* Method to check if the number is self dividing
         */
        public static bool isSelfDividing(int num, int digit)
        {
            // If the digit divides the number 
            // then return true else return false. 
            return (digit != 0 && num % digit == 0);
        }


        /*
        * n – number of terms of the series, integer (int)
        * 
        * summary        : This method prints the following series till n terms:
        * 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6 …. n terms
        * For example, if n = 5, output will be
        * 1, 2, 2, 3, 3
        *
        * returns        : N/A
        * return type    : void
        */

        public static void printSeries(int n)
        {
            try
            {
                Console.WriteLine("The output for print series for value n = " + n + " is :");
                int term = n;
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        if (term > 0)
                        {
                            Console.WriteLine(i);
                        }
                        term--;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }



        /*
        * n – number of lines for the pattern, integer (int)
        * 
        * summary      : This method prints an inverted triangle using *
        * For example n = 5 will display the output as: 
        *********
         *******
          *****
           ***
            *

        *
        * returns      : N/A
        * return type  : void
        */
        public static void printTriangle(int n)
        {
            try
            {
                int num = n;
                while (n > 0)
                {
                    int k = 2 * n - 1;
                    for (int i = 0; i < ((2 * num - 1) - k) / 2; i++)
                    {
                        Console.Write(" ");
                    }
                    for (int i = 0; i < k; i++)
                    {
                        Console.Write("*");
                    }
                    n--;
                    Console.Write("\n");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }


        /*
        * a – array of elements, integer (int)
        * 
        * summary      : You're given an array J representing the types of stones that are 
        * jewels, and S representing the stones you have.  Each element in S is a type of 
        * stone you have.  You want to know how many of the stones you have are also jewels.
        * The elements in J are guaranteed distinct.
        * The function should return an integer.
        * For example:
        * J = [1,3], S = [1,3,3,2,2,2,2,2] will return the output: 
        * 3 (since 1, 3, 3 are jewels)
        * and
        * J = [2], S = [0,0] will return the output: 
        * 0
        *
        * returns      : Integer
        * return type  : int
        */
        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                HashSet<int> jewelAndStones = new HashSet<int>();
                foreach (int j in J)
                    jewelAndStones.Add(j);

                int count = 0;
                foreach (int s in S)
                    if (jewelAndStones.Contains(s))
                        count++;

                return count;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }
            return 0;
        }

        /*
        * a – array of elements, integer (int)
        * 
        * summary      : This method finds the largest common contiguous subarray from two 
        * sorted arrays. The given arrays are sorted in ascending order. If there are multiple 
        * arrays with the same length, then return the last array having the maximum length.
        * The function should return the array.
        * For example:
        * a = [1,2,5,6,7,8,9], b = [1,2,3,4,5] will return the output: 
        * [1,2]
        * and
        * a = [1,2,3,4,5,6,7,8,9], b = [1,2,5,7,8,9,10] will return the output: 
        * [7,8,9]
        * and
        * a = [1,2,3,4,5,6], b = [1,2,5,6,7,8,9] will return the output: 
        * [5,6]
        *
        * returns      : Array of integers
        * return type  : int[]
        */
        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            int[,] matrix = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++)
            {
                for (int j = 0; j <= b.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        if (a[i - 1] == b[j - 1])
                        {
                            matrix[i, j] = matrix[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                        }
                    }
                }
            }
            int lengthLCA = matrix[a.Length, b.Length];
            int iCurr = a.Length;
            int jCurr = b.Length;
            List<int> result = new List<int>();
            while (lengthLCA > 0)
            {
                if (a[iCurr - 1] == b[jCurr - 1])
                {
                    result.Insert(0, b[iCurr - 1]);
                    iCurr--;
                    jCurr--;
                    lengthLCA--;
                }
                else
                {
                    if (matrix[iCurr - 1, jCurr] > matrix[iCurr, jCurr - 1])
                    {
                        iCurr--;
                    }
                    else
                    {
                        jCurr--;
                    }
                }
            }
            int[] res = result.ToArray();
            return res;
        }

    }

    internal class Puzzles
    {
        string n1, n2, sum;
        char oper;
        bool invalidString;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        List<char> lettercount = new List<char>();
        Func<int, int, int, bool> calc;

        public Puzzles(string str)
        {
            SetString(str);
            if (!invalidString)
            {
                SetDict(n1);
                SetDict(n2);
                SetDict(sum);
            }
        }

        void SetString(string str)
        {
            str = str.ToUpper().Replace(' ', '\0');
            string[] words = new string[3];
            try
            {
                for (int i = 0, j = 0; i < str.Length; i++)
                {
                    if (char.IsLetter(str[i]))
                    {
                        words[j] += str[i];
                    }
                    else
                    {
                        j++;
                        if (str[i] != '=')
                            SetOperator(str[i]);
                    }
                }
                n1 = words[0];
                n2 = words[1];
                sum = words[2];
            }
            catch
            {
                invalidString = true;
            }
        }

        void SetOperator(char op)
        {
            switch (op)
            {
                case '+':
                    calc = (n1, n2, s) => n1 + n2 == s && dict[sum[0]] != 0;
                    break;
                case '-':
                    calc = (n1, n2, s) => n1 - n2 == s && dict[sum[0]] != 0;
                    break;
                case '*':
                    calc = (n1, n2, s) => n1 * n2 == s && dict[sum[0]] != 0;
                    break;
                case '/':
                    calc = (n1, n2, s) => n2 == 0 ? false : n1 / n2 == s && dict[sum[0]] != 0;
                    break;
                case '^':
                    calc = (n1, n2, s) => Math.Pow(n1, n2) == s && dict[sum[0]] != 0;
                    break;
                case '%':
                    calc = (n1, n2, s) => n2 == 0 ? false : n1 % n2 == s && dict[sum[0]] != 0;
                    break;
                default:
                    throw new Exception("Invalid Input");
            }
            oper = op;
        }



        /*
        * 
        * summary      : At a recent college reunion meeting of one of the instructors of this 
        * class, his friend was wearing the t-shirt shown in the picture above. It was a gift
        * from his niece. Appropriate assignment of numbers to each digit solves the puzzle 
        * above. In this question, write a general method to solve puzzles such as the above.
        * The method should ask the user for the two input strings (e.g. uber, cool) and the 
        * output string (e.g. uncle) and identify a set of number assignments that solve the 
        * puzzle and print out the numbers.
        *
        * Tip: There is no need to search for algorithms. It is fine to brute force all 
        * possible combinations. However, for full credit, use maximal organization of your
        * code into the appropriate methods (e.g. a method to collect inputs, a method to
        * identify unique characters in the strings, a method to test the currently assigned
        * values etc).
        *
        * returns      : nothing
        * return type  : void
        */

        public void solvePuzzle()
        {
            if (dict.Count > 10 || invalidString || calc == null)
                throw new Exception("Invalid String");
            HashSet<int> set = new HashSet<int>();
            if (Solve(0, set))
            {
                PrintResult();
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        bool Solve(int idx, HashSet<int> set)
        {
            bool found = false;
            if (idx == dict.Count)
            {
                return Verify();
            }
            char ch = lettercount[idx];
            for (int n = 0; n < 10; n++)
            {
                if (!set.Contains(n) && dict[ch] == -1)
                {
                    dict[ch] = n;
                    set.Add(n);
                    found = Solve(idx + 1, set);
                    if (!found)
                    {
                        set.Remove(n);
                        dict[ch] = -1;
                    }
                    else return found;
                }
            }
            return false;
        }

        void SetDict(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!dict.ContainsKey(str[i]))
                {
                    dict.Add(str[i], -1);
                    lettercount.Add(str[i]);
                }
            }
        }

        bool Verify()
        {
            int n1 = GetNum(this.n1);
            int n2 = GetNum(this.n2);
            int sum = GetNum(this.sum);
            return calc(n1, n2, sum);
        }

        int GetNum(string str)
        {
            int pow = 1;
            int res = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                res += dict[str[i]] * pow;
                pow *= 10;
            }
            return res;
        }

        void PrintResult()
        {
            PrintString(n1);
            Console.WriteLine(oper);
            PrintString(n2);
            Console.WriteLine("=");
            PrintString(sum);
        }

        void PrintString(string str)
        {
            string res = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                res += dict[str[i]];
            }
            Console.WriteLine(str);
            Console.WriteLine(res);
        }
    }

}

