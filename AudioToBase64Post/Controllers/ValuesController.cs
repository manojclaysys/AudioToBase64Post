// ValuesController
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AudioToBase64Post.Model;
using AudioToBase64Post.Repository;
using System.Text.Json;

namespace AudioToBase64Post.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Class model)
        {

            try
            {
                Exception exception = new Exception();

                if (model.File != null)
                {
                    var response = new
                    {
                        Error = "",
                        Prediction = 26.69,
                        Result = "Live"
                    };

                    // Serialize response object to JSON
                    string jsonResponse = JsonSerializer.Serialize(response);

                    return Content(jsonResponse, "application/json");
                }
                else
                {
                    var response = new
                    {
                        Error = "",
                        Prediction = 0.20,
                        Result = "Replay"
                    };

                    // Serialize response object to JSON
                    string jsonResponse = JsonSerializer.Serialize(response);

                    return Content(jsonResponse, "application/json");
                    //return StatusCode((int)HttpStatusCode.InternalServerError, new { error = exception.Message });

                }


            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { error = e.Message });
            }
        }
    }
}