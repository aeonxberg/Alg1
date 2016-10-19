using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawBucketHashTable
    {
        public int Size { get; private set; }

        protected int _used = 0;
        protected Alg1HashItemArray<string, List<NAW>> _array;

        //
        // Huiswerk methodes
        //

        public bool Add(NAW naw)
        {
            
            if (_used == 0)
            {
                int key = Math.Abs((naw.Naam.GetHashCode()) % Size);
                List<NAW> bucket = new List<NAW>();
               bucket.Add(naw);

               _array[key].Key = naw.Naam;
               _array[key].Value = bucket;
               return true;
            }
            else if (Find(naw.Naam) != null)
            {
                List<NAW> foundList = Find(naw.Naam);
                foundList.Add(naw);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public List<NAW> Remove(string key)
        {
            throw new NotImplementedException();
            // Is key-waarde de _Array[i].key of is het de index?
        }

        public List<NAW> Find(string key)
        {
            throw new NotImplementedException();
            //Zie remove
        }


        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public NawBucketHashTable(int size)
        {
            _array = new Alg1HashItemArray<string, List<NAW>>(size);
            Size = size;
        }

        public int Count
        {
            get { return _used; }
            set { _used = value; }
        }


        public void Show()
        {
            System.Console.WriteLine();
            for (int i = 0; i < Size; i++)
            {
                System.Console.Write("Item [{0}] = ", i);
                if (_array[i] == null)
                {
                    System.Console.WriteLine("empty");
                }
                else
                {
                    if (_array[i].IsDeleted)
                    {
                        System.Console.WriteLine("Deleted Bucket");
                    }
                    else
                    {
                        System.Console.WriteLine("Bucket for key: \"{0}\"", _array[i].Key);
                        foreach (NAW entry in _array[i].Value)
                        {
                            entry.Show();
                        }
                    }
                }


            }
        }
    }


}
