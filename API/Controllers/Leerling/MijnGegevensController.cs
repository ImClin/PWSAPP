using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;
using WebApiClin.Classes.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers.Leerling
{
    [ApiController]
    [Route("api/Leerling/[controller]/{LeerlingId}")]
    public class MijnGegevensController : ControllerBase
    {
        // GET: api/Docenten
        [HttpGet]

        public LeerlingGegevens Get(
            [FromRoute] string LeerlingId)
        {
            LeerlingGegevens resultaat = Database.MijnLeerlingGegevens(LeerlingId);
            return resultaat;
        }


    }
}
