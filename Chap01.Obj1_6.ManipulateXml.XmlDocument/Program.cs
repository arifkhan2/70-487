using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Chapter 01: Accessing Data
//Objective 1.6: Manipulate XML data structures
//Topic: XmlDocument class - write capabilities
//Source reference: https://msdn.microsoft.com/en-us/library/fw1ys7w6(v=vs.110).aspx


namespace Chap01.Obj1_6.ManipulateXml.XmlDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                        "<title>Pride and Prejudice</title>" +
                        "</book>");

            System.Xml.XmlElement elem = doc.CreateElement("price");
            System.Xml.XmlText text = doc.CreateTextNode("19.95");
            doc.DocumentElement.AppendChild(elem);
            doc.DocumentElement.LastChild.AppendChild(text);

            Console.WriteLine("display the modified xml..");
            doc.Save(Console.Out);

            Console.ReadLine();
        }
       
    }
}
