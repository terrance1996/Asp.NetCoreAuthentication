using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using timsoft.entities;
using timsoft.services;

namespace timsoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Type_EpreuveController : ControllerBase
    {

        private IType_EpreuveService type_EpreuveService;
        public Type_EpreuveController(IType_EpreuveService type_Epreuve)
        {
            this.type_EpreuveService = type_Epreuve;
        }

        [HttpPost]
        [Route("AddType_Epreuve")]
        public ActionResult AddType_Epreuve([FromBody] Type_Epreuve type_Epreuve)
        {
            return Ok(type_EpreuveService.AddType_Epreuve(type_Epreuve));
        }
        [HttpGet]
        [Route("GetType_EpreuveById")]
        public ActionResult GetType_EpreuveById(int id)
        {
            return Ok(type_EpreuveService.GetType_EpreuveById(id));
        }

        [HttpGet]
        [Route("GetAllType_Epreuves")]
        public ActionResult GetAllType_Epreuves()
        { return Ok(type_EpreuveService.GetAllType_Epreuves()); }

        [HttpDelete]
        [Route("DeleteType_Epreuve")]
        public ActionResult DeleteType_Epreuve(int id)
        {
            return Ok(type_EpreuveService.DeleteType_Epreuve(id));
        }
        [HttpPut]
        [Route("UpdateType_Epreuve")]
        public ActionResult UpdateType_Epreuve(Type_Epreuve type_Epreuve, int id)
        {
            return Ok(type_EpreuveService.UpdateType_Epreuve(type_Epreuve, id));


        }


    }
}
