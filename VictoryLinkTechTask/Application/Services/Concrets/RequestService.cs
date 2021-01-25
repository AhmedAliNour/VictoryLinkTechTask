using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VictoryLinkTechTask.Application.Contracts.Inbound;
using VictoryLinkTechTask.Application.Contracts.Outbound;
using VictoryLinkTechTask.Application.Services.Interfaces;
using VictoryLinkTechTask.Domain.Models;
using VictoryLinkTechTask.Infrastructure.Persistance;

namespace VictoryLinkTechTask.Application.Services.Concrets
{
    public class RequestService : IRequestService
    {
        private readonly AppDbContext _context;
        public RequestService(AppDbContext context)
        {
            _context = context;
        }

        public ResultViewModel ReceiveRequest(RequestModel requestDto)
        {
            try
            {
                if (requestDto.Action.Length > 50)
                {
                    return new ResultViewModel()
                    {
                        Status = 0,
                        Message = "fail"
                    };
                }

                var existingRequest = _context.Requests.Where(r => r.MobileNumber == requestDto.MobileNumber).FirstOrDefault();

                if (existingRequest != null)
                {
                    return new ResultViewModel()
                    {
                        Status = 0,
                        Message = "fail"
                    };
                }

                var request = new Request()
                {
                    Action = requestDto.Action,
                    MobileNumber = requestDto.MobileNumber,
                    Handled = false,
                    RequestDate = DateTime.Now
                };

                _context.Requests.Add(request);
                _context.SaveChanges();

                return new ResultViewModel()
                {
                    Status = 1,
                    Message = "success"
                };
            }
            catch (Exception)
            {
                return new ResultViewModel()
                {
                    Status = 2,
                    Message = "fail"
                };
            }
        }

        public ResultViewModel HandleRequest(int mobileNumber)
        {
            try
            {
                var existingRequest = _context.Requests.Where(r => r.MobileNumber == mobileNumber).FirstOrDefault();

                if (existingRequest == null)
                {
                    return new ResultViewModel()
                    {
                        Status = 0,
                        Message = "fail"
                    };
                }

                existingRequest.Handled = true;
                existingRequest.HandlingDate = DateTime.Now;

                _context.SaveChanges();

                return new ResultViewModel()
                {
                    Status = 1,
                    Message = "success"
                };
            }
            catch (Exception)
            {
                return new ResultViewModel()
                {
                    Status = 2,
                    Message = "fail"
                };
            }
        }
        public List<RequestModel> GetAllUnhandledRequests()
        {
            return _context.Requests.Where(r => !r.Handled).Select(x => new RequestModel()
            {
                Action = x.Action,
                MobileNumber = x.MobileNumber
            }).ToList();
        }
    }
}