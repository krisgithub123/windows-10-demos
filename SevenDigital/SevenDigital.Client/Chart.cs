using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenDigital.Client
{
    public class Chart
    {
        [JsonProperty("fromDate")]
        public DateTimeOffset From { get; set; }

        [JsonProperty("toDate")]
        public DateTimeOffset To { get; set; }

        [JsonProperty("chartItem")]
        public IReadOnlyList<ChartItem> Items { get; set; }
    }
}
