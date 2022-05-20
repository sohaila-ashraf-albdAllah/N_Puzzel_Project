using System;
using System.Collections.Generic;
using System.Text;

namespace N_Puzzel_Project
{        
    class Hamming
    {
        static int Exit = 0;
        public Dictionary<string, Puzzel> Open_child = new Dictionary<string, Puzzel>();
        public Dictionary<string, Puzzel> closed_child = new Dictionary<string, Puzzel>();
        public Priority_Queue PQ_list = new Priority_Queue();
        public List<Puzzel> Path_Of_Res = new List<Puzzel>();

        //***********************************************************************************
        public void Get_final_Path(Puzzel final) //Θ(N^2)
        {
            Puzzel prnt = final.parent; //o(1)
            int size = final.puzzel_size; //o(1)
            while (prnt.parent != null) //o(n)
            {
                Path_Of_Res.Add(prnt); //o(1)
                prnt = prnt.parent; //o(1)
            }
            Path_Of_Res.Add(prnt); //o(1)
            Display_(size); //Θ(N^2)
        }

        //***********************************************************************************
        public void Display_(int size) //Θ(N^2)
        {
            if (Exit == 0) //o(1)
            {
                int num = Path_Of_Res.Count; //o(1)
                if (size == 3) //o(1)
                {
                    for (int i = num - 1; i >= 0; i--) //o(n) * o(n) ==> O(N^2)
                    {
                        Path_Of_Res[i].Display();//o(n)
                    }
                }
                Console.WriteLine("______________________________________"); //o(1)
                Console.WriteLine("--> ( Number of Movements = " + (num - 1) + " )"); //o(1)
                Console.WriteLine("______________________________________"); //o(1)
            }
            Exit = 1; //o(1)
        }

        //***********************************************************************************
        public bool Child_Open(Puzzel child)//Θ(1)
        {
            if (Open_child.ContainsKey(child.key) == true) //o(1)
            {
                return true; //o(1)
            }
            else
                return false; //o(1)
        }

        //***********************************************************************************
        public void Create_New_Child(Puzzel p) //Θ(N^2)
        {
            if (p.check_Movement_value(1,0,0,0)==true) //o(1)
            {
                Puzzel child = new Puzzel(p); //o(1)
                bool check; //o(1)
                child.UP_movement(); //o(1)
                child.Hamming(); //o(n)
                child.Calculate_cost_of_hamming(); //o(1)

                if (child.IS_reache_to_goal_hamming() == true) //o(1)
                {
                    child.direction_of_moves = "Goal"; //o(1)
                    Path_Of_Res.Add(child); //o(1)
                    Get_final_Path(child);//o(N^2)
                }
                child.direction_of_moves = "UP"; //o(1)
                check = Child_Open(child); //o(1)

                if (check == false) //o(1)
                {
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child); //o(1)
                }
            }

            if (p.check_Movement_value(0, 1, 0, 0) == true)
            {
                Puzzel child = new Puzzel(p);
                bool check;
                child.Down_movement();
                child.Hamming();
                child.Calculate_cost_of_hamming();
                
                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves = "Goal";
                    Path_Of_Res.Add(child);
                    Get_final_Path(child);
                }
                child.direction_of_moves = "Down";
                check = Child_Open(child);

                if (check == false)
                {
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }
            }

            if (p.check_Movement_value(0, 0, 1, 0) == true)
            {
                Puzzel child = new Puzzel(p);
                bool check;
                child.Left_movement();
                child.Hamming();
                child.Calculate_cost_of_hamming();
               
                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves = "Goal";
                    Path_Of_Res.Add(child);
                    Get_final_Path(child);
                }
                child.direction_of_moves = "Left";
                check = Child_Open(child);

                if (check == false)
                {
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }
            }

            if (p.check_Movement_value(0, 0, 0, 1) == true)
            {
                Puzzel child = new Puzzel(p);
                bool check;
                child.Right_movement();
                child.Hamming();
                child.Calculate_cost_of_hamming();
                if (child.IS_reache_to_goal_hamming() == true)
                {
                    child.direction_of_moves = "Goal";
                    Path_Of_Res.Add(child);
                    Get_final_Path(child);
                }
                child.direction_of_moves = "Right";

                check = Child_Open(child);
                if (check == false)
                {
                    PQ_list.Enqueue(child);
                    Open_child.Add(child.key, child);
                }
            }
        }

        //***********************************************************************************
        public int Closed_child(Puzzel N)
        {
            if (closed_child.ContainsKey(N.key) == true) //o(1)
            {
                //check if cost of cloed one less than 
                Puzzel check = closed_child[N.key]; //o(1)
                if (check.cost < N.cost) //o(1)
                {
                    PQ_list.Enqueue(check);
                    Open_child.Add(check.key, check);//o(1)
                }
                return 0; //o(1)
            }
            return 1;  //o(1)
        }

        //***********************************************************************************
        public void A_Star_Algorithm_wiht_hamming(Puzzel First)
        {
            Open_child.Add(First.key, First); //o(1)
            PQ_list.Enqueue(First);
            while (Exit == 0)
            {
                Puzzel New = new Puzzel(PQ_list.Dequeue(),0);
                if (Closed_child(New) == 1) 
                {
                    closed_child.Add(New.key, New);
                    Create_New_Child(New);
                }
            }
        } 
    }
}
