using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawQueueDotNet
    {
        Queue<NAW> newQueue = new Queue<NAW>();
        //
        // Workshop methodes
        //

        public void Enqueue(NAW naw)
        {
            newQueue.Enqueue(naw);
        }

        public NAW Dequeue()
        {
            if (newQueue.Count()>=1)
            {
                return newQueue.Dequeue();
            }
            else
            {
                return null;
            }
        }

        public int Count()
        {
            return newQueue.Count();
           
        }

    }
}
