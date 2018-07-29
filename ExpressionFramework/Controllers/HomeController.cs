using ExpressionFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ExpressionFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\sunny\source\repos\ExpressionFramework\ExpressionFramework\Content\XMLFile1.xml");
            Node rootNode = ReadNodes(xml.ChildNodes[1]);
            HomeViewModel vm = new HomeViewModel();
            vm.Node = rootNode;
            return View(vm);
        }

        private Node ReadNodes(XmlNode xmlNode)
        {
            Node localNode = new Node();

            localNode.name = Convert.ToString(xmlNode.Attributes["name"].Value);
            localNode.isList = Convert.ToBoolean(xmlNode.Attributes["isList"].Value);
            localNode.isProcessable = Convert.ToBoolean(xmlNode.Attributes["isProcessable"].Value);
            localNode.type = Convert.ToString(xmlNode.Attributes["type"].Value);

            if (xmlNode.HasChildNodes)
            {
                localNode.ChildNodes = new List<Node>();
                foreach (XmlNode item in xmlNode.ChildNodes)
                {
                    localNode.ChildNodes.Add(ReadNodes(item));
                }
            }

            return localNode;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}