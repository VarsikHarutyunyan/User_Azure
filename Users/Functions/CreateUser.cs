using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Users.Models;
using Users.Services;
namespace Users.Functions
{
    public class CreateUser
    {
        private readonly IService _service;
        public CreateUser(IService service)
        {
            _service = service;
        }

        [FunctionName("CreateUser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "CreateUser")] HttpRequest req,
            ILogger log)
        {
            string bodyStr = await new StreamReader(req.Body).ReadToEndAsync();
            var userToCreate = JsonConvert.DeserializeObject<User>(bodyStr);
            var user = await _service.CreateAsync(userToCreate);
            if (user == null)
            {
                return new BadRequestObjectResult($"username {userToCreate.Name} exists!");
            }
            var responseMsg = $"User is created, the id is {user.Id}";
            return new OkObjectResult(responseMsg);
        }
    }
}
