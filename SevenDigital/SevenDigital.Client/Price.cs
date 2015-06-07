using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDigital.Client
{
    public class Price
    {
        public decimal Value { get; set; }
        public string FormattedPrice { get; set; }
        public bool OnSale { get; set; }
    }
}
