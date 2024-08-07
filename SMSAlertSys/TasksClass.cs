using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SMSAlertSys
{
    internal class TasksClass
    {
        public void TaskGenerator()
        {
            TaskXMLWriter("false");
            if (!TaskAlreadyGenerated())
            {
                TaskXMLWriter("true");
                MessageBox.Show("Task has been generated");
            }
            else MessageBox.Show("Task has already been generated. DELETE THIS MESSAGEBOX AFTERWARDS");
        }

        private bool TaskAlreadyGenerated() 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Study\\all I know about SQL\\SMSAlertSys\\SMSAlertSys\\config.xml");
            string xmlString = doc.InnerXml;

            if (xmlString != null)
            {
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.GetElementsByTagName("xmlGenerated");

                foreach (XmlNode node in nodes)
                {
                    if (node.InnerText.Contains("true"))
                    {
                        Console.WriteLine(node.InnerText);
                        return true;
                    }
                    else
                    {
                        TaskXMLWriter("false");
                    }
                }
            }
            return false;
        }

        private void TaskXMLWriter(string binValue)
        {
            XmlDocument doc = new XmlDocument();

            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //(2) string.Empty makes cleaner code
            XmlElement element1 = doc.CreateElement(string.Empty, "body", string.Empty);
            doc.AppendChild(element1);

            XmlElement element2 = doc.CreateElement(string.Empty, "conf", string.Empty);
            element1.AppendChild(element2);

            XmlElement element3 = doc.CreateElement(string.Empty, "xmlGenerated", string.Empty);
            XmlText text1 = doc.CreateTextNode(binValue);
            element3.AppendChild(text1);
            element2.AppendChild(element3);

            doc.Save("C:\\Study\\all I know about SQL\\SMSAlertSys\\SMSAlertSys\\config.xml");
        }
    }
}
