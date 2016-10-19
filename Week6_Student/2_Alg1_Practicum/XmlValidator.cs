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
    public class XmlValidator
    {

        public XmlValidator()
        {
        }

        //
        // Huiswerk methodes
        //

        public bool Validate(string xml)
        {
            List<string> xmlList = new List<string>();
            Stack xmlStack = new Stack();
            List<string> splitList = new List<string>();

            //Make list with first split
            xmlList = xml.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string item in xmlList)  //Fill the splitList with parts after 2nd split.
            {
                splitList.Add(item.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries).Last());
            }

            foreach (string item in splitList)//Read tag content
            {
                if (item.StartsWith("/"))//Check if it immediately starts with / 
                {
                    if (!xmlStack.IsEmpty())//If it is not empty Pop it. --> Else its wrong
                    {
                        String head = xmlStack.Pop();

                        if (!head.Equals(item.Remove(0, 1)))//If the Popped head is not the same as the first item it is wrong
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    xmlStack.Push(item);
                }
            }
            return xmlStack.IsEmpty();
        }
    }
}


