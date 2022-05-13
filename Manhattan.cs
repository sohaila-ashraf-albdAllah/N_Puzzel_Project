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

        public void A__Algorithm(Puzzel First)
        {
            Open_child.Add(First.key, First);
            PQ_list.Enqueue(First);
            while (PQ_list.data.Count != 0)
            {
                Puzzel New = new Puzzel(PQ_list.Dequeue());
                if(Closed_child(New) == 1)
                {
                    closed_child.Add(New.key, New);
                    Create_New_Child(New);
                }
            }
        }
        public void Create_New_Child(Puzzel N)
        {
            if( N.check_up_value()) 
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.UP_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_min_cost_Manhattan();
                if(New_puzzel.IS_reache_to_goal_manhattan())
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
            if (N.check_down_value())
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.Down_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_min_cost_Manhattan();
                if (New_puzzel.IS_reache_to_goal_manhattan())
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
            if (N.check_right_value())
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.right_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_min_cost_Manhattan();
                if (New_puzzel.IS_reache_to_goal_manhattan())
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
            if (N.check_left_value())
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.Left_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_min_cost_Manhattan();
                if (New_puzzel.IS_reache_to_goal_manhattan())
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
        public int Closed_child(Puzzel N)
        {
            if(closed_child.ContainsKey(N.key))
            {
                return 0;
            }
            return 1;
        }
        public int Child_Open(Puzzel N)
        {
            if (Open_child.ContainsKey(N.key))
            {
                return 0;
            }
            return 1;
        }
        public void Display_path()
        {
            int Num_Of_Paths = Path_Of_Res.Count;
            int Num_Of_Movements = Num_Of_Paths - 1;
            for (int i = 0; i < Num_Of_Paths; i++)
            {
                Path_Of_Res[i].Display();
            }
            Console.WriteLine();
            Console.Write(" Number Of Movements = " + Num_Of_Movements);
            Console.WriteLine();
            Environment.Exit(0);
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
    }
}
