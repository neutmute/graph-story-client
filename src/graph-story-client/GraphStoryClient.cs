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
    /// <summary>
    /// Based off
    /// https://gist.github.com/funkatron/c8b88de350f628bc4a1f0568a06c51d1, revision 2
    /// </summary>
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
            var result = Get<InstancesResponseOuter>("/instances");
            return result.Data;
        }

        public ExportResponse Export(Instance instance)
        {
            var result = Post<ExportResponseOuter>($"/instances/{instance.Id}/export");
            var response = result.Data;
            response.Instance = instance; // Make it easy to rebuild the status request url
            return response;
        }

        public ExportStatusResponse GetExportStatus(ExportResponse exportResponse)
        {
            var result = Get<ExportStatusResponseOuter>($"/instances/{exportResponse.Instance.Id}/export/{exportResponse.ExportId}");
            return result.Data;
        }

        private TResponse Get<TResponse>(string command) where TResponse : BaseResponse
        {
            return GetResponse<TResponse>(command, DoGet);
        }

        private TResponse Post<TResponse>(string command) where TResponse : BaseResponse
        {
            return GetResponse<TResponse>(command, DoPost);
        }

        private TResponse GetResponse<TResponse>(string command, Func<HttpClient, string, string> clientAction) where TResponse : BaseResponse
        {
            TResponse result;
            string rawResult;
            using (var client = ClientFactory())
            {
                var uri = GetFullUri(command);
                rawResult = clientAction(client, uri);
                result = JsonConvert.DeserializeObject<TResponse>(rawResult);
            }

            if (result.Status != ResponseStatus.Success)
            {
                throw new Exception("Expected success but got: " + rawResult);
            }

            return result;
        }

        private string DoGet(HttpClient client, string fullUri)
        {
            return client.GetStringAsync(fullUri).Result;
        }

        private string DoPost(HttpClient client, string fullUri)
        {
            var postResult = client.PostAsync(fullUri, new StringContent(string.Empty)).Result;
            var responseContent = postResult.Content.ReadAsStringAsync().Result;
            return responseContent;
        }

        private string GetFullUri(string command)
        {
            var uri = ApiBaseUrl + command + $"?api_key={_config.ApiKey}";
            return uri;
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
