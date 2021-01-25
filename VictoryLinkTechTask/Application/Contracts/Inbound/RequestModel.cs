using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VictoryLinkTechTask.Application.Contracts.Inbound
{
    public class RequestModel
    {
        public int MobileNumber { get; set; }
        public string Action { get; set; }
    }
}