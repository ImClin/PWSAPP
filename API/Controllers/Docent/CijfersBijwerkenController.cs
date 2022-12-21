using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;
using WebApiClin.Classes.Requests;
using WebApiClin.Classes.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers.Docent
{
    [ApiController]
    [Route("api/Docent/[controller]")]
    public class CijfersBijwerkenController : ControllerBase
    {
        // POST api/<Logon>
        [HttpPost]
        public List<CijfersPerKlas> Post([FromBody] List<BehaaldeCijfers> RequestBody)
        {
            List<CijfersPerKlas> resultaat = Database.CijfersBijwerken(RequestBody);
            return resultaat;
        }
    }
}
