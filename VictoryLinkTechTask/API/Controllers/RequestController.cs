using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VictoryLinkTechTask.Application.Contracts.Inbound;
using VictoryLinkTechTask.Application.Services.Interfaces;

namespace VictoryLinkTechTask.API.Controllers
{
    public class RequestController : ApiController
    {
        private IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {

            _requestService = requestService;
        }

        [HttpPost]
        [Route("ReceiveRequest")]
        public IHttpActionResult ReceiveRequest([FromBody] RequestModel requestdto)
        {
            return Ok(_requestService.ReceiveRequest(requestdto));
        }

        [HttpPost]
        [Route("HandleRequest/{mobileNumber}")]
        public IHttpActionResult HandleRequest(int mobileNumber)
        {
            return Ok(_requestService.HandleRequest(mobileNumber));
        }

        [HttpGet]
        [Route("GetAllUnhandledRequests")]
        public IHttpActionResult GetAllUnhandledRequests()
        {
            return Ok(_requestService.GetAllUnhandledRequests());
        }
    }
}
