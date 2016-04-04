﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphStory.Client
{
    public enum ResponseStatus
    {
        Unknown = 0,
        Success = 1
    }

    public class Instance
    {
        public string Created { get; set; }
        public string Host { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string WebUi { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name='{Name}'";
        }
    }

    public class GetInstancesResponse
    {
        public List<Instance> Data { get; set; }
        public ResponseStatus Status { get; set; }
    }
}
