using Microsoft.AspNetCore.Mvc;

namespace CustomAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("You have access to this endpoint");
    }
}
