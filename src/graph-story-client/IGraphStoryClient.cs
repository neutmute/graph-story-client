using System.Collections.Generic;

namespace GraphStory.Client
{
    public interface IGraphStoryClient
    {
        List<Instance> GetInstances();
    }
}