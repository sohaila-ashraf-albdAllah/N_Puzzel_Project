using System;
using System.Collections.Generic;
using System.Text;
namespace N_Puzzel_Project
{
    class Priority_Queue
    {  
        public List<Puzzel> PUZZLE;
        public Priority_Queue()
        {                                                                                                                                                                                                             
            PUZZLE = new List<Puzzel>();
        }
        static void swap_puzzel(Puzzel x, Puzzel y)
        {
            Puzzel tempswap = x;
            x = y;
            y  = tempswap;
        }
        public void Enqueue(Puzzel item)
        {
            PUZZLE.Add(item);
            int child_index = PUZZLE.Count - 1, parent_index;
            here:
            parent_index = (child_index - 1) / 2;
            if ((PUZZLE[child_index].cost) < (PUZZLE[parent_index].cost))
            {
                swap_puzzel(PUZZLE[child_index], PUZZLE[parent_index]);
                child_index = parent_index;
                goto here;
            }
        }
        public Puzzel Dequeue()
        {
            Puzzel frontItem = PUZZLE[0];
            int lastindex_beforeremove = PUZZLE.Count - 1;
            PUZZLE[0]= PUZZLE[lastindex_beforeremove];
            PUZZLE.RemoveAt(lastindex_beforeremove);
            int lastindex_afterchange = lastindex_beforeremove-1;
            int parent_index = 0;
            again:
            int leftchild_index = parent_index * 2 + 1;
            if (leftchild_index <= lastindex_afterchange)
            {
                int right_children = leftchild_index + 1;
                if (right_children <= lastindex_afterchange && PUZZLE[right_children].cost < PUZZLE[leftchild_index].cost)
                    leftchild_index = right_children;
                if (PUZZLE[parent_index].cost > (PUZZLE[leftchild_index].cost))
                {
                    Puzzel tmp = PUZZLE[parent_index];
                    PUZZLE[parent_index] = PUZZLE[leftchild_index];
                    PUZZLE[leftchild_index] = tmp;
                    parent_index = leftchild_index;
                    goto again;
                }
            }
            return frontItem;
        }
    }
}
