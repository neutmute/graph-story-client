using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
            GetInstancesResponse result;

            using (var client = new HttpClient())
            {
                var uri = ApiBaseUrl + "/instances" + $"?api_key={_config.ApiKey}";
                var rawResult = client.GetStringAsync(uri).Result;
                result = JsonConvert.DeserializeObject<GetInstancesResponse>(rawResult);
            }

            return result.Data;
        }
    }
}
