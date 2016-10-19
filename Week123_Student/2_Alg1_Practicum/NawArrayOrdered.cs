using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Exceptions;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawArrayOrdered : INawArrayOrdered, IBinarySearch
    {
        protected Alg1NawArray _nawArray;
        protected int _size;
        protected int _used;

        //
        // Workshop methodes
        //

        public NawArrayOrdered(int initialSize)
        {
            _size = initialSize;
            if (initialSize < 1 || initialSize > 1000000)
            {
                throw new NawArrayOrderedInvalidSizeException();
            }
            _nawArray = new Alg1NawArray(initialSize);
        }
        public virtual void Add(NAW item)
        {
            if (_used < _size)
            {
                int _insertIndex;
                for (_insertIndex = 0; _insertIndex < _used; _insertIndex++)
                {
                    if (item.CompareTo(_nawArray[_insertIndex]) == -1)
                    {
                        for (int j = _used; j > _insertIndex; j--)
                        {
                            _nawArray[j] = _nawArray[j - 1];
                        }
                        _nawArray[_insertIndex] = item;
                        _used++;
                        return;
                    }

                }
                _nawArray[_used] = item;
                _used++;
            }
            else
            {
                throw new NawArrayOrderedOutOfBoundsException();
            }
        }


        //
        // Huiswerk methodes
        //

        public void RemoveAtIndex(int index)
        {
            //Remove from array
            _nawArray[index] = null;
            //Loop through the list, if the next value is not empty move it one lower.
            for (int i = index; i < _used; i++)
            {
                if (_nawArray[i + 1] != null)
                {
                    _nawArray[i] = _nawArray[i + 1];
                }
            }
            _used--;
        }


        public int ItemCount()
        {
            return _used;
        }

        public int Find(NAW item)
        {
            throw new NotImplementedException();
        }


        public bool Update(NAW oldValue, NAW newValue)
        {
            throw new NotImplementedException();
        }

        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public void Show()
        {
            // Gebruikt om mee te testen

            System.Console.WriteLine("Array contains {0} of {1} items.", _used, _size);
            for (int i = 0; i < _size; i++)
            {
                if (i == _used)
                {
                    System.Console.WriteLine("------------------------------------------------------");
                }
                System.Console.Write("Item {0} contains: ", i);
                if (_nawArray[i] != null)
                {
                    _nawArray[i].Show();
                }
                else
                {
                    System.Console.WriteLine("nothing");
                }
            }
        }

        public Alg1NawArray Array
        {
            get { return _nawArray; }
            set { _nawArray = value; }
        }

        public int Count
        {
            // huiswerk 1.6
            get { return ItemCount(); }
            set { _used = value; }

        }



        public void AddBinary(NAW item)
        {
            throw new NotImplementedException();
        }

        public int FindBinary(NAW item)
        {
            int lowerBound = 0;
            int upperBound = _size - 1;
            int curIn;

            if (_used > 0)
            {
                while (true)
                {
                    curIn = (lowerBound + upperBound) / 2;
                    if (_nawArray[curIn] == item)
                    {
                        return curIn;
                    }
                    else if (lowerBound > upperBound)
                    {
                        return -1;
                    }
                    else
                    {
                        if (_nawArray[curIn].CompareTo(item) == -1)
                        {
                            lowerBound = curIn + 1;
                        }
                        else
                        {
                            upperBound = curIn - 1;
                        }
                    }
                }
            }
            else
            {
                return -1;
            }
        }
    }
}


