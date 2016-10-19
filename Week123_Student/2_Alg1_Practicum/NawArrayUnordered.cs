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
    public class NawArrayUnordered : INawArrayUnordered, INawArrayUnordered_wk2, IBubbleSort, ISelectionSort, IInsertionSort
    {
        protected Alg1NawArray _nawArray;
        protected int _size;
        protected int _used;

        //
        // Workshop methodes
        //

        public NawArrayUnordered(int initialSize)
        {
            _size = initialSize;
            // throw new NotImplementedException();
            if (initialSize < 1 || initialSize > 1000000)
            {
                throw new NawArrayUnorderedInvalidSizeException();
            }
            _nawArray = new Alg1NawArray(initialSize);
        }

        public int ItemCount()
        {
            // throw new NotImplementedException();
            return _used;
        }

        public void Add(NAW item)
        {
            // throw new NotImplementedException();
            if (_used == _size)
            {
                throw new NawArrayUnorderedOutOfBoundsException();
            }
            if (_nawArray[_used] == null)
            {
                _nawArray[_used] = item;
                _used++;
            }
        }

        public int FindNaam(string gezochteNaam)
        {
            // throw new NotImplementedException();
            for (int i = 0; i < _size; i++)
            {
                if (_nawArray[i].HeeftNaam(gezochteNaam))
                {
                    return i;
                }
            }
            return -1;
        }

        //
        // Huiswerk methodes
        //

        public void RemoveAtIndex(int index)
        {
            throw new NotImplementedException();
        }

        public void RemoveFirstNaam(string gezochteNaam)
        {
            throw new NotImplementedException();
        }

        public void RemoveLastNaam(string gezochteNaam)
        {
            throw new NotImplementedException();
        }

        public int RemoveAllNaam(string gezochteNaam)
        {
            throw new NotImplementedException();
        }

        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public void Show()
        {
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
            get { return ItemCount(); }
            set { _used = value; }
        }

        public int FindNaw(NAW item)
        {
            throw new NotImplementedException();
        }


        public INawArrayOrdered ToNawArrayOrdered()
        {
            NawArrayOrdered newArray = new NawArrayOrdered(_used);

            for (int i = 0; i < _used; i++)
            {
                newArray.Add(_nawArray[i]);
            }

            return newArray;
        }

        public void BubbleSort()
        {

            Boolean flag = true;

            for (int i = 1; (i <= (_used - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (_used - 1); j++)
                {
                    if (_nawArray[j].CompareTo(_nawArray[j + 1]) > 0)
                    {
                        _nawArray.Swap(j, j + 1);
                        flag = true;
                    }
                }
            }
        }

        public void BubbleSortInverted()
        {
            Boolean flag = true;

            for (int i = _used - 1; (i > 0) && flag; i--)
            {
                flag = false;
                for (int j = _used - 1; j > 0; j--)
                {
                    if (_nawArray[j].CompareTo(_nawArray[j - 1]) < 0)
                    {
                        _nawArray.Swap(j, j - 1);
                        flag = true;
                    }
                }
            }
        }
        public void BubbleSortAlternative()
        {

            Boolean flag = true;

            for (int i = 1; (i <= (_used - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (_used - 1); j++)
                {
                    if (_nawArray[j].CompareTo(_nawArray[j + 1]) >= 0)
                    {
                        if (_nawArray[j].CompareTo(_nawArray[j + 1]) == 0)
                        {
                            Console.WriteLine("The object with Hashcode " + _nawArray[j].GetHashCode() + " is the same as " + _nawArray[j + 1].GetHashCode());
                        }
                        _nawArray.Swap(j, j + 1);
                        flag = true;
                        Console.WriteLine("Unstable will have swapped the above values, current order:" + _nawArray[j].GetHashCode() + " and " + _nawArray[j + 1].GetHashCode());
                    }
                }
            }
        }

        public void SelectionSort()
        {
            /*   repeat (numOfElements - 1) times
                 set the first unsorted element as the minimum
                 for each of the unsorted elements
                 if element < currentMinimum
                 set element as new minimum
                 swap minimum with first unsorted position
             */

            int curMin = 0;
            if (_nawArray != null)
            {
                for (int j = 0; j < _used; j++)
                {
                    curMin = j;
                    for (int i = j + 1; i < _used; i++)
                    {
                        if (_nawArray[i].CompareTo(_nawArray[curMin]) < 0)
                        {
                            curMin = i;
                        }
                    }
                    if (j != curMin)
                    {
                        _nawArray.Swap(j, curMin);
                    }

                }
            }
        }

        public void SelectionSortInverted()
        {
            int curMax = 0;
            if (_nawArray != null)
            {
                for (int j = _used - 1; j > 0; j--)
                {
                    curMax = j;
                    for (int i = 0; i < j; i++)
                    {
                        if (_nawArray[i].CompareTo(_nawArray[curMax]) > 0)
                        {
                            curMax = i;
                        }
                    }
                    if (j != curMax)
                    {
                        _nawArray.Swap(j, curMax);
                    }
                }
            }
        }

        public void InsertionSort()
        {
            int i = 0;
            int j = 0;

                for (i = 1; i < _used; i++)
                {
                    NAW toSort = _nawArray[i];
                    j = i;

                    while (j > 0 && _nawArray[j - 1].CompareTo(toSort) > 0)
                    {
                        _nawArray[j] = _nawArray[j - 1];
                        j--;
                    }
                    if (j != i)
                    {
                        _nawArray[j] = toSort;
                    }
                }
            }

        public void InsertionSortInverted()
        {
            if (_nawArray != null)
            {
                for (int i = _used - 2; i >= 0; i--)
                {
                    NAW toSort = _nawArray[i];
                    int j = 0;

                    while (j < _used-1 && _nawArray[j+1].CompareTo(toSort) <0)
                    {
                        _nawArray[j]=_nawArray[j+1];
                        j++;
                        }
                    if (j != i)
                    {
                        _nawArray[j] = toSort;
                    }
                    }
                }
            }
        }
    }
