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
                path.Add(prnt);
                prnt = prnt.parent;
            }
            path.Add(prnt);
            int num = path.Count();
            for (int i = num - 1; i >= 0; i--)
            { 
                path[i].display();
            }
            Console.Write(" Number of Movements = " + num - 1 );
            Console.WriteLine();
            Console.WriteLine("Open List Size :  " + PQ_list.size());
            Console.WriteLine();
            Console.WriteLine("Closed List Size : < " + closed_list.Count()+" >");
            Environment.Exit(0);
        }
       
        public Boolean Child_Open(puzzel child)
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
              Boolean check = true;
              puzzel child = new puzzel(p);
              check = check_if_child_in_open(child);

            if (p.check_up_value() == true)
            {
                child.UP_movement();
                child.Hamming();
                child.Calculate_min_cost_of_hamming();

                if (check == true)
                { 
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }

                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves= "Goal";
                    path.Add(c);
                    Get_Path(c);
                }
                c.direction_of_moves = "UP";
            }

            if (p.check_down_value() == true)
            {   
                child.Down_movement();
                child.Hamming();
                child.Calculate_min_cost_of_hamming();
                  if (check == true) 
                { 
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }
                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves= "Goal";
                    path.Add(child);
                    Get_Path(child);
                }
                 child.direction_of_moves =  "Down";
            }

            if (p.check_left_value == true)
            {
                child.Left_movement();
                child.Hamming();
                child.Calculate_min_cost_of_hamming();
                if (check == true) 
                { 
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }
                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves= "Goal";
                    path.Add(child);
                    Get_Path(child);
                }
                child.direction_of_moves = "Left";
            }

            if (p.check_right_value == true )
            {
                child.Right_movement();
                child.Hamming();
                child.Calculate_min_cost_of_hamming();
                    if (check == true) 
                { 
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }

                if (child.IS_reache_to_goal_hamming() == true)
                {
                   child.direction_of_moves = "Goal";
                    path.Add(child);
                    Get_Path(child);
                }
                child.direction_of_moves = "Right";
            }
           
        }

         public Boolean Check_if_child_in_closed(puzzel child)
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
    }
    }
}
