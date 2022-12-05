using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using GG3902;

namespace Testing
{
    public static class TestMain
    {
        public static void Main(string[] args)
        {
            XmlParser test = new XmlParser(new Type[] { typeof(Book) });
            List<object> objects = test.CreateObjectsFromXml(XmlParserTest.TestDataPath + "books.xml");

            Console.WriteLine("Objects :");
            foreach(object obj in objects)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
