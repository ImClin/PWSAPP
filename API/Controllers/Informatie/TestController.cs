using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers.Informatie
{
    [Route("api/Informatie/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/Test
        [HttpGet]
        public string Get()
        {
            string resultaat = Database.TestConnection();
            return resultaat;
        }


    }
}
