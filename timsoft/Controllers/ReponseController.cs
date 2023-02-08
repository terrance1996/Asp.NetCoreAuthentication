using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using timsoft.entities;
using timsoft.services;

namespace timsoft.Controllers
{
    [Route("api/Reponse*/")]
    [ApiController]
    public class ReponseController : ControllerBase
    {

        private IReponseService reponseService;
        public ReponseController(IReponseService reponseService)
        {
            this.reponseService = reponseService;
        }

        [HttpPost]
        [Route("AddReponse")]
        public ActionResult AddReponse([FromBody] Reponse reponse)
        {
            return Ok(reponseService.AddReponse(reponse));
        }
        [HttpGet]
        [Route("GetReponseById")]
        public ActionResult GetReponseById(int id)
        {
            return Ok(reponseService.GetReponseById(id));
        }

        [HttpGet]
        [Route("GetAllReponses")]
        public ActionResult GetAllReponses()
        { return Ok(reponseService.GetAllReponses()); }

        [HttpDelete]
        [Route("DeleteReponse")]
        public ActionResult DeleteReponse(int id)
        {
            return Ok(reponseService.GetReponseById(id));
        }
        [HttpPut]
        [Route("UpdateReponse")]
        public ActionResult UpdateReponse(Reponse reponse, int id)
        {
            return Ok(reponseService.UpdateReponse(reponse, id));


        }
    }
}
