using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;
using WebApiClin.Classes.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers.Informatie
{
    [ApiController]
    [Route("api/Informatie/[controller]")]
    public class LeerlingenController : ControllerBase
    {
        // GET: api/Docenten
        [HttpGet]
        public List<LeerlingGegevens> Get()
        {
            List<LeerlingGegevens> resultaat = Database.LeerlingenLijst();
            return resultaat;
        }


    }
}
