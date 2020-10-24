using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        // GET: api/<GreetingController>
        [HttpGet]
        public string Get()
        {
            return  "Hello, World!";
        }

    }
}
