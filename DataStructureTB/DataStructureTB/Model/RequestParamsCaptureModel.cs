using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Model
{
    public class RequestParamsCaptureModel
    {
        public string url { get; set; }

        public Dictionary<string, string> fields { get; set; }

        public string name { get; set; }
    }
}