using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractZeefLinks.Models
{
    [Serializable]
    public class LinkBlock
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public IEnumerable<LinkPosition> LinkPositions { get; set; }
    }
}
