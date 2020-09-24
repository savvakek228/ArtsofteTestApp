using Microsoft.AspNetCore.Mvc;

namespace ArtsofteTestWebApp.Controllers
{
    [ApiController]
    [Route("/departments")]
    public class DepartmentsController : ControllerBase
    {
        public DepartmentsController()
        {
            
        }
        [HttpPost]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        public string Get()
        {
            return "test";
        }

        [HttpPut]
        public string Put()
        {
            return "ok";
        }
        
    }
}