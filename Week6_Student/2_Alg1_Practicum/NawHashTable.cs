using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawHashTable
    {

        public int Size { get; private set; }

        protected int _used = 0;
        protected Alg1HashItemArray _array;

        //
        // Workshop methodes
        //
        virtual public bool Add(NAW naw)
        {
            /*-Als	deze	plek	al	bezet	is	ga	je	via	linear	probing op	zoek	naar	de	eerstvolgende	
                geschikte index.	
              -De	methode	retourneert	een	boolean	die	aangeeft	of	het	element	geplaatst	kon	
                worden.
              -Het	is	toegestaan	om	meerdere	NAW		objecten	met	dezelfde	naam	(een dus	key)	
               toe	te	voegen.*/

            int newHash = naw.Naam.GetHashCode(); //Something something % modulo

            if (_array == null)
            {
                _array = new Alg1HashItemArray(10);
            }
            int index = Math.Abs(newHash % Size);
            int originalIndex = index;

            HashItem newItem = new HashItem(naw.Naam, naw);
            bool inserted = false;

            while (!inserted)
            {
                if (_array.Size == _used)
                {
                    break;
                }
                if (_array[index] == null || _array[index].IsDeleted)
                {
                    _array[index] = newItem;
                    _used++;
                    inserted = true;
                }
                if (index >= _array.Size - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                    if (originalIndex == index)
                    {
                        break;
                    }
                }
            }
            return inserted;
        }


        public NAW Find(string naam)
        {
            int newHash = naam.GetHashCode(); //Something something % modulo

            if (_array == null)
            {
                return null;
            }

            int index = Math.Abs(newHash % Size);
            int originalIndex = index;
            NAW foundItem = null;

            while (foundItem == null)
            {
                if (_array[index] != null && !_array[index].IsDeleted)
                {
                    if (_array[index].Value.Naam.Equals(naam))
                    {
                        foundItem = _array[index].Value;
                    }
                }
                index++;
                if (index > _array.Size - 1)
                {
                    index = 0;
                }
                if (index == originalIndex)
                {
                    break;
                }
            }
            return foundItem;
        }

        //
        // Huiswerk methodes
        //

        public NAW Remove(string key)
        {
            int index = Math.Abs(key.GetHashCode() % Size);

            if (_array[index] == null)
            {
                return null;
            }
            else
            {
                _array[index].IsDeleted = true;
            }
            return _array[index].Value;
        }


        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public NawHashTable(int size)
        {
            _array = new Alg1HashItemArray(size);
            Size = size;
        }

        public int Count
        {
            get { return _used; }
            set { _used = value; }
        }

        public void Show()
        {
            for (int i = 0; i < Size; i++)
            {
                System.Console.Write("Item [{0}] = ", i);
                if (_array[i] == null)
                {
                    System.Console.WriteLine("empty");
                }
                else
                {
                    _array[i].Show();
                }


            }
        }
    }
}
