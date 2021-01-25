using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VictoryLinkTechTask.Application.Contracts.Outbound
{
    public class ResultViewModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
}