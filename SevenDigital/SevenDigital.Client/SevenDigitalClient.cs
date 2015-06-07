using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SevenDigital.Client
{
    public class SevenDigitalClient : ISevenDigitalClient
    {
        private const string ConsumerKey = "7d8g36wvf8cy";
        private const int PageSize = 20;

        private HttpClient httpClient;

        public SevenDigitalClient()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
            };

            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://api.7digital.com")
            };

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        }

        private async Task<T> SendAsync<T>(string path, IDictionary<string, string> parameters)
        {
            parameters.Add("country", "NZ");
            parameters.Add("oauth_consumer_key", ConsumerKey);

            var queryString = String.Join("&", parameters.Select(v => String.Format("{0}={1}", Uri.EscapeUriString(v.Key), Uri.EscapeUriString(v.Value))));

            var uri = String.Concat(path, "?", queryString);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            
            var response = await httpClient.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<Chart> GetReleaseChartAsync()
        {
            var results = await SendAsync<ChartRepsonse>("/1.2/release/chart", new Dictionary<string, string>
            {
                { "pageSize", PageSize.ToString() },
                { "imageSize", "200" }
            });

            return results.Chart;
        }

        public async Task<Release> GetReleaseDetailsAsync(int releaseId)
        {
            var results = await SendAsync<ReleaseResponse>("/1.2/release/details", new Dictionary<string, string>
            {
                { "releaseId", releaseId.ToString() },
                { "imageSize", "200" }
            });

            return results.Release;
        }

        public async Task<Artist> GetArtistDetailsAsync(int artistId)
        {
            var results = await SendAsync<ArtistResponse>("/1.2/artist/details", new Dictionary<string, string>
            {
                { "artistId", artistId.ToString() },
                { "imageSize", "200" }
            });

            return results.Artist;
        }
    }
}
