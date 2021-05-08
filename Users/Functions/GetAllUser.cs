using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Services;

namespace Users.Functions
{
   public class GetAllUser
    {
        private readonly IService _service;
        public GetAllUser(IService service)
        {
            _service = service;
        }

        [FunctionName("GetAllUser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetAllUser")] HttpRequest req,
            ILogger log)
        {
            var user = await _service.GetAllAsync();
            return new OkObjectResult(user);
        }
    }
}
