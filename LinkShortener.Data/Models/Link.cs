using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Data.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string OriginalLink { get; set; }
        public string ShortenedLink { get; set; }
    }
}
