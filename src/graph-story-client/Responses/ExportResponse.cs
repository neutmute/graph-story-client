using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphStory.Client;

namespace GraphStory.Client
{
    public class ExportResponse
    {
        public Instance Instance { get; set; }

        public string ExportId { get; set; }
        public int GraphId { get; set; }
        public string GraphName { get; set; }
        public string StatusUrl { get; set; }

        public override string ToString()
        {
            return $"ExportId='{ExportId}', GraphId='{GraphId}', GraphName='{GraphName}', StatusUrl='{StatusUrl}'";
        }
    }

    internal class ExportResponseOuter : BaseResponse
    {
        public ExportResponse Data { get; set; }
    }
}
