using timsoft.entities;

namespace timsoft.repositories
{
    public interface IQuestionRepository
    {
        Question AddQuestion(Question question);
        String UpdateQuestion(Question question , int id);
        List<Question> GetAllQuestions();
        Question GetQuestionById(int id);
       string DeleteQuestion(int id);
      
    }
}
