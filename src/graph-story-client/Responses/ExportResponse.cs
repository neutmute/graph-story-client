using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphStory.Client.Responses
{
    public class ExportResponse
    {
        public string ExportId { get; set; }
        public int GraphId { get; set; }
        public string GraphName { get; set; }
        public string StatusUrl { get; set; }

        public override string ToString()
        {
            return $"ExportId='{ExportId}', GraphId='{GraphId}', GraphName='{GraphName}'";
        }
    }

    internal class ExportResponseOuter
    {
        public ExportResponse Data { get; set; }
    }
}
