using timsoft.entities;

namespace timsoft.services
{
    public interface IQuestionService
    {

        Question AddQuestion(Question question);
        String UpdateQuestion(Question question, int id);
        List<Question> GetAllQuestions();
        Question GetQuestionById(int id);
        String DeleteQuestion(int id);

    }
}
