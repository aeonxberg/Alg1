using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawDoublyLinkedList : IBubbleSort
    {

        public DoubleLink First { get; set; }
        public DoubleLink Last { get; set; }

        //
        // Workshop methodes
        //

        public void InsertHead(NAW naw)
        {
            DoubleLink newLink = new DoubleLink();
            newLink.Naw = naw;

            if (First == null)
            {
                First = newLink;
                Last = newLink;
            }
            else
            {
                newLink.Next = First;
                First.Previous = newLink;
                First = newLink;
            }

        }

        public DoubleLink SwapLinkWithNext(DoubleLink link)
        {
            if (link == Last) return null;

            DoubleLink nextLink = link.Next;
            DoubleLink secondNextLink = nextLink.Next;
            DoubleLink prevLink = link.Previous;

            if (link == First)
            {
                secondNextLink.Previous = link;

                link.Next = secondNextLink;
                link.Previous = nextLink;

                nextLink.Next = link;
                nextLink.Previous = null;

                First = nextLink;
            }
            else if (link.Next == Last)
            {
                link.Next = null;
                link.Previous = nextLink;

                nextLink.Next = link;
                nextLink.Previous = prevLink;

                prevLink.Next = nextLink;
                Last = link;
            }
            else
            {
                secondNextLink.Previous = link;

                link.Next = secondNextLink;
                link.Previous = nextLink;

                nextLink.Next = link;
                nextLink.Previous = prevLink;

                prevLink.Next = nextLink;
            }

            return nextLink;
        }


        //
        // Huiswerk methodes
        //

        public void BubbleSort()
        {
            if(First == null && Last == null)
            {
                return;
            }
            DoubleLink outerLink = First;
            while (outerLink != null)
            {
                DoubleLink innerLink = First;
                while (innerLink != null)
                {
                    DoubleLink useLink = innerLink;
                    DoubleLink nextLink = innerLink.Next;
                    if (nextLink != null)
                    {
                        if (useLink.Naw.CompareTo(nextLink.Naw) > 0)
                        {
                            SwapLinkWithNext(useLink);
                        }
                        innerLink = innerLink.Next;
                    }
                    else
                    {
                        break;
                    }
                }
                    outerLink = outerLink.Next;
            }
        }

        public BigO OrderOfBubbleSort()
        {
            return BigO.N2;
            // Loop in a loop, no more loops in methods.
        }

        //
        //  Onderstaande methode hoef je niet te implementeren maar hoort wel bij de IBubbleSort interface
        //

        public void BubbleSortInverted()
        {
            throw new NotImplementedException();
        }
    }
}
