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
    public class DeleteUser
    {
        private readonly IService _service;
        public DeleteUser(IService service)
        {
            _service = service;
        }

        [FunctionName("DeleteUser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeleteUser/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            var isSuccess = await _service.DeleteAsync(id);
            return new OkObjectResult($"the user is deleted: {isSuccess}");
        }
    }
}
