
using Microsoft.AspNetCore.Mvc;

namespace SystemIO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Home Controller";
        }

    }

}