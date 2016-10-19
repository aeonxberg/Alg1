using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawPriorityQueue
    {

        //
        // Huiswerk methodes
        //
        private Dictionary<int, NawQueueLinkedList> priorityQueue;
        private int used = 0;
        private int highestPriorityQueue = 0;

        public NawPriorityQueue()
        {
            priorityQueue = new Dictionary<int, NawQueueLinkedList>();
        }

        public void Enqueue(int key, NAW naw)
        {
            if (key > highestPriorityQueue)
            {
                highestPriorityQueue = key;
            }

            NawQueueLinkedList list = priorityQueue[key];

            if (list == null)
            {
                list = new NawQueueLinkedList();
                priorityQueue.Add(key, list);
            }
            used++;
            list.Enqueue(naw);
        }


        public NAW Dequeue()
        {
            if (used == 0)
            {
                return null;
            }
            for (int i = highestPriorityQueue; i > 0; i++)
            {
                NawQueueLinkedList list = priorityQueue[i];
                if (list.Count() > 0)
                {
                    NAW firstNaw = list.First.Naw;
                    list.Dequeue();
                    return firstNaw;
                }
            }
            return null;
        }

        public int Count()
        {
            return used;
        }

    }
}
