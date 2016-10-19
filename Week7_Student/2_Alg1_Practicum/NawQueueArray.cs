using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alg1_Practicum_Utils.Exceptions;

namespace Alg1_Practicum
{
    public class NawQueueArray
    {
        public int Front { get; set; }

        public int Rear { get; set; }

        protected Alg1NawArray _array; // interne array
        protected int _count; // aantal gebruikte index in interne array
        protected int _size; // maximale omvang van interne array


        //
        // Workshop methodes
        //

        public void Enqueue(NAW naw)
        {
            throw new NotImplementedException();
        }

        public NAW Dequeue()
        {
            throw new NotImplementedException();
        }


        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public NawQueueArray(int initialSize)
        {
            // aanmaken intern array
            if ((initialSize > 0) && (initialSize <= 1000))
            {
                _size = initialSize;
            }
            else
            {
                throw new NawQueueArrayInvalidSizeException();
            }

            _array = new Alg1NawArray(_size);

            // verdere initialisatie

            Front = 0;
            Rear = -1;
        }


        public int Count()
        {
            return _count;
        }
    }

}
