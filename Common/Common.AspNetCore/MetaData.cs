using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.AspNetCore.Enums;

namespace Common.AspNetCore
{
    public class MetaData
    {
        public string Message { get; set; }
        public AppStatusCode AppStatusCode { get; set; }
    }
}