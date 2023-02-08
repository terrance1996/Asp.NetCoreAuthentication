using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using timsoft.entities;
using timsoft.services;

namespace timsoft.Controllers
{
    [Route("api/Question*/")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionService questionService;
        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpPost]
        [Route("AddQuestion")]
        public ActionResult AddQuestion([FromBody] Question question)
        {
            return Ok(questionService.AddQuestion(question));
        }
        [HttpGet]
        [Route("GetQuestionById")]
        public ActionResult GetQuestionById(int id)
        {
            return Ok(questionService.GetQuestionById(id));
        }

        [HttpGet]
        [Route("GetAllQuestions")]
        public ActionResult GetAllQuestions()
        { return Ok(questionService.GetAllQuestions()); }

        [HttpDelete]
        [Route("DeleteQuestion")]
        public ActionResult DeleteQuestion(int id)
        {
            return Ok(questionService.DeleteQuestion(id));
        }
        [HttpPut]
        [Route("UpdateQuestion")]
        public ActionResult UpdateQuestion(Question question, int id)
        {
            return Ok(questionService.UpdateQuestion(question, id));


        }
    }
}
