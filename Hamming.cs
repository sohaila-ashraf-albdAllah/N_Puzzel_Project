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
            while (prnt.parent != null) //o(N)
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
        public bool Child_Open(Puzzel child)//O(N)
        {
            if (Open_child.ContainsKey(child.key) == true) //O(N)
            {
                return true; //O(1)
            }
            else
                return false; //O(1)
        }

        //***********************************************************************************
        public void Create_New_Child(Puzzel p) //O(N^2)
        {
            if (p.check_Movement_value(1,0,0,0)==true) //O(N)
            {
                Puzzel child = new Puzzel(p); //O(1)
                bool check; //O(1)
                child.UP_movement(); //O(N)
                child.Hamming(); //O(N)
                child.Calculate_cost_of_hamming(); //O(N)

                if (child.IS_reache_to_goal_hamming() == true) //O(1)
                {
                    child.direction_of_moves = "Goal"; //O(1)
                    Path_Of_Res.Add(child); //O(1)
                    Get_final_Path(child);//O(N^2)
                }
                child.direction_of_moves = "UP"; //O(1)
                check = Child_Open(child); //O(N)

                if (check == false) //O(1)
                {
                    PQ_list.Enqueue(child);//O(N)
                    Open_child.Add(child.key, child); //O(1)
                }
            }

            if (p.check_Movement_value(0, 1, 0, 0) == true)//O(N)
            {
                Puzzel child = new Puzzel(p);//O(1)
                bool check;//O(1)
                child.Down_movement();//O(N)
                child.Hamming();//O(N)
                child.Calculate_cost_of_hamming();//O(1)

                if (child.IS_reache_to_goal_hamming() == true) //o(1)
                {
                    child.direction_of_moves = "Goal"; //O(1)
                    Path_Of_Res.Add(child); //O(1)
                    Get_final_Path(child);//O(N^2)
                }

                child.direction_of_moves = "Down";//O(1)
                check = Child_Open(child);//O(N)

                if (check == false) //O(1)
                {
                    PQ_list.Enqueue(child);//O(N)
                    Open_child.Add(child.key, child); //O(1)
                }
            }

            if (p.check_Movement_value(0, 0, 1, 0) == true)
            {
                Puzzel child = new Puzzel(p);//O(1)
                bool check;//O(1)
                child.Left_movement();//O(N)
                child.Hamming();//O(N)
                child.Calculate_cost_of_hamming();//O(1)

                if (child.IS_reache_to_goal_hamming() == true) //o(1)
                {
                    child.direction_of_moves = "Goal"; //O(1)
                    Path_Of_Res.Add(child); //O(1)
                    Get_final_Path(child);//O(N^2)
                }
                child.direction_of_moves = "Left";//O(N)
                check = Child_Open(child);//O(N)

                if (check == false) //O(1)
                {
                    PQ_list.Enqueue(child);//O(N)
                    Open_child.Add(child.key, child); //O(1)
                }
            }

            if (p.check_Movement_value(0, 0, 0, 1) == true)
            {
                Puzzel child = new Puzzel(p);//O(1)
                bool check;//O(1)
                child.Right_movement();//O(N)
                child.Hamming();//O(N)
                child.Calculate_cost_of_hamming();//O(1)
                if (child.IS_reache_to_goal_hamming() == true) //o(1)
                {
                    child.direction_of_moves = "Goal"; //O(1)
                    Path_Of_Res.Add(child); //O(1)
                    Get_final_Path(child);//O(N^2)
                }
                child.direction_of_moves = "Right";//O(N)
                check = Child_Open(child);//O(N)

                if (check == false) //O(1)
                {
                    PQ_list.Enqueue(child);//O(N)
                    Open_child.Add(child.key, child); //O(1)
                }
            }
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
        public void A_Star_Algorithm_wiht_hamming(Puzzel First)//O(N^3)
        {
            Open_child.Add(First.key, First);//O(1)
            PQ_list.Enqueue(First);//O(N)
            while (Exit == 0)//O(N)
            {
                Puzzel New = new Puzzel(PQ_list.Dequeue(),0);//O(N^2)
                if (Closed_child(New) == 1)//O(N)
                {
                    closed_child.Add(New.key, New);//O(1)
                    Create_New_Child(New);//O(N^2)
                }
            }
        } 
    }
}
