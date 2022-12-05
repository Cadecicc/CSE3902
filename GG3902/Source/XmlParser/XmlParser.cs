using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace GG3902
{
    public class XmlParser
    {
        private Type[] types;

        public XmlParser(Type[] types)
        {
            this.types = types;
        }

        // Given an Xml file path, generates and returns a list of objects.
        public List<object> CreateObjectsFromXml(string filePath)
        {
            List<object> objects = new List<object>();
            XmlReader reader = XmlReader.Create(filePath);

            try
            {
                // Ensure there is an objects node in the Xml doc
                while (reader.Read())
                    if (reader.Name.Equals("objects"))
                        break;

                while (reader.Read())
                {
                    // Read until the end of the objects node
                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("objects"))
                        break;
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;

                    // If the current node is an element, it must be an object
                    XElement subtree = XElement.Load(reader.ReadSubtree());
                    if (TryGetType(subtree.Name.LocalName, out Type type))
                        objects.Add(CreateObjectFromElement(subtree, type));
                }
            }
            finally
            {
                reader.Close();
            }

            return objects;
        }

        // Given an XElement and a Type, this function returns a new object of that Type loaded with info from the XElement.
        private object CreateObjectFromElement(XElement element, Type type)
        {
            object obj;

            // Grabs the first constructor of the identified object type
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            ParameterInfo[] paramInfo = constructorInfo[0].GetParameters();
            object[] parameters = new object[paramInfo.Length];
            Dictionary<string, string> elementChildValues = new Dictionary<string, string>();

            // Add child values into dictionary to be loaded into parameters
            foreach (XElement child in element.Elements())
            {
                string key = Normalize(child.Name.LocalName, true);
                string value = Normalize(child.Value);
                elementChildValues.Add(key, value);
            }

            // Match elements with required parameters
            for (int i = 0; i < paramInfo.Length; i++)
            {
                ParameterInfo pInfo = paramInfo[i];
                string paramName = Normalize(pInfo.Name, true);
                if (!elementChildValues.TryGetValue(paramName, out string paramValue))
                    continue;

                parameters[i] = StringConversion.ConvertFromToString(paramValue, pInfo.ParameterType);
            }

            obj = constructorInfo[0].Invoke(parameters);
            return obj;
        }

        // Matches a string to a Type in the local array of types. Returns true if a match is found.
        private bool TryGetType(string name, out Type type, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            type = null;
            foreach (Type curr in types)
            {
                if (string.Equals(curr.Name, name, comparisonType))
                {
                    type = curr;
                    return true;
                }
            }
            return false;
        }

        // Returns a lowercase (optional) string containing no tabs, newlines, extra whitespace, etc.
        private string Normalize(string str, bool toLower = false)
        {
            Regex regex = new Regex(@"[ ]{2,}", RegexOptions.None);
            str = regex.Replace(str, @" ");
            str = str.Trim().Replace("\n", "").Replace("\t", "");
            if (toLower)
                str = str.ToLower();
            return str;
        }
    }
}