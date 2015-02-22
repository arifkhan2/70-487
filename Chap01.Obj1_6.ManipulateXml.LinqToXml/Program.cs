using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
//Chapter 01: Accessing Data
//Objective 1.6: Manipulate XML data structures
//Topic: LINQ-to-XML
//Source reference: hhttps://msdn.microsoft.com/en-us/library/bb387085.aspx

namespace Chap01.Obj1_6.ManipulateXml.LinqToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement contacts = 
                   new XElement("Contacts",
                       new XElement("Contact",
                           new XElement("Name", "Patrick Hines"),
                           new XElement("Phone", "206-555-0144"),
                           new XElement("Address",
                               new XElement("Street1", "123 Main St"),
                               new XElement("City", "Mercer Island"),
                               new XElement("State", "WA"),
                               new XElement("Postal","60042")
                               )
                           )
                       );
            Console.WriteLine(contacts);
            Console.ReadLine();
        }
    }
}
