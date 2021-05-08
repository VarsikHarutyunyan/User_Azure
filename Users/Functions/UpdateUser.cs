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
    public class UpdateUser
    {
        private readonly IService _service;
        public UpdateUser(IService service)
        {
            _service = service;
        }

        [FunctionName("UpdateUser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "UpdateUser/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            string bodyStr = await new StreamReader(req.Body).ReadToEndAsync();
            var updatedUser = JsonConvert.DeserializeObject<User>(bodyStr);

            var user = await _service.UpdateAsync(id, updatedUser);
            return new OkObjectResult(user);
        }
    }
}
