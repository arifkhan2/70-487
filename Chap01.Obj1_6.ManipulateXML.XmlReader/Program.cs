using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

//Chapter 01: Accessing Data
//Objective 1.6: Manipulate XML data structures
//Topic: XmlDocument class - write capabilities
//Source reference: https://msdn.microsoft.com/en-us/library/fw1ys7w6(v=vs.110).aspx

namespace Chap01.Obj1_6.ManipulateXML.XmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();
            String xmlString =
                 @"<bookstore>
                    <book genre='autobiography' publicationdate='1981-03-22' ISBN='1-861003-11-0'>
                        <title>The Autobiography of Benjamin Franklin</title>
                        <author>
                            <first-name>Benjamin</first-name>
                            <last-name>Franklin</last-name>
                        </author>
                        <price>8.99</price>
                    </book>
                </bookstore>";
            using (System.Xml.XmlReader reader = System.Xml.XmlReader.Create(new StringReader(xmlString)))
            {
                reader.ReadToFollowing("book");
                reader.MoveToFirstAttribute();
                string genre = reader.Value;
                Console.WriteLine("The genre value: " + genre);

                reader.ReadToFollowing("title");
                Console.Write("contents of the title element:" + reader.ReadElementContentAsString());
            }
            Console.ReadLine();
        }
    }
}
