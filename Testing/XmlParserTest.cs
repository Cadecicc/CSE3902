using Microsoft.VisualStudio.TestTools.UnitTesting;
using GG3902;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace Testing
{
    [TestClass]
    public class XmlParserTest
    {
        public static readonly string TestDataPath;
        private static XmlParser Parser;

        static XmlParserTest()
        {
            string workingDirectory = Environment.CurrentDirectory;
            TestDataPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "/TestData/";
            Parser = null;
        }

        [TestMethod]
        public void CreateListOfObjects()
        {
            List<object> expectedObjects = new List<object>
            {
                new Book("bk101", "Gambardella, Matthew", "XML Developer's Guide", "Computer", 44.95d, "2001-10-01", "An in-depth look at creating applications with XML.")
            };
            List<object> objects = Parser.CreateObjectsFromXml(TestDataPath + "one_book.xml");
            Assert.IsTrue(expectedObjects.SequenceEqual(objects), "Expected : {" + string.Join(", ", expectedObjects.ToArray()) + "}\nActual : {" + string.Join(", ", objects.ToArray()) + "}");
        }
    }
}
