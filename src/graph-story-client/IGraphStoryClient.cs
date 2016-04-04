using System.Collections.Generic;
using GraphStory.Client.Responses;

namespace GraphStory.Client
{
    public interface IGraphStoryClient
    {
        List<Instance> GetInstances();
        ExportResponse Export(Instance instance);
        ExportStatusResponse GetExportStatus(ExportResponse exportResponse);
    }
}