﻿using System;
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
        public void Display_path(int size)
        {
            if (Exit == 0)
            {
                int num = Path_Of_Res.Count;
                if (size == 3)
                {
                    for (int i = num - 1; i >= 0; i--)
                    {
                        Path_Of_Res[i].Display();
                    }
                }             
                Console.WriteLine("______________________________________");
                Console.WriteLine("--> ( Number of Movements = " + (num - 1) + " )");
                Console.WriteLine("______________________________________");
            }
            Exit = 1;
        }
        //***********************************************************************************
        public void get_Entire_Path(Puzzel Final)
        {
            Puzzel path = Final.parent;
            int size = Final.puzzel_size;
            while (path.parent != null)
            {
                Path_Of_Res.Add(path);
                path = path.parent;
            }
            Path_Of_Res.Add(path);
            Display_path(size);
        }
        //***********************************************************************************
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
        }

        //***********************************************************************************
        public int Child_Open(Puzzel N)
        {
            if (Open_child.ContainsKey(N.key) == true)
            {
                return 0;
            }
            return 1;
        }

        //***********************************************************************************
        public void Create_New_Child(Puzzel N)
        {
            if (N.check_Movement_value(1, 0, 0, 0) == true)
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.UP_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_cost_Manhattan();
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
            if (N.check_Movement_value(0, 1, 0, 0) == true)
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.Down_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_cost_Manhattan();
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
            if (N.check_Movement_value(0, 0, 0, 1) == true)
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.Right_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_cost_Manhattan();
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
            if (N.check_Movement_value(0, 0, 1, 0) == true)
            {
                Puzzel New_puzzel = new Puzzel(N);
                New_puzzel.Left_movement();
                New_puzzel.manhattan();
                New_puzzel.Calculate_cost_Manhattan();
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

        //***********************************************************************************
        public void A__Algorithm(Puzzel First)
        {
            Open_child.Add(First.key, First);
            PQ_list.Enqueue(First);
            while (Exit == 0)
            {
                Puzzel New = new Puzzel(PQ_list.Dequeue(), 0);
                if(Closed_child(New) == 1)
                {
                    closed_child.Add(New.key, New);
                    Create_New_Child(New);
                }
            }
        }       
    }
}
