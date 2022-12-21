using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;
using WebApiClin.Classes.Requests;
using WebApiClin.Classes.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Logon : ControllerBase
    {
        // POST api/<Logon>
        [HttpPost]
        public SessionToken Post([FromBody] LogonRequest RequestBody)
        {
            SessionToken resultaat = Database.Login(RequestBody);
            return resultaat;
        }
    }
}
