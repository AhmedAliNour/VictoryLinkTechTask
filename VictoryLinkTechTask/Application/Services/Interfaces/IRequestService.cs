using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VictoryLinkTechTask.Application.Contracts.Inbound;
using VictoryLinkTechTask.Application.Contracts.Outbound;

namespace VictoryLinkTechTask.Application.Services.Interfaces
{
    public interface IRequestService
    {
        ResultViewModel ReceiveRequest(RequestModel requestDto);
        ResultViewModel HandleRequest(int mobileNumber);
        List<RequestModel> GetAllUnhandledRequests();
    }
}