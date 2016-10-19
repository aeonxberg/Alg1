using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class Stack : IStack
    {
        protected StackLink First { get; set; }

        //
        // Workshop methodes
        //

        public void Push(string value)
        {
            StackLink newLink = new StackLink();
            newLink.String = value;

            if (First == null)
            {
                First = newLink;
            }
            else
            {
                newLink.Next = First;
                First = newLink;
            }

        }

        public string Pop()
        {
            if (IsEmpty())
            {
                return null;
            }
            else
            {
                StackLink returnLink = First;
                First = First.Next;
                return returnLink.String;
            }
        }

        public bool IsEmpty()
        {
            if (First == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public String Peek()
        {
            return !IsEmpty() ? First.String : null;
        }
    }
}
