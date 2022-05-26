using System;
using System.Collections.Generic;
using System.Text;

namespace N_Puzzel_Project
{
    class Manhattan
    {
        static int Exit = 0;
        public Dictionary<string, Puzzel> Open_child = new Dictionary<string, Puzzel>();
        public Dictionary<string, Puzzel> closed_child = new Dictionary<string, Puzzel>();
        public Priority_Queue PQ_list = new Priority_Queue();
        public List<Puzzel> Path_Of_Res = new List<Puzzel>();

        //***********************************************************************************
        public void Display_path(int size)//Θ(N^2)
        {
            if (Exit == 0) //O(1)
            {
                int num = Path_Of_Res.Count; //O(1)
                if (size == 3) //O(1)
                {
                    for (int i = num - 1; i >= 0; i--) //O(n) * O(n) ==> O(N^2)
                    {
                        Path_Of_Res[i].Display();//O(n)
                    }
                }
                Console.WriteLine("--> ( Number of Movements = " + (num - 1) + " )"); //O(1)
            }
            Exit = 1; //O(1)
        }
        //***********************************************************************************
        public void get_Entire_Path(Puzzel Final)//Θ(N^2)
        {
            Puzzel prnt = Final.parent; //o(1)
            int size = Final.puzzel_size; //o(1)
            while (prnt.parent != null) //o(N)
            {
                Path_Of_Res.Add(prnt); //o(1)
                prnt = prnt.parent; //o(1)
            }
            Path_Of_Res.Add(prnt); //o(1)
            Display_path(size);//Θ(N^2)
        }
        //***********************************************************************************
        public int Closed_child(Puzzel N)//O(N)
        {
            if (closed_child.ContainsKey(N.key) == true) //O(N)
            {
                //check if cost of cloed one less than 
                Puzzel check = closed_child[N.key]; //O(1)
                if (check.cost < N.cost) //O(1)
                {
                    PQ_list.Enqueue(check);//O(N)
                    Open_child.Add(check.key, check);//O(1)
                }
                return 0; //O(1)
            }
            return 1;  //O(1)
        }

        //***********************************************************************************
        public int Child_Open(Puzzel N)//O(N)
        {
            if (Open_child.ContainsKey(N.key) == true)//O(N)
            {
                return 0;//O(1)
            }
            return 1;//O(1)
        }

        //***********************************************************************************
        public void Create_New_Child(Puzzel N)//O(N^2)
        {
            if (N.check_Movement_value(1, 0, 0, 0) == true)//O(N)
            {
                Puzzel New_puzzel = new Puzzel(N);//O(1)
                New_puzzel.UP_movement();//O(N)
                New_puzzel.manhattan();//O(N)
                New_puzzel.Calculate_cost_Manhattan();//O(N)
                if (New_puzzel.IS_reache_to_goal_manhattan() == true)//O(1)
                {
                    New_puzzel.direction_of_moves = "Goal";//O(1)
                    Path_Of_Res.Add(New_puzzel);//O(1)
                    get_Entire_Path(New_puzzel);//O(N^2)
                }
                New_puzzel.direction_of_moves = "Up"; //O(1)
                int flag = Child_Open(New_puzzel);//O(N)
                if (flag == 1)//O(1)
                {
                    PQ_list.Enqueue(New_puzzel);//O(N)
                    Open_child.Add(New_puzzel.key, New_puzzel);//O(1)
                }
            }
            if (N.check_Movement_value(0, 1, 0, 0) == true)//O(N)
            {
                Puzzel New_puzzel = new Puzzel(N);//O(1)
                New_puzzel.Down_movement();//O(N)
                New_puzzel.manhattan();//O(N)
                New_puzzel.Calculate_cost_Manhattan();//O(N)
                if (New_puzzel.IS_reache_to_goal_manhattan() == true)//O(1)
                {
                    New_puzzel.direction_of_moves = "Goal";//O(1)
                    Path_Of_Res.Add(New_puzzel);//O(1)
                    get_Entire_Path(New_puzzel);//O(N^2)
                }
                New_puzzel.direction_of_moves = "Down";//O(1)
                int flag = Child_Open(New_puzzel);//O(N)
                if (flag == 1)//O(1)
                {
                    PQ_list.Enqueue(New_puzzel);//O(N)
                    Open_child.Add(New_puzzel.key, New_puzzel);//O(1)
                }
            }
            if (N.check_Movement_value(0, 0, 0, 1) == true)//O(N)
            {
                Puzzel New_puzzel = new Puzzel(N);//O(1)
                New_puzzel.Right_movement();//O(N)
                New_puzzel.manhattan();//O(N)
                New_puzzel.Calculate_cost_Manhattan();//O(N)
                if (New_puzzel.IS_reache_to_goal_manhattan() == true)//O(1)
                {
                    New_puzzel.direction_of_moves = "Goal";//O(1)
                    Path_Of_Res.Add(New_puzzel);//O(1)
                    get_Entire_Path(New_puzzel);//O(N^2)
                }
                New_puzzel.direction_of_moves = "Right";//O(1)
                int flag = Child_Open(New_puzzel);//O(N)
                if (flag == 1)//O(1)
                {
                    PQ_list.Enqueue(New_puzzel);//O(N)
                    Open_child.Add(New_puzzel.key, New_puzzel);//O(1)
                }
            }
            if (N.check_Movement_value(0, 0, 1, 0) == true)//O(N)
            {
                Puzzel New_puzzel = new Puzzel(N);//O(1)
                New_puzzel.Left_movement();//O(N)
                New_puzzel.manhattan();//O(N)
                New_puzzel.Calculate_cost_Manhattan();//O(N)
                if (New_puzzel.IS_reache_to_goal_manhattan() == true)//O(1)
                {
                    New_puzzel.direction_of_moves = "Goal";//O(1)
                    Path_Of_Res.Add(New_puzzel);//O(1)
                    get_Entire_Path(New_puzzel);//O(N^2)
                }
                New_puzzel.direction_of_moves = "Left";//O(1)
                int flag = Child_Open(New_puzzel);//O(N)
                if (flag == 1)//O(1)
                {
                    PQ_list.Enqueue(New_puzzel);//O(N)
                    Open_child.Add(New_puzzel.key, New_puzzel);//O(1)
                }
            }
        }

        //***********************************************************************************
        public void A__Algorithm(Puzzel First)//O(N^3)
        {
            Open_child.Add(First.key, First);//O(1)
            PQ_list.Enqueue(First);//O(N)
            while (Exit == 0)//O(N)
            {
                Puzzel New = new Puzzel(PQ_list.Dequeue(), 0);//O(N^2)
                if (Closed_child(New) == 1)//O(N)
                {
                    closed_child.Add(New.key, New);//O(1)
                    Create_New_Child(New);//O(N^2)
                }
            }
        }       
    }
}
