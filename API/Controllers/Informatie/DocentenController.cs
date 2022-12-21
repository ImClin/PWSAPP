using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;
using WebApiClin.Classes.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers.Informatie
{
    [ApiController]
    [Route("api/Informatie/[controller]")]
    public class DocentenController : ControllerBase
    {
        // GET: api/Docenten
        [HttpGet]
        public List<DocentGegevens> Get()
        {
            List<DocentGegevens> resultaat = Database.DocentenLijst();
            return resultaat;
        }


    }
}
