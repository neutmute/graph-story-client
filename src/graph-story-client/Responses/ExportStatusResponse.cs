using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphStory.Client
{
    public enum ExportStatus
    {
        Unknown,
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

        public override string ToString()
        {
            return $"Status={Status}, Uuid={Uuid}, DownloadUrl={DownloadUrl}";
        }
    }

    internal class ExportStatusResponseOuter : BaseResponse
    {
        public ExportStatusResponse Data { get; set; }
    }
}
