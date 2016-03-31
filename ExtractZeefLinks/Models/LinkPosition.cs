using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractZeefLinks.Models
{
    [Serializable]
    public class LinkPosition
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Link Link { get; set; }
    }
}
