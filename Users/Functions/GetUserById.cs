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
  public  class GetUserById
    {
        private readonly IService _service;
        public GetUserById(IService service)
        {
            _service = service;
        }

        [FunctionName("GetUserById")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetUserById/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            var user = await _service.GetByIdAsync(id);
            return new OkObjectResult(user);
        }
    }
}
