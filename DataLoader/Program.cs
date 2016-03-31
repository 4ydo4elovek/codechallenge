using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Line = Entities.Line;
using Node = Entities.Node;

namespace DataLoader
{
    internal class Program
    {
        private static DataNodeServiceClient.DataNodeServiceClient dataClient;

        private static void Main()
        {
            var nodes = LoadNodes();

            using (var client = new DataNodeServiceClient.DataNodeServiceClient("BasicHttpBinding_IDataNodeService"))
            {
                Console.WriteLine("Data host started...");
                Console.WriteLine("--------------------------------");

                client.SaveNodes(nodes.ToArray());

                var s = string.Empty;
                do
                {
                    Console.WriteLine("1. Restart folder.");
                    Console.WriteLine("2. Exit.");
                    s = Console.ReadLine();
                    switch (s)
                    {
                        case "1":
                            nodes = LoadNodes();
                            client.SaveNodes(nodes.ToArray());;
                            Console.WriteLine("-Success-");
                            break;
                    }
                } while (s != "2");
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
