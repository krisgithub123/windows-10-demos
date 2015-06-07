using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDigital.Client
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppearsAs { get; set; }
        public string Image { get; set; }
        public Biography Bio { get; set; }
    }
}
