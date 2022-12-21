using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;
using WebApiClin.Classes.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers.Docent
{
    [Route("api/Docent/[controller]/{VakId}")]
    [ApiController]
    public class MijnKlasController : ControllerBase
    {
        // GET: api/<VersieController>
        [HttpGet]
        public List<CijfersPerKlas> Get(
            [FromRoute] int VakId)
        {
            List<CijfersPerKlas> resultaat = Database.MijnLeerlingenCijfers(VakId);
            return resultaat;

        }


    }
}
