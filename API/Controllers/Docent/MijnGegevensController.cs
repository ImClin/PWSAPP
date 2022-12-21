using Microsoft.AspNetCore.Mvc;
using WebApiClin.Classes;
using WebApiClin.Classes.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiClin.Controllers.Docent
{
    [ApiController]
    [Route("api/Docent/[controller]/{DocentId}")]
        public class MijnGegevensController : ControllerBase
    {
        /// <param name="DocentId"></param>
        /// <returns>Haalt de gegevens op van een docent</returns>
        /// <remarks>
        /// // GET: api/Docenten
        [HttpGet]
        public DocentGegevens Get(
            [FromRoute] string DocentId)
        {
            DocentGegevens resultaat = Database.MijnDocentGegevens(DocentId);
            return resultaat;
        }


    }
}
