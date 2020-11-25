using Grpc.Core;
using GrpcServer.Web.Data;
using GrpcServer.Web.protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Web.Services
{
    public class MyEmployeeService:EmployeeService.EmployeeServiceBase
    {
        private readonly ILogger<MyEmployeeService> _logger;

        public MyEmployeeService(ILogger<MyEmployeeService>logger)
        {
                _logger = logger;
        }
        public override async Task<EmployeeResponse> 
            GetByNo(GetByNoRequest request, ServerCallContext context)
        {
            var employee = InMemoryData.Employees.SingleOrDefault(x => x.No == request.No);
            if (employee!=null)
            {
                var response = new EmployeeResponse
                {
                    Employee = employee
                };
                return await Task.FromResult(response);
            }
            throw new Exception($"Employee not found with no:{request.No}");
            
        }
    }
}
