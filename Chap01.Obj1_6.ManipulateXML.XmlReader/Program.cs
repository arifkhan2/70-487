using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
