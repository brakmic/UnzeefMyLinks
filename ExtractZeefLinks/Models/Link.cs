using System;

namespace ExtractZeefLinks.Models
{
    [Serializable]
    public class Link
    {
        public long Id { get; set; }
        public string DefaultTitle { get; set; }
        public string Description { get; set; }
        public string TargetUrl { get; set; }
    }
}
