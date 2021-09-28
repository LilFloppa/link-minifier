using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkShortener.WebUI.Models
{
    public class Link
    {
        public string OriginalLink { get; set; }
        public string ShortenedLink { get; set; }
    }
}
