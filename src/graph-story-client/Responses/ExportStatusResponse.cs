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

    public class ExportStatusResponseCore
    {
        public string DownloadUrl { get; set; }
        public ExportStatus Status { get; set; }
        public Guid Uuid { get; set; }

        public override string ToString()
        {
            return $"Status={Status}, Uuid={Uuid}, DownloadUrl={DownloadUrl}";
        }

        public void Absorb(ExportStatusResponseCore source)
        {
            DownloadUrl = source.DownloadUrl;
            Status = source.Status;
            Uuid = source.Uuid;
        }
    }

    internal class ExportStatusResponseInner : ExportStatusResponseCore
    {
        public int DateTime { get; set; }

        /// <summary>
        /// Convert epoch time to something nicer
        /// </summary>
        public ExportStatusResponse ToPublic()
        {
            var real = new ExportStatusResponse();
            real.Absorb(this);

            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var utcDate = epoch.AddSeconds(DateTime);

            real.DateTime = new DateTimeOffset(utcDate);
            return real;
        }
    }

    public class ExportStatusResponse : ExportStatusResponseCore
    {
        public Instance Instance { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }

    internal class ExportStatusResponseOuter : BaseResponse
    {
        public ExportStatusResponseInner Data { get; set; }
    }
}
