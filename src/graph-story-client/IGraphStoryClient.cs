using System.Collections.Generic;
using System.Net.Http;
using GraphStory.Client;

namespace GraphStory.Client
{
    public interface IGraphStoryClient
    {
        List<Instance> GetInstances();
        ExportResponse Export(Instance instance);
        ExportStatusResponse GetExportStatus(ExportResponse exportResponse);

        HttpClient CreateHttpClient();
    }
}