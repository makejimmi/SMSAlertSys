using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SMSAlertSys
{
    public class xmlFile
    {
        public xmlFile() 
        {
        }

        public static XDocument loadXmlFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    XDocument xDocument = XDocument.Load(filename);
                    return xDocument;
                }
                else 
                {
                    return null;
                }
            }
            catch ( Exception e ) 
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static void writeDataXml(XDocument doc, string filename, string title, int passed, DateTime date, DateTime startTime, DateTime endTime,
            string trigger, string notes, string mail, string nr)
        {
            try
            {
                int nullCheck = 0;

                if (doc == null)
                {
                    doc = new XDocument(
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XComment("Some title"),
                        new XElement("Root"));
                }
                else
                {
                    XElement lastEvent = doc.Root.Elements("Event").LastOrDefault();
                    if (lastEvent != null)
                    {
                        nullCheck = int.Parse(lastEvent.Attribute("Nr").Value) + 1;
                    }
                }

                doc.Root.Add(
                    new XElement("Event", new XAttribute("Nr", nullCheck),
                        new XElement("Title", title),
                        new XElement("Passed", passed.ToString()),
                        new XElement("Date", date.ToString()),
                        new XElement("Start", startTime.ToString()),
                        new XElement("End", endTime.ToString()),
                        new XElement("Trigger", trigger),
                        new XElement("Notes", notes),
                        new XElement("Email", mail),
                        new XElement("PhoneNr", nr)
                        )
                    );

                doc.Save(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //  GlobalVars.sc.addData(this._title, this._passed, this._date, this.startTime, this.endTime,
        //          GlobalVars.chosenTrigger.ToString(), this._notes, this._email, this._phonenr);

        //public void TaskGenerator()
        //{
        //    TaskXMLWriter("false");
        //    //if (!TaskAlreadyGenerated())
        //    //{
        //    //    TaskXMLWriter("true");
        //    //    MessageBox.Show("Task has been generated.\nSee Windows Task Scheduler.");
        //    //}
        //    //else MessageBox.Show("Task has already been generated. DELETE THIS MESSAGEBOX AFTERWARDS");
        //}

        //private bool TaskAlreadyGenerated()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load("C:\\Study\\all I know about SQL\\SMSAlertSys\\SMSAlertSys\\config.xml");
        //    string xmlString = doc.InnerXml;

        //    if (xmlString != null)
        //    {
        //        XmlElement root = doc.DocumentElement;
        //        XmlNodeList nodes = root.GetElementsByTagName("xmlGenerated");

        //        foreach (XmlNode node in nodes)
        //        {
        //            if (node.InnerText.Contains("true"))
        //            {
        //                Console.WriteLine(node.InnerText);
        //                return true;
        //            }
        //            else
        //            {
        //                TaskXMLWriter("false");
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private void TaskXMLWriter(string binValue)
        //{
        //    XmlDocument doc = new XmlDocument();

        //    //(1) the xml declaration is recommended, but not mandatory
        //    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        //    XmlElement root = doc.DocumentElement;
        //    doc.InsertBefore(xmlDeclaration, root);

        //    //(2) string.Empty makes cleaner code
        //    XmlElement element1 = doc.CreateElement(string.Empty, "body", string.Empty);
        //    doc.AppendChild(element1);

        //    XmlElement element2 = doc.CreateElement(string.Empty, "conf", string.Empty);
        //    element1.AppendChild(element2);

        //    XmlElement element3 = doc.CreateElement(string.Empty, "xmlGenerated", string.Empty);
        //    XmlText text1 = doc.CreateTextNode(binValue);
        //    element3.AppendChild(text1);
        //    element2.AppendChild(element3);

        //    doc.Save("C:\\Study\\all I know about SQL\\SMSAlertSys\\SMSAlertSys\\config.xml");
        //}
    }


}
