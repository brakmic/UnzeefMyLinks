using ExtractZeefLinks.Models;
using ExtractZeefLinks.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExtractZeefLinks
{
    class Program
    {
        static void Main(string[] args)
        {
            //USAGE: extractlinks.exe [path-to-extracted-Zeef-XML]
            if (args == null || args.Length < 1
                || !File.Exists(args[0]))
            {
                throw new ArgumentException("No XML-filename provided or file not existing.");
            }
            string fileName = args[0];
            //read whole document as XML
            var xdoc = XDocument.Load(new FileStream(fileName, FileMode.Open));
            if(xdoc != null)
            {
                var blocks = XmlParser.GetLinkBlocks(xdoc);
                //iterate over "blocks" & extract links
                foreach (var block in blocks)
                {
                    Console.WriteLine(string.Format("\r\nBLOCK: {0}, LINKS: {1}\r\n", 
                                                                    block.Title, 
                                                                    block.LinkPositions.Count()));
                    Console.WriteLine("*************************************\r\n");
                    int counter = 1;
                    foreach (var linkPos in block.LinkPositions)
                    {
                        Console.WriteLine(string.Format("{0} : TITLE: {1}, URL: {2}", 
                                                    counter++,
                                                    linkPos.Link.DefaultTitle, 
                                                    linkPos.Link.TargetUrl));
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
