using System;
using System.Collections.Generic;
using System.Text;

namespace N_Puzzel_Project
{
    class Puzzel
    {

        public int[,] puzzel_2D_array;
        public int puzzel_size, blank_space_i, blank_space_j;
        public int hamming_value;
        public String direction_of_moves , key="";
        public int cost, number_of_level; //number of moves tree level
        public Puzzel parent;

        public Puzzel(int size, int[,] puzzel , int blank_i , int blank_j)
        {
            puzzel_2D_array = puzzel;
            puzzel_size = size;
            blank_space_i = blank_i;
            blank_space_j = blank_j;
            direction_of_moves = "Start";
            for (int i = 0; i < puzzel_size; i++)
            {
                for (int j = 0; j < puzzel_size; j++)
                {
                    puzzel_2D_array[i, j] = puzzel[i, j];
                    key += puzzel_2D_array[i, j];

                }
            }
            Hamming();
            number_of_level = 0;
            parent = null;
        }
    
        //copy constructor 
         public Puzzel(Puzzel p)
        {
            puzzel_size = p.puzzel_size;
            puzzel_2D_array = new int[puzzel_size, puzzel_size];
            for (int i = 0; i < puzzel_size; i++)
            {
                for (int j = 0; j < puzzel_size; j++)
                {

                    puzzel_2D_array[i, j] = p.puzzel_2D_array[i, j];
                }
            }
            blank_space_i = p.blank_space_i;
            blank_space_j = p.blank_space_j;
            number_of_level = p.number_of_level + 1;
            parent = p.parent;

        }

        public void Hamming()
        {
            /* ex
             * ==> 1  2  3  4  5  6  7  8 
             * ==> 1  1  0  0  1  1  0  0
             * hamming_value = 4;
             */

            int miss_position = 0; // number of blocks out of place
            int correct_position = 1; // position correct number allocation
            for (int i = 0; i < puzzel_size; i++)
            {
                for (int j = 0; j < puzzel_size; j++)
                {
                    key += this.puzzel_2D_array[i, j];
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0) //blank space
                    {
                        miss_position++;
                    }
                    else 
                    correct_position++;
                }
            }

            hamming_value = miss_position;
        }

        public void Calculate_min_cost_of_hamming()
        { 
            // f(n) = g(n) + h(n)
            cost = number_of_level + hamming_value;
        }

        public Boolean IS_reache_to_goal_hamming()
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

        /*********************************************Movement**********************************************/
        /*  j/i | 0  1  2
         *  ----|----------
         *   0  | 4  1  3
         *   1  | 0  2  5
         *   2  | 7  8  6
         */
        public void UP_movement() 
        {           
                int swap_part = puzzel_2D_array[blank_space_i - 1, blank_space_j];
                puzzel_2D_array[blank_space_i,blank_space_j] = swap_part;
                swap_part = 0;  
                // To know where blank space is it 
                blank_space_i = blank_space_i - 1;
        }
      public Boolean check_up_value ()
        {
            if (blank_space_i != 0)
            {
                 UP_movement();
                 Hamming();
                 Calculate_min_cost_of_hamming();
                 return true;
            }
            else
                return false;

        }

        public void Down_movement()
        {
                int swap_part = puzzel_2D_array[blank_space_i + 1, blank_space_j];
                puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;
                swap_part = 0;  //position = 0 
                // To know where blank space is it 
                blank_space_i = blank_space_i + 1;
        }

        public Boolean check_down_value()
        {
            if (blank_space_i != puzzel_size - 1)
            {
                UP_movement();
                Hamming();
                Calculate_min_cost_of_hamming();
                return true;
            }
            else
                return false;

        }

        public void Left_movement()
        {
                int swap_part = puzzel_2D_array[blank_space_i, blank_space_j - 1];
                puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;
                swap_part = 0; //position = 0 
                // To know where blank space is it 
                blank_space_j = blank_space_j - 1;
        }

        public Boolean check_left_value()
        {
            if (blank_space_j != 0)
            {
                UP_movement();
                Hamming();
                Calculate_min_cost_of_hamming();
                return true;
            }
            else
                return false;

        }
        public void right_movement()
        {
                int swap_part = puzzel_2D_array[blank_space_i, blank_space_j + 1];
                puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;
                swap_part = 0; //position = 0 
                // To know where blank space is it 
                blank_space_j = blank_space_j + 1;
        }

        public Boolean check_right_value()
        {
            if (blank_space_j != puzzel_size - 1)
            {
                UP_movement();
                Hamming();
                Calculate_min_cost_of_hamming();
                return true;
            }
            else
                return false;
        }
        
        /*********************************************End of movement********************************************/

        public void display()
        {
            for (int i = 0; i < puzzel_size; i++)
            {
                for (int j = 0; j < puzzel_size; j++)
                {
                    Console.Write(puzzel_2D_array[i, j]);
                    Console.Write(" ");
                }
                if (i == 0) //message of direction will appear in when i = 0
                {
                    Console.WriteLine(" ----> " + direction_of_moves); 
                }
                else { 
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}

