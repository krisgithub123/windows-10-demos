using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDigital.Client
{
    public class ReleaseResponse
    {
        public string Status { get; set; }
        public string Version { get; set; }
        public Release Release { get; set; }
    }
}
