using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphStory.Client.Responses
{
    public enum ExportStatus
    {
        Running,
        Compressing,
        Uploading,
        Finished,
        Failed
    }

    public class ExportStatusResponse
    {
        public int DateTime { get; set; }
        public string DownloadUrl { get; set; }
        public ExportStatus Status { get; set; }
        public Guid Uuid { get; set; }
    }

    internal class ExportQueryResponseOuter : BaseResponse
    {
        public ExportStatusResponse Data { get; set; }
    }
}
