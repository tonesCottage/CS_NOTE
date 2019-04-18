using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ClassLibrary.Peking_Cs.p10
{
    class Xml_Xlst
    {
        static void Main()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@".\BookList.xml");
                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();
                XslTransform xt = new XslTransform();
                xt.Load(@".\BookList.xslt");
                XmlTextWriter writer = new XmlTextWriter(Console.Out);
                xt.Transform(nav, null, writer);
            }
            catch (XmlException e)
            {
                Console.WriteLine("XML Exception:" + e.ToString());
            }
            catch (XsltException e)
            {
                Console.WriteLine("XSLT Exception:" + e.ToString());
            }

        }
    }
}
