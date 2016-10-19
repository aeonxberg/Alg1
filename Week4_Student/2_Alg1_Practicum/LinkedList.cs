using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class LinkedList : ILinkedList
    {
        protected Link _first; // wijst naar eerste element in de lijst
        protected Link _last;  // wijst naar laatste element in de lijst
        protected int _length; // is gelijk aan het aantal links in de lijst 


        //
        // Workshop methodes
        //

        public void InsertHead(NAW naw)
        {
            //Voeg een link aan het begin
            //Pas de huidige eerste aan als tweede
            Link newLink = new Link { Naw = naw };

            if (_first != null)
            {
                newLink.Next = _first;
                newLink.Next.Naw = _first.Naw;
                _first= newLink;
            }
            else
            {
                _first = newLink;
                _first.Next = _last;

                _last = newLink;
                _last.Naw = naw;

            }
            _length++;
            
        }

        public void RemoveHead()
        {
            throw new NotImplementedException();
        }

        public int CountCalculated()
        {
            throw new NotImplementedException();
        }

        public int CountStored()
        {
            return _length;
        }

        public int FindNaw(NAW naw)
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }


        //
        // Huiswerk methodes
        //

        public virtual void InsertTail(NAW naw) // <= virtual keyword niet weghalen i.v.m. testscripts
        {
            throw new NotImplementedException();
        }

        public void RemoveTail()
        {
            throw new NotImplementedException();
        }



        public void RemoveAllNaw(NAW naw)
        {
            throw new NotImplementedException();
        }

        public NAW GetNawAt(int index)
        {
            throw new NotImplementedException();
        }

        public void SetNawAt(int index, NAW naw)
        {
            throw new NotImplementedException();
        }

        public void BubbleSort()
        {
            throw new NotImplementedException();
        }       

        public BigO OrderOfBubbleSort()
        {
            return BigO.One; // Pas de returnwaarde aan naar het juiste antwoord
        }


        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public Link Head()
        {
            return _first;
        }

        public Link Tail()
        {
            return _last;
        }

    }
}
