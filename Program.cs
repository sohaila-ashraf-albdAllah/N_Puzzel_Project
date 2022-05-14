using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace N_Puzzel_Project
{
    class Program
    {
        static int indexn0, indexi0;
        static string choice;
        static FileStream choosefile()
        {
            FileStream d;
            bool here = false;
            Console.WriteLine("Is it A kind of model\n" + "a-simple\n" + "b-complete\n" + "Enter your choice A or B: ");
        HERE:

            string choice = Console.ReadLine();
            if (choice == "a" || choice == "A")
            {
                Console.WriteLine("Is it A kind of text\n" + "1-8 Puzzle (1)\n" + "2-8 Puzzle - Case 1\n" + "3-8 Puzzle (2)\n" + "4-8 Puzzle (3)\n" + "5-8 Puzzle(2) - Case 1\n" + "6-8 Puzzle(3) - Case 1\n" + "7-15 Puzzle - 1\n" + "8-24 Puzzle 1\n" + "9-15 Puzzle - Case 2\n" + "10-15 Puzzle - Case 3\n" + "11-24 Puzzle 2\n");
                string txt = Console.ReadLine();
                if (txt == "1") return d = new FileStream("8 Puzzle (1).txt", FileMode.Open, FileAccess.Read);
                else if (txt == "2") return d = new FileStream("8 Puzzle - Case 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "3") return d = new FileStream("8 Puzzle (2).txt", FileMode.Open, FileAccess.Read);
                else if (txt == "4") return d = new FileStream("8 Puzzle (3).txt", FileMode.Open, FileAccess.Read);
                else if (txt == "5") return d = new FileStream("8 Puzzle(2) - Case 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "6") return d = new FileStream("8 Puzzle(3) - Case 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "7") return d = new FileStream("15 Puzzle - 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "8") return d = new FileStream("24 Puzzle 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "9") return d = new FileStream("15 Puzzle - Case 2.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "10") return d = new FileStream("15 Puzzle - Case 3.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "11") return d = new FileStream("24 Puzzle 2.txt", FileMode.Open, FileAccess.Read);
                else Console.WriteLine("invalid source\n" + "press a or b to choose again\n");
            }
            else if (choice == "b" || choice == "B")
            {
                Console.WriteLine("Is it A kind of text\n" + "1-50 Puzzle\n" + "2-99 Puzzle - 1\n" + "3-99 Puzzle - 2\n" + "4-9999 Puzzle\n" + "5-15 Puzzle 1\n" + "6-15 Puzzle 3\n" + "7-15 Puzzle 4\n" + "8-15 Puzzle 5\n" + "9-15 Puzzle 1 - Unsolvable\n" + "10-99 Puzzle - Unsolvable Case 1\n" + "11-99 Puzzle - Unsolvable Case 2\n" + "12-9999 Puzzle  - Unsolvable case\n" + "13-TEST\n");
                string txt = Console.ReadLine();
                if (txt == "1") return d = new FileStream("50 Puzzle.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "2") return d = new FileStream("99 Puzzle - 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "3") return d = new FileStream("99 Puzzle - 2.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "4") return d = new FileStream("9999 Puzzle.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "5") return d = new FileStream("15 Puzzle 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "6") return d = new FileStream("15 Puzzle 3.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "7") return d = new FileStream("15 Puzzle 4.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "8") return d = new FileStream("15 Puzzle 5.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "9") return d = new FileStream("15 Puzzle 1 - Unsolvable.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "10") return d = new FileStream("99 Puzzle - Unsolvable Case 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "11") return d = new FileStream("99 Puzzle - Unsolvable Case 2.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "12") return d = new FileStream("9999 Puzzle  - Unsolvable case.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "13") return d = new FileStream("TEST.txt", FileMode.Open, FileAccess.Read);
                else Console.WriteLine("invalid source\n" + "press a or b to choose again\n");
            }
            else
            {
                Console.WriteLine("invalid source\n" + "press a or b to choose again\n");
            }
            here = true;
            goto HERE;
        }
        static int getnumberofversion(int N, int[] arr2)
        {
            int num_of_version = 0;
            for (int i = 0; i < N * N - 1; i++)
                for (int j = i + 1; j < N * N; j++)
                    if (arr2[j] != 0 && arr2[i] != 0 && arr2[i] > arr2[j])
                        num_of_version++;
            return num_of_version;
        }
        static bool isSolvable(int N, int[] puzzle)
        {
            bool num = false;
            int num_of_Inversions = getnumberofversion(N, puzzle);
            //number odd and version even
            if (N % 2 != 0 && num_of_Inversions % 2 == 0)
                num = true;
            //number even
            //1-version odd w blank even
            //2-version even w blank odd
            else if (N % 2 == 0)
            {
                if (num_of_Inversions % 2 != 0 && (N - indexn0 + 2) % 2 == 0)
                    num = true;
                else if (num_of_Inversions % 2 == 0 && (N - indexn0 + 2) % 2 != 0)
                    num = true;
            }
            else
                num = false;
            if (num)
                Console.WriteLine("This puzzel is Solvable");
            else
                Console.WriteLine("This puzzel  is Nan_Solvable");
            return num;
        }
        static void Main(string[] args)
        {
              min:
            FileStream file_puzzle = choosefile();
            StreamReader sr = new StreamReader(file_puzzle);
            string[] vertices = sr.ReadLine().Split(' ');
            int cases = int.Parse(vertices[0]);
            sr.ReadLine();
            int[,] arr = new int[cases, cases];
            int[] arr2 = new int[cases * cases];
            int n = 0, counter = 0;
            while (n < cases)
            {
                string[] only_line = sr.ReadLine().Split(' ');
                int i = 0;
                while (i < cases)
                {
                    arr2[counter] = int.Parse(only_line[i]);
                    arr[n, i] = int.Parse(only_line[i]);
                    if (int.Parse(only_line[i]) == 0)
                    {
                        indexn0 = n;
                        indexi0 = i;
                    }
                    i++;
                    counter++;
                }
                n++;
            }
            if (isSolvable(cases, arr2) )
            {
                Console.WriteLine("Is it A kind of model\n" + "[1]Hamming\n" + "[2]Manhattan\n" + "[3]Hamming and manhattan\n"+ "Enter your choice 1 or 2 or 3: ");
                char choose = (char)Console.ReadLine()[0];
                if (choose == '1')
                {

                }
                else if (choose == '2')
                {
                    Console.WriteLine("  -----------------------------------  ");
                    Puzzel First = new Puzzel(cases, arr, indexi0, indexn0);
                    Manhattan A = new Manhattan();
                    A.A__Algorithm(First);

                }
                else if(choose == '3'){

                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
            }
            Console.Write("Do you want to run any test again now (y/n)? ");
            char ch = (char)Console.Read();
            if (ch == 'y' || ch == 'Y')
                goto min;

        }
    }
}
