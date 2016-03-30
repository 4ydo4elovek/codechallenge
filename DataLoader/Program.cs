using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Threading;
using System.Xml;
using Entities;
using ServiceLayer;

namespace DataLoader
{
    internal class Program
    {
        private static void Main()
        {
            var nodes = LoadNodes();
            var data = new DataNodeService();
            data.SaveNodes(nodes);

            var algo = new AlgorithmService();
            algo.GetShortestPath(9, 7);

            var t = new Thread(Run);
            t.IsBackground = false;
            t.Start();

            using (var host = new ServiceHost(typeof(ClientNodeService)))
            {
                host.Open();

                Console.WriteLine("--------------------------------");
                Console.WriteLine("Host with data started...");
                Console.WriteLine("--------------------------------");

                var s = string.Empty;
                do
                {
                    Console.WriteLine("1. Restart folder.");
                    Console.WriteLine("2. Exit.");
                    s = Console.ReadLine();
                    switch (s)
                    {
                        case "1":
                            data.SaveNodes(LoadNodes());
                            break;
                    }
                } while (s != "1" && s != "2");
            }
        }

        public static void Run()
        {
            using (var host = new ServiceHost(typeof (AlgorithmService)))
            {
                host.Open();

                Console.WriteLine("--------------------------------");
                Console.WriteLine("Host with algroritm started...");
                Console.WriteLine("--------------------------------");
                Console.ReadLine();
            }
        }

        private static IList<Node> LoadNodes()
        {
            DirectoryInfo dir = null;
            do
            {
                Console.WriteLine("Specify path to the directory:");
                var path = Console.ReadLine();

                path = @"C:\Work\CodeChallenge\codechallenge\nodes\";

                if (!string.IsNullOrEmpty(path))
                {
                    dir = new DirectoryInfo(path);
                }
            } while (!dir.Exists);

            var list = new List<Node>();

            foreach (var xml in dir.GetFiles("*.xml"))
            {
                var node = new Node();

                var doc = new XmlDocument();
                doc.Load(xml.FullName);
                foreach (XmlNode xnode in doc.DocumentElement.ChildNodes)
                {
                    if (xnode.Name == "id")
                    {
                        node.IdUnique = xnode.InnerText;
                    }
                    else if (xnode.Name == "label")
                    {
                        node.Label = xnode.InnerText;
                    }
                    else if (xnode.Name == "adjacentNodes")
                    {
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            node.Lines.Add(new Line
                            {
                                NodeIdFromUnique = node.IdUnique,
                                NodeIdToUnique = childNode.InnerText
                            });
                        }
                    }
                }

                list.Add(node);
            }

            return list;
        }
    }
}
