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
        public static int x, y = 0;
        static FileStream choosefile()
        {           
        FileStream d;
            Console.WriteLine("________________________________________");
            Console.WriteLine("|\tIs it A kind of model\t\t|\n"
                + "|\t[a]Simple \t\t\t|\n" + "|\t[b]Complete \t\t\t|\n" + "|\t( Enter your choice A or B )\t|");
            Console.WriteLine("________________________________________");
            HERE:
            Console.Write(" ====> ");
            string choice = Console.ReadLine();
            if (choice == "a" || choice == "A")
            {
                Console.WriteLine("________________________________________");
                Console.WriteLine("|\tIs it A kind of text\t\t|\n" 
                    + "|\t1-8 Puzzle (1)\t\t\t|\n" + "|\t2-8 Puzzle - Case 1\t\t|\n" + "|\t3-8 Puzzle (2)\t\t\t|\n"
                    + "|\t4-8 Puzzle (3)\t\t\t|\n" + "|\t5-8 Puzzle(2) - Case 1\t\t|\n" + "|\t6-8 Puzzle(3) - Case 1\t\t|\n"
                    + "|\t7-15 Puzzle - 1\t\t\t|\n" + "|\t8-24 Puzzle 1\t\t\t|\n" + "|\t9-15 Puzzle - Case 2\t\t|\n" + "|\t10-15 Puzzle - Case 3\t\t|\n"
                    + "|\t11-24 Puzzle 2\t\t\t|");
                Console.WriteLine("________________________________________");
                Console.Write(" ====> ");
                string txt = Console.ReadLine();
                if (txt == "1") return d = new FileStream("Testcases/Sample/Solvable Puzzles/8 Puzzle (1).txt", FileMode.Open, FileAccess.Read);
                else if (txt == "2") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/8 Puzzle - Case 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "3") return d = new FileStream("Testcases/Sample/solvable Puzzles/8 Puzzle (2).txt", FileMode.Open, FileAccess.Read);
                else if (txt == "4") return d = new FileStream("Testcases/Sample/Solvable Puzzles/8 Puzzle (3).txt", FileMode.Open, FileAccess.Read);
                else if (txt == "5") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/8 Puzzle(2) - Case 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "6") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/8 Puzzle(3) - Case 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "7") return d = new FileStream("Testcases/Sample/Solvable Puzzles/15 Puzzle - 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "8") return d = new FileStream("Testcases/Sample/Solvable Puzzles/24 Puzzle 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "9") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/15 Puzzle - Case 2.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "10") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/15 Puzzle - Case 3.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "11") return d = new FileStream("Testcases/Sample/Solvable Puzzles/24 Puzzle 2.txt", FileMode.Open, FileAccess.Read);
                else Console.WriteLine("invalid source\n" + "press a or b to choose again\n");
            }
            else if (choice == "b" || choice == "B")
            {
                Console.WriteLine("________________________________________");
                Console.WriteLine("|\tIs it A kind of text\t\t|\n" + "|\t1-50 Puzzle\t\t\t|\n" + "|\t2-99 Puzzle - 1\t\t\t|\n"
                    + "|\t3-99 Puzzle - 2\t\t\t|\n" + "|\t4-9999 Puzzle\t\t\t|\n" + "|\t5-15 Puzzle 1\t\t\t|\n" + "|\t6-15 Puzzle 3\t\t\t|\n"
                    + "|\t7-15 Puzzle 4\t\t\t|\n" + "|\t8-15 Puzzle 5\t\t\t|\n" + "|\t9-15 Puzzle 1 - Unsolvable\t|\n"
                    + "|\t10-99 Puzzle - Unsolvable Case 1|\n" + "|\t11-99 Puzzle - Unsolvable Case 2|\n"
                    + "|\t12-9999 Puzzle - Unsolvable case|\n" + "|\t13-TEST\t\t\t\t|");
                Console.WriteLine("________________________________________");
                Console.Write(" ====> ");
                string txt = Console.ReadLine();
                if (txt == "1") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan & Hamming/50 Puzzle.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "2") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan & Hamming/99 Puzzle - 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "3") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan & Hamming/99 Puzzle - 2.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "4") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan & Hamming/9999 Puzzle.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "5") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan Only/15 Puzzle 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "6") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan Only/15 Puzzle 3.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "7") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan Only/15 Puzzle 4.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "8") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan Only/15 Puzzle 5.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "9") return d = new FileStream("Testcases/Complete/Unsolvable puzzles/15 Puzzle 1 - Unsolvable.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "10") return d = new FileStream("Testcases/Complete/Unsolvable puzzles/99 Puzzle - Unsolvable Case 1.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "11") return d = new FileStream("Testcases/Complete/Unsolvable puzzles/99 Puzzle - Unsolvable Case 2.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "12") return d = new FileStream("Testcases/Complete/Unsolvable puzzles/9999 Puzzle.txt", FileMode.Open, FileAccess.Read);
                else if (txt == "13") return d = new FileStream("TEST.txt", FileMode.Open, FileAccess.Read);
                else Console.WriteLine("invalid source\n" + "press a or b to choose again\n");
            }
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
            FileStream file_puzzle = choosefile();
            StreamReader sr = new StreamReader(file_puzzle);
            string[] vertices = sr.ReadLine().Split(' ');
            int cases = int.Parse(vertices[0]);
            int[,] arr = new int[cases, cases];
            int[] arr2 = new int[cases * cases];
            int n = 0, counter = 0;
            while (n < cases)
            {
                String line = sr.ReadLine();
                if (line == "")
                    continue;
                string[] only_line = line.Split(' ');
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
            Console.WriteLine("________________________________________");
            Console.WriteLine("|\tIs it A kind of model\t\t|\n" + "|\t[1] Hamming\t\t\t|\n"
                + "|\t[2] Manhattan\t\t\t|\n" + "|\t[3] Hamming &Manhattan\t\t|\n"
                + "|\t( Enter your choice 1 or 2 )\t|");
            Console.WriteLine("________________________________________");
            Console.Write(" ====> ");
            string choose = Console.ReadLine();
            int x, y = 0;
            //x = Environment.TickCount;
            if (choose == "1")
            {
                {
                    Stopwatch t = new Stopwatch();
                    t.Start();
                    // Check If Board Is Solvable Or Not 
                    if (isSolvable(cases, arr2))
                    {
                        Puzzel start = new Puzzel(cases, arr, indexn0, indexi0);
                        Hamming A = new Hamming();
                        A.A_Star_Algorithm_wiht_hamming(start);
                        // A.Display_();
                        t.Stop();
                        var s = t.Elapsed;
                        Console.WriteLine();
                        Console.WriteLine("Time Taken In S : " + ((s)));
                    }
                }
            }
            else if (choose == "2")
            {
                Stopwatch t = new Stopwatch();
                t.Start();
                // Check If Board Is Solvable Or Not 
                if (isSolvable(cases, arr2))
                {
                    Puzzel start = new Puzzel(cases, arr, indexn0, indexi0);
                    Manhattan A = new Manhattan();
                    A.A__Algorithm(start);
                    // A.Display_path();
                    var s = t.Elapsed;
                    Console.WriteLine();
                    Console.WriteLine("Time Taken In S : " + ((s)));
                    t.Stop();
                }
            }
            else if (choose == "3")
            {
                Stopwatch t = new Stopwatch();
                t.Start();
                if (isSolvable(cases, arr2))
                {
                    Puzzel start = new Puzzel(cases, arr, indexn0, indexi0);
                    Console.WriteLine("------MANHATTAN------");
                    Manhattan M = new Manhattan();
                    M.A__Algorithm(start);
                   // M.Display_path();
                    Console.WriteLine();
                    Hamming A = new Hamming();
                    Console.WriteLine("------HAMMING------");
                    A.A_Star_Algorithm_wiht_hamming(start);
                    // A.Display_();
                    var s = t.Elapsed;
                    Console.WriteLine();
                    Console.WriteLine("Time Taken In S : " + ((s)));
                    t.Stop();
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine(" No Feasible Solution For The Given Board ");
            //y = Environment.TickCount;
            Console.WriteLine();
            Console.Write("----------------------------------------");
            timer.Stop();

        }
    }
}
 