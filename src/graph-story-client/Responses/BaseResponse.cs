using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphStory.Client.Responses
{
    public class BaseResponse
    {
        public ResponseStatus Status { get; set; }

        public override string ToString()
        {
            return $"Status={Status}";
        }
    }
}
