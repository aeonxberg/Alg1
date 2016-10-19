using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawQueueLinkedList
    {
        public Link First { get; set; }

        protected Link Last { get; set; }

        protected int _count;


        //
        // Workshop methodes
        //

        public void Enqueue(NAW naw)
        {
            Link newQueueLink = new Link();
            newQueueLink.Naw = naw;
            if (First == null)
            {
                First = newQueueLink;
                Last = newQueueLink;
            }
            else
            {
                Last.Next = newQueueLink;
                Last = newQueueLink;
                Last.Next = null;
            }
            _count++;
        }

        public NAW Dequeue()
        {
            Link removeLink = First;

            if (First != null)
            {
                First = First.Next;
                _count--;
                return removeLink.Naw;
            }
            else
            {
                return null;
            }
        }

        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //


        public int Count()
        {
            return _count;
        }
    }

 }
