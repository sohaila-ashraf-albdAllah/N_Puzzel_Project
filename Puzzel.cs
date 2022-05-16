using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace N_Puzzel_Project
{
    struct Movements
    {
        public bool left;
        public bool right;
        public bool up;
        public bool down;
    }

    class Puzzel
    {
        public int[,] puzzel_2D_array;
        public int puzzel_size, blank_space_i, blank_space_j, hamming_value, manhattan_value, cost, number_of_level; //number of moves tree level
        public String direction_of_moves , key="";
        public Puzzel parent;
        public Movements mov;
        
        //*****************************************************************************************
        public Puzzel(int size, int[,] puzzel , int blank_i , int blank_j)
        {
            puzzel_2D_array = puzzel;
            puzzel_size = size;
            blank_space_i = blank_i;
            blank_space_j = blank_j;
            direction_of_moves = "Start";
            Hamming();
            manhattan();
            number_of_level = 0;
            parent = null;

            for (int x = 0; x < puzzel_size * puzzel_size; x++)
            {
                    int i = x / puzzel_size;
                    int j = x % puzzel_size;
                    puzzel_2D_array[i, j] = puzzel[i, j];
                    key += puzzel[i, j]; 
            }
        }
       
        //*****************************************************************************************

        public Puzzel(Puzzel p, int x)
        {
            puzzel_size = p.puzzel_size;
            puzzel_2D_array = new int[puzzel_size, puzzel_size];
            blank_space_i = p.blank_space_i;
            blank_space_j = p.blank_space_j;
            number_of_level = p.number_of_level;
            parent = p;
            cost = p.cost;
            key = p.key;
            hamming_value = p.hamming_value;
            manhattan_value = p.manhattan_value;

            for (int y = 0; y < puzzel_size * puzzel_size; y++)
            {
                int i = y / puzzel_size;
                int j = y % puzzel_size;
                puzzel_2D_array[i, j] = p.puzzel_2D_array[i, j];
                
            }
        }

        //***************copy constructor**************************************************************************
        public Puzzel(Puzzel p)
         {
            puzzel_size = p.puzzel_size;
            puzzel_2D_array = new int[puzzel_size, puzzel_size];
            blank_space_i = p.blank_space_i;
            blank_space_j = p.blank_space_j;
            number_of_level = p.number_of_level + 1;
            parent = p.parent;

            for (int x = 0; x < puzzel_size * puzzel_size; x++)
            {
                int i = x / puzzel_size;
                int j = x % puzzel_size;
                puzzel_2D_array[i, j] = p.puzzel_2D_array[i, j];
               
            }
         }

        //*****************************************************************************************
        public void Hamming()
        {
            /* ex
             * ==> 1  2  3  4  5  6  7  8 
             * ==> 1  1  0  0  1  1  0  0
             * hamming_value = 4;
             */
            int miss_position = 0; // number of blocks out of place
            int correct_position = 1; // position correct number allocation
            for (int x = 0; x < puzzel_size * puzzel_size; x++)
            {
                int i = x / puzzel_size;
                int j = x % puzzel_size;
                key += puzzel_2D_array[i, j];
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0) //blank space
                    {
                        miss_position++;
                    } 
                    correct_position++;
            }
            hamming_value = miss_position;
        }

        //*****************************************************************************************

        public void manhattan()
        {
            int cnt = 0;
            int RES = 0;
            for (int x = 0; x < puzzel_size * puzzel_size; x++)
            {
                int row = x / puzzel_size;
                int col = x % puzzel_size;
                this.key += this.puzzel_2D_array[row, col];
                    int val = this.puzzel_2D_array[row, col];
                    RES++;
                    if (val != 0 && val != RES)
                    {
                        int temp1 = ((val - 1) / puzzel_size);
                        int temp2 = ((val - 1) % puzzel_size);
                        cnt += Math.Abs(row - temp1) + Math.Abs(col - temp2);
                    }
            
            }
            manhattan_value = cnt;
        }

        //*****************************************************************************************

        public void Calculate_cost_of_hamming()
        { 
            // f(n) = g(n) + h(n)
            cost = number_of_level + hamming_value;
        }
        public void Calculate_cost_Manhattan()
        {
            /*f(n) = g(n) + h(n)*/
            cost = number_of_level + manhattan_value;
        }

        //*****************************************************************************************

        public bool IS_reache_to_goal_hamming()
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
        public bool IS_reache_to_goal_manhattan()
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
        public int UP_movement() 
        {           
            int swap_part = puzzel_2D_array[blank_space_i - 1, blank_space_j];
            puzzel_2D_array[blank_space_i,blank_space_j] = swap_part;
            swap_part = 0;
            puzzel_2D_array[blank_space_i - 1, blank_space_j] = swap_part;
            // To know where blank space is it 
            blank_space_i = blank_space_i - 1;
            return puzzel_2D_array[blank_space_i, blank_space_j];
        }

        public int Down_movement()
        {
            int swap_part = puzzel_2D_array[blank_space_i + 1, blank_space_j];
            puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;
            swap_part = 0;  //position = 0 
            puzzel_2D_array[blank_space_i + 1, blank_space_j] = swap_part;
            // To know where blank space is it 
            blank_space_i = blank_space_i + 1;
            return puzzel_2D_array[blank_space_i, blank_space_j];

        }
       
        public int Left_movement()
        {
            int swap_part = puzzel_2D_array[blank_space_i, blank_space_j - 1];
            puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;
            swap_part = 0; //position = 0 
            puzzel_2D_array[blank_space_i, blank_space_j - 1] = swap_part;
            // To know where blank space is it 
            blank_space_j = blank_space_j - 1;
            return puzzel_2D_array[blank_space_i, blank_space_j];
        }
       
        public int Right_movement()
        {
            int swap_part = puzzel_2D_array[blank_space_i, blank_space_j + 1];
            puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;
            swap_part = 0; //position = 0 
            puzzel_2D_array[blank_space_i, blank_space_j + 1] = swap_part;
            // To know where blank space is it 
            blank_space_j = blank_space_j + 1;
            return puzzel_2D_array[blank_space_i, blank_space_j];
        }


        public bool check_Movement_value(int u, int d, int l, int r)
        {
            if (u == 1)
            {
                if (blank_space_i != 0)
                {
                    mov.up = true;
                }
                return mov.up;
            }
            if (d == 1)
            {
                if (blank_space_i != puzzel_size - 1)
                {
                    mov.down = true;
                }
                return mov.down;
            }
            if (l == 1)
            {
                if (blank_space_j != 0)
                {
                    mov.left = true;
                }
                return mov.left;
            }
            if (r == 1)
            {
                if (blank_space_j != puzzel_size - 1)
                {
                    mov.right = true;
                }
                return mov.right;
            }
            else
                return false;
        }

        /*********************************************End of movement********************************************/

        public void Display()
        {
             Console.WriteLine(puzzel_2D_array.Cast<int>());

            Console.WriteLine();
            /* for (int i = 0; i < puzzel_size; i++)
             {
                 for (int j = 0; j < puzzel_size; j++)
                 {
                     Console.Write(puzzel_2D_array[i, j] + " ");
                 }
                 if (i == 0) //message of direction will appear in when i = 0
                 {
                     Console.WriteLine("--> ( " + direction_of_moves + " )"); 
                 }
                 else
                 { 
                     Console.WriteLine();
                 }
             }
             Console.WriteLine("________________");*/
        }

    }
}

