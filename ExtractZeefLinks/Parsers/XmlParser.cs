using ExtractZeefLinks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExtractZeefLinks.Parsers
{
    /// <summary>
    /// A simple `parser` that uses LINQ-to-XML to extract links and descriptions from exported Zeef-XML
    /// </summary>
    public class XmlParser
    {
        /// <summary>
        /// Returns a list of LinkBlocks
        /// </summary>
        /// <param name="xdoc">XDocument instance representing the exported Zeef-XML</param>
        /// <returns>A collection of LinkBlocks</returns>
        public static IEnumerable<LinkBlock> GetLinkBlocks(XDocument xdoc)
        {
            if(xdoc == null)
            {
                throw new NullReferenceException("No valid XML document provided!");
            }
            IEnumerable<LinkBlock> blocks = from el in xdoc.Descendants("linkBlocks").Elements("linkBlock")
                                            select new LinkBlock
                                            {
                                                Id = long.Parse(el.Element("id").Value),
                                                LastModified = DateTimeOffset.Parse(el.Element("lastModified").Value),
                                                LinkPositions = GetLinkPositions(el.Descendants("linkPositions")),
                                                Title = el.Element("title").Value
                                            };
            return blocks;
        }
        /// <summary>
        /// Returns a list of LinkPositions
        /// </summary>
        /// <param name="xelems">XElement collection representing the LinkPosition collection</param>
        /// <returns>A collection of LinkPositions</returns>
        public static IEnumerable<LinkPosition> GetLinkPositions(IEnumerable<XElement> xelems)
        {
            List<LinkPosition> positions = new List<LinkPosition>();
            foreach (var el in xelems.Descendants("linkPosition"))
            {
                if (el != null)
                {
                    LinkPosition position = new LinkPosition
                    {
                        Id = long.Parse(el.Element("id").Value),
                        Link = GetLink(el.Element("link")),
                        Title = el.Element("title").Value
                    };
                    positions.Add(position);
                }
            }
            return positions;
        }
        /// <summary>
        /// Returns a single Link
        /// </summary>
        /// <param name="xelem">Raw XElement</param>
        /// <returns>Type-safe Link element</returns>
        public static Link GetLink(XElement xelem)
        {
            if(xelem == null)
            {
                return null;
            }
            return new Link
            {
                DefaultTitle = xelem.Element("defaultTitle").Value,
                Description = xelem.Element("description").Value,
                Id = long.Parse(xelem.Element("id").Value),
                TargetUrl = xelem.Element("targetURL").Value
            };
        }
    }
}
