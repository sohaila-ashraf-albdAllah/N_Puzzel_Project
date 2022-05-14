using System;
using System.Collections.Generic;
using System.Text;

namespace N_Puzzel_Project
{
    class Hamming
    {
        public Dictionary<string, Puzzel> Open_child = new Dictionary<string, Puzzel>();
        public Dictionary<string, Puzzel> closed_child = new Dictionary<string, Puzzel>();
        public Priority_Queue PQ_list = new Priority_Queue();
        public List<Puzzel> Path_Of_Res = new List<Puzzel>();
        public void Get_final_Path(Puzzel goal)
        {
            Puzzel prnt = goal.parent;
            while (prnt.parent != null)
            {
                Path_Of_Res.Add(prnt);
                prnt = prnt.parent;
            }
            Path_Of_Res.Add(prnt);
            Display();
        }

        public void Display()
        {
            int num = Path_Of_Res.Count;
            for (int i = num - 1; i >= 0; i--)
            {
                Path_Of_Res[i].Display();
            }
            Console.Write("----------------------------------------");
            Console.WriteLine();
            Console.Write("Number of Movements = " + (num - 1));
            Console.WriteLine();
            Console.Write("----------------------------------------");
            Environment.Exit(0);
        }
        public Boolean Child_Open(Puzzel child)
        {
            if (Open_child.ContainsKey(child.key))
            {
                return true;
            }
            else
                return false;

        }

        public void Create_New_Child(Puzzel p)
        {
            Puzzel child = new Puzzel(p);
            Boolean check;
            check = Child_Open(child);

            if (p.check_up_value() == true)
            {
                child.UP_movement();
                child.Hamming();
                child.Calculate_min_cost_of_hamming();

                if (check == false)
                {
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }

                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves = "Goal";
                    Path_Of_Res.Add(child);
                    Get_final_Path(child);
                }
                child.direction_of_moves = "UP";
            }

            if (p.check_down_value() == true)
            {
                child.Down_movement();
                child.Hamming();
                child.Calculate_min_cost_of_hamming();
                if (check == false)
                {
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }
                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves = "Goal";
                    Path_Of_Res.Add(child);
                    Get_final_Path(child);
                }
                child.direction_of_moves = "Down";
            }

            if (p.check_left_value() == true)
            {
                child.Left_movement();
                child.Hamming();
                child.Calculate_min_cost_of_hamming();
                if (check == false)
                {
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }
                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves = "Goal";
                    Path_Of_Res.Add(child);
                    Get_final_Path(child);
                }
                child.direction_of_moves = "Left";
            }

            if (p.check_right_value() == true)
            {
                child.Right_movement();
                child.Hamming();
                child.Calculate_min_cost_of_hamming();
                if (check == false)
                {
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }

                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves = "Goal";
                    Path_Of_Res.Add(child);
                    Get_final_Path(child);
                }
                child.direction_of_moves = "Right";
            }

        }

        public Boolean Closed_child(Puzzel child)
        {
            if (closed_child.ContainsKey(child.key))
            {
                return true;
            }
            return false;
        }

        public void A_Star_Algorithm_wiht_hamming(Puzzel First)
        {
            Open_child.Add(First.key, First);
            PQ_list.Enqueue(First);
            while (PQ_list.PUZZLE.Count != 0)
            {
                Puzzel New = new Puzzel(PQ_list.Dequeue(),0);
                if (Closed_child(New) == true)
                {
                    closed_child.Add(New.key, New);
                    Create_New_Child(New);
                }
            }
        } 
    }
}
