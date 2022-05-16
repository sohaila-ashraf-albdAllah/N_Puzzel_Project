using System;
using System.Collections.Generic;
using System.Text;

namespace N_Puzzel_Project
{
    class Manhattan
    {
        public Dictionary<string, Puzzel> Open_child = new Dictionary<string, Puzzel>();
        public Dictionary<string, Puzzel> closed_child = new Dictionary<string, Puzzel>();
        public Priority_Queue PQ_list = new Priority_Queue();
        public List<Puzzel> Path_Of_Res = new List<Puzzel>();
        static int Exit = 0;

        public int Closed_child(Puzzel N)
        {
            if (closed_child.ContainsKey(N.key) == true)
            {
                //check if cost of cloed one less than 
                Puzzel check = closed_child[N.key];
                if (check.cost < N.cost)
                {
                    PQ_list.Enqueue(check);
                    Open_child.Add(check.key, check);
                }
                return 0;
            }
            return 1;
        }//n
        public int Child_Open(Puzzel N)
        {
            if (Open_child.ContainsKey(N.key) == true)
            {
                return 0;
            }
            return 1;
        }//n
        public void Create_New_Child(Puzzel N)
        {
            if (N.check_up_value() == true)
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.UP_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_min_cost_Manhattan();
                if (New_puzzel.IS_reache_to_goal_manhattan() == true)
                {
                    New_puzzel.direction_of_moves = "Goal";
                    Path_Of_Res.Add(New_puzzel);
                    get_Entire_Path(New_puzzel);
                }
                New_puzzel.direction_of_moves = "Up";
                int flag = Child_Open(New_puzzel);
                if (flag == 1)
                {
                    PQ_list.Enqueue(New_puzzel);
                    Open_child.Add(New_puzzel.key, New_puzzel);
                }
            }
            if (N.check_down_value() == true)
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.Down_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_min_cost_Manhattan();
                if (New_puzzel.IS_reache_to_goal_manhattan() == true)
                {
                    New_puzzel.direction_of_moves = "Goal";
                    Path_Of_Res.Add(New_puzzel);
                    get_Entire_Path(New_puzzel);
                }
                New_puzzel.direction_of_moves = "Down";
                int flag = Child_Open(New_puzzel);
                if (flag == 1)
                {
                    PQ_list.Enqueue(New_puzzel);
                    Open_child.Add(New_puzzel.key, New_puzzel);
                }
            }
            if (N.check_right_value() == true)
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.Right_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_min_cost_Manhattan();
                if (New_puzzel.IS_reache_to_goal_manhattan() == true)
                {
                    New_puzzel.direction_of_moves = "Goal";
                    Path_Of_Res.Add(New_puzzel);
                    get_Entire_Path(New_puzzel);
                }
                New_puzzel.direction_of_moves = "Right";
                int flag = Child_Open(New_puzzel);
                if (flag == 1)
                {
                    PQ_list.Enqueue(New_puzzel);
                    Open_child.Add(New_puzzel.key, New_puzzel);
                }
            }
            if (N.check_left_value() == true)
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.Left_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_min_cost_Manhattan();
                if (New_puzzel.IS_reache_to_goal_manhattan() == true)
                {
                    New_puzzel.direction_of_moves = "Goal";
                    Path_Of_Res.Add(New_puzzel);
                    get_Entire_Path(New_puzzel);
                }
                New_puzzel.direction_of_moves = "Left";
                int flag = Child_Open(New_puzzel);
                if (flag == 1)
                {
                    PQ_list.Enqueue(New_puzzel);
                    Open_child.Add(New_puzzel.key, New_puzzel);
                }
            }
        }
        public void A__Algorithm(Puzzel First)
        {
            Open_child.Add(First.key, First);
            PQ_list.Enqueue(First);
            while (PQ_list.PUZZLE.Count != 0)
            {
                Puzzel New = new Puzzel(PQ_list.Dequeue(), 0);
                if(Closed_child(New) == 1)
                {
                    closed_child.Add(New.key, New);
                    Create_New_Child(New);
                }
            }
        }
        public void get_Entire_Path(Puzzel Final)
        {
            Puzzel path = Final.parent;
            while (path.parent != null)
            {
                Path_Of_Res.Add(path);
                path = path.parent;
            }
            Path_Of_Res.Add(path);
            Display_path();
        }
        public void Display_path()
        {
            if(Exit == 0)
            {
                int Num_Of_Paths = Path_Of_Res.Count;
                int Num_Of_Movements = Num_Of_Paths - 1;
                for (int i = Num_Of_Paths - 1; i >= 0; i--)
                {
                    Path_Of_Res[i].Display();
                }
                /* int i = 0, j = 0, cn = 0 , Num_Of_Paths = Path_Of_Res.Count ,;
                 if (cn == i && cn % puzzel_size == 0)
                {
                    Console.WriteLine(" ------- > " + direction_of_moves);
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
            */
                Console.Write("----------------------------------------");
                Console.WriteLine();
                Console.Write(" Number Of Movements = " + Num_Of_Movements);
                Console.WriteLine();
                Console.Write("----------------------------------------");
            }      
            Exit = 1;
        }
    }
}
