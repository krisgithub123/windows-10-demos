using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDigital.Client
{
    public class ArtistResponse
    {
        public string Status { get; set; }
        public string Version { get; set; }
        public Artist Artist { get; set; }
    }
}
