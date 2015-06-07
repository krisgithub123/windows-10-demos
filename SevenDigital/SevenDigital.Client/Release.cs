using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDigital.Client
{
    public class Release
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public Artist Artist { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Type { get; set; }
        public Price Price { get; set; }
        public int Duration { get; set; }
        public int TrackCount { get; set; }
    }
}
