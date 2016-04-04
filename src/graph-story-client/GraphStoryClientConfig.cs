using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphStory.Client
{
    public interface IGraphStoryClientConfig
    {
        string ApiKey { get; set; }   
    }

    public class GraphStoryClientConfig : IGraphStoryClientConfig
    {
        public string ApiKey { get; set; }
        
    }
}
