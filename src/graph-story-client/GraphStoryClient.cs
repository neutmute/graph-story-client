using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GraphStory.Client.Responses;
using Newtonsoft.Json;

namespace GraphStory.Client
{
    public class GraphStoryClient : IGraphStoryClient
    {
        private IGraphStoryClientConfig _config;
        const string ApiBaseUrl = "https://console.graphstory.com/public/api/v0";

        public GraphStoryClient(IGraphStoryClientConfig config)
        {
            _config = config;
        }

        public List<Instance> GetInstances()
        {
            var result = GetResponse<GetInstancesResponse>("/instances");
            return result.Data;
        }

        private TResponse GetResponse<TResponse>(string command) where TResponse : BaseResponse
        {
            TResponse result;
            string rawResult;
            using (var client = ClientFactory())
            {
                var uri = GetFullUri(command);
                rawResult = client.GetStringAsync(uri).Result;
                result = JsonConvert.DeserializeObject<TResponse>(rawResult);
            }

            if (result.Status != ResponseStatus.Success)
            {
                throw new Exception("Expected success but got: " + rawResult);
            }

            return result;
        }

        private string GetFullUri(string command)
        {
            var uri = ApiBaseUrl + command + $"?api_key={_config.ApiKey}";
            return uri;
        }

        public ExportResponse Export()
        {
            return null;
        }

        public ExportStatusResponse GetExportStatus()
        {
            return null;
        }

        private HttpClient ClientFactory()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.Proxy = new WebProxy(_config.ProxyUri, false);
            httpClientHandler.UseProxy = !string.IsNullOrWhiteSpace(_config.ProxyUri);

            var client = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };

            return client;
        }
    }
}
