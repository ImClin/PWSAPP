using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;
using WebApiClin.Classes.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers.Leerling
{
    [Route("api/Leerling/[controller]/{LeerlingId}")]
    [ApiController]
    public class MijnCijfersController : ControllerBase
    {
        // GET: api/<VersieController>
        [HttpGet]
        public List<MijnCijfers> Get(
            [FromRoute] string LeerlingId)
        {
            List<MijnCijfers> resultaat = Database.MijnCijferLijst(LeerlingId);
            return resultaat;

        }


    }
}
