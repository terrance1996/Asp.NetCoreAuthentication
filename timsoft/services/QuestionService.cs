using timsoft.entities;
using timsoft.repositories;

namespace timsoft.services
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _repository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _repository= questionRepository;
            
        }
        public Question AddQuestion(Question question)
        {
          return _repository.AddQuestion(question);
        }

        public string DeleteQuestion(int id)
        {
           return _repository.DeleteQuestion(id);
        }

        public List<Question> GetAllQuestions()
        {
           return _repository.GetAllQuestions();
        }

        public Question GetQuestionById(int id)
        {
            return _repository.GetQuestionById(id);
        }

        public String UpdateQuestion(Question question, int id)
        {
          return _repository.UpdateQuestion(question , id);
        }
    }
}
