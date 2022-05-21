using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace N_Puzzel_Project
{
    struct Movements
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
    }

    class Puzzel
    {
        public int[,] puzzel_2D_array;
        public int puzzel_size, blank_space_i, blank_space_j, hamming_value, manhattan_value, cost, number_of_level; //number of moves tree level
        public String direction_of_moves , key="";
        public Puzzel parent;
        public Movements mov;

        //*****************************************************************************************
        public Puzzel(int size, int[,] puzzel , int blank_i , int blank_j)//O(N^2)
        {
            puzzel_2D_array = puzzel; //o(1)
            puzzel_size = size; //o(1)
            blank_space_i = blank_i; //o(1)
            blank_space_j = blank_j; //o(1)
            direction_of_moves = "Start"; //o(1)
            Hamming(); //o(n)
            manhattan(); //o(n)
            number_of_level = 0; //o(1)
            parent = null; //o(1)

            for (int x = 0; x < puzzel_size * puzzel_size; x++)//O(N^2)
            {
                int i = x / puzzel_size; //o(1)
                int j = x % puzzel_size; //o(1)
                puzzel_2D_array[i, j] = puzzel[i, j]; //o(1)
                key += puzzel[i, j];  //o(1)
            }
        }
       
        //*****************************************************************************************

        public Puzzel(Puzzel p, int x)//O(N^2)
        {
            puzzel_size = p.puzzel_size; //o(1)
            puzzel_2D_array = new int[puzzel_size, puzzel_size]; //o(1)
            blank_space_i = p.blank_space_i; //o(1)
            blank_space_j = p.blank_space_j; //o(1)
            number_of_level = p.number_of_level; //o(1)
            parent = p; //o(1)
            cost = p.cost; //o(1)
            key = p.key; //o(1)
            hamming_value = p.hamming_value; //o(1)
            manhattan_value = p.manhattan_value; //o(1)

            for (int y = 0; y < puzzel_size * puzzel_size; y++)//O(N^2)
            {
                int i = y / puzzel_size; //o(1)
                int j = y % puzzel_size; //o(1)
                puzzel_2D_array[i, j] = p.puzzel_2D_array[i, j]; //o(1)

            }
        }

        //***************copy constructor**************************************************************************
        public Puzzel(Puzzel p) //o(n^2)
        {
            puzzel_size = p.puzzel_size; //o(1)
            puzzel_2D_array = new int[puzzel_size, puzzel_size]; //o(1)
            blank_space_i = p.blank_space_i; //o(1)
            blank_space_j = p.blank_space_j; //o(1)
            number_of_level = p.number_of_level + 1; //o(1)
            parent = p.parent;

            for (int x = 0; x < puzzel_size * puzzel_size; x++)//O(N^2)
            {
                int i = x / puzzel_size; //o(1)
                int j = x % puzzel_size; //o(1)
                puzzel_2D_array[i, j] = p.puzzel_2D_array[i, j]; //o(1)
            }
         }

        //*****************************************************************************************
        public void Hamming()//O(N)
        {
            /* ex
             * ==> 1  2  3  4  5  6  7  8 
             * ==> 1  1  0  0  1  1  0  0
             * hamming_value = 4;
             */
            int miss_position = 0; // number of blocks out of place
            int correct_position = 1; // position correct number allocation
            int i = 0, j = 0;
            while (i < puzzel_size)//O(N)
            {
                if (i != puzzel_size - 1 && j != puzzel_size - 1)
                {
                    key += this.puzzel_2D_array[i, j];
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0) //blank space
                    {
                        miss_position++;
                    }
                    correct_position++;
                    j++;
                }
                else if (i != puzzel_size - 1 && j == puzzel_size - 1)
                {
                    key += this.puzzel_2D_array[i, j];
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0) //blank space
                    {
                        miss_position++;
                    }
                    correct_position++;
                    j = 0;
                    i++;
                }
                else if (i == puzzel_size - 1 && j != puzzel_size - 1)
                {
                    key += this.puzzel_2D_array[i, j];
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0) //blank space
                    {
                        miss_position++;
                    }
                    correct_position++;
                    j++;
                }
                else
                {
                    key += this.puzzel_2D_array[i, j];
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0) //blank space
                    {
                        miss_position++;
                    }
                    correct_position++;
                    hamming_value = miss_position;
                    break;
                }
            }
        }

        //*****************************************************************************************

        public void manhattan()//O(N)
        {
            int i = 0, j = 0, cnt = 0, RES = 0;
            while (i < puzzel_size)//O(N)
            {
                if (i != puzzel_size - 1 && j != puzzel_size - 1)
                {
                    this.key += this.puzzel_2D_array[i, j];
                    int val = this.puzzel_2D_array[i, j];
                    RES++;
                    if (val != 0 && val != RES)
                    {
                        int temp1 = ((val - 1) / puzzel_size);
                        int temp2 = ((val - 1) % puzzel_size);
                        cnt += Math.Abs(i - temp1) + Math.Abs(j - temp2);
                    }
                    j++;
                }
                else if (i != puzzel_size - 1 && j == puzzel_size - 1)
                {
                    this.key += this.puzzel_2D_array[i, j];
                    int val = this.puzzel_2D_array[i, j];
                    RES++;
                    if (val != 0 && val != RES)
                    {
                        int temp1 = ((val - 1) / puzzel_size);
                        int temp2 = ((val - 1) % puzzel_size);
                        cnt += Math.Abs(i - temp1) + Math.Abs(j - temp2);
                    }
                    j = 0;
                    i++;
                }
                else if (i == puzzel_size - 1 && j != puzzel_size - 1)
                {
                    this.key += this.puzzel_2D_array[i, j];
                    int val = this.puzzel_2D_array[i, j];
                    RES++;
                    if (val != 0 && val != RES)
                    {
                        int temp1 = ((val - 1) / puzzel_size);
                        int temp2 = ((val - 1) % puzzel_size);
                        cnt += Math.Abs(i - temp1) + Math.Abs(j - temp2);
                    }
                    j++;
                }
                else
                {
                    this.key += this.puzzel_2D_array[i, j];
                    int val = this.puzzel_2D_array[i, j];
                    RES++;
                    if (val != 0 && val != RES)
                    {
                        int temp1 = ((val - 1) / puzzel_size);
                        int temp2 = ((val - 1) % puzzel_size);
                        cnt += Math.Abs(i - temp1) + Math.Abs(j - temp2);
                    }
                    manhattan_value = cnt;
                    break;
                }
            }
        }

        //*****************************************************************************************

        public void Calculate_cost_of_hamming()//O(1)
        { 
            // f(n) = g(n) + h(n)
            cost = number_of_level + hamming_value;
        }
        public void Calculate_cost_Manhattan()//O(1)
        {
            /*f(n) = g(n) + h(n)*/
            cost = number_of_level + manhattan_value;
        }

        //*****************************************************************************************

        public bool IS_reache_to_goal_hamming()//O(1)
        {
            // f(n) = g(n) + 0
            if (hamming_value == 0)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }
        public bool IS_reache_to_goal_manhattan()//O(1)
        {
            // f(n) = g(n) + 0
            if (manhattan_value == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*********************************************Movement**********************************************/
        /*  j/i | 0  1  2
         *  ----|----------
         *   0  | 4  1  3
         *   1  | 0  2  5
         *   2  | 7  8  6
         */
        public int UP_movement() //O(1)
        {           
            int swap_part = puzzel_2D_array[blank_space_i - 1, blank_space_j];
            puzzel_2D_array[blank_space_i,blank_space_j] = swap_part;
            swap_part = 0;
            puzzel_2D_array[blank_space_i - 1, blank_space_j] = swap_part;
            // To know where blank space is it 
            blank_space_i = blank_space_i - 1;
            return puzzel_2D_array[blank_space_i, blank_space_j];
        }

        public int Down_movement()//O(1)
        {
            int swap_part = puzzel_2D_array[blank_space_i + 1, blank_space_j];
            puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;
            swap_part = 0;  //position = 0 
            puzzel_2D_array[blank_space_i + 1, blank_space_j] = swap_part;
            // To know where blank space is it 
            blank_space_i = blank_space_i + 1;
            return puzzel_2D_array[blank_space_i, blank_space_j];

        }
       
        public int Left_movement()//O(1)
        {
            int swap_part = puzzel_2D_array[blank_space_i, blank_space_j - 1];
            puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;
            swap_part = 0; //position = 0 
            puzzel_2D_array[blank_space_i, blank_space_j - 1] = swap_part;
            // To know where blank space is it 
            blank_space_j = blank_space_j - 1;
            return puzzel_2D_array[blank_space_i, blank_space_j];
        }
       
        public int Right_movement()//O(1)
        {
            int swap_part = puzzel_2D_array[blank_space_i, blank_space_j + 1];
            puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;
            swap_part = 0; //position = 0 
            puzzel_2D_array[blank_space_i, blank_space_j + 1] = swap_part;
            // To know where blank space is it 
            blank_space_j = blank_space_j + 1;
            return puzzel_2D_array[blank_space_i, blank_space_j];
        }


        public bool check_Movement_value(int u, int d, int l, int r)//O(N)
        {
            if (u == 1)
            {
                if (blank_space_i != 0)
                {
                    mov.up = true;//O(N)
                }
                return mov.up;//O(N)
            }
            if (d == 1)
            {
                if (blank_space_i != puzzel_size - 1)
                {
                    mov.down = true;//O(N)
                }
                return mov.down;//O(N)
            }
            if (l == 1)
            {
                if (blank_space_j != 0)
                {
                    mov.left = true;//O(N)
                }
                return mov.left;//O(N)
            }
            if (r == 1)
            {
                if (blank_space_j != puzzel_size - 1)
                {
                    mov.right = true;//O(N)
                }
                return mov.right;//O(N)
            }
            else
                return false;
        }

        /*********************************************End of movement********************************************/

        public void Display()//O(N)
        {
            int i = 0, j = 0, cn = 0;
            while (i < puzzel_size)//O(N)
            {
                if (cn == i && cn % puzzel_size == 0)
                {
                    Console.WriteLine(" ---> " + direction_of_moves);
                    cn++;
                }
                if (i != puzzel_size - 1 && j != puzzel_size - 1)
                {
                    Console.Write(puzzel_2D_array[i, j]);
                    Console.Write(" ");
                    j++;
                }
                else if (i != puzzel_size - 1 && j == puzzel_size - 1)
                {
                    Console.Write(puzzel_2D_array[i, j]);
                    Console.WriteLine();
                    j = 0;
                    i++;
                }
                else if (i == puzzel_size - 1 && j != puzzel_size - 1)
                {
                    Console.Write(puzzel_2D_array[i, j]);
                    Console.Write(" ");
                    j++;
                }
                else
                {
                    Console.Write(puzzel_2D_array[i, j]);
                    Console.WriteLine("\n");
                    break;
                }
            }
        }

    }

}

