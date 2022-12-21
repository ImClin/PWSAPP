using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers.Informatie
{
    [Route("api/Informatie/[controller]")]
    //[EnableCors("myAllowSpecificOrigins")]
    [ApiController]
    public class Versie : ControllerBase
    {
        // GET: api/<VersieController>
        [HttpGet]
        public string Get()
        {
            return "Versie 1.0";
        }


    }
}
