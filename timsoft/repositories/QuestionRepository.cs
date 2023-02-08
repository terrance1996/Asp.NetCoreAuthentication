using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using timsoft.DataBase;
using timsoft.entities;

namespace timsoft.repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private DataBaseContext _context;
        public QuestionRepository(DataBaseContext dataBaseContext)
        {

            _context = dataBaseContext;

        }
        public Question AddQuestion(Question question)
        {
            _context.Question.Add(question);
            _context.SaveChanges();
            return question;
        }

        public string DeleteQuestion(int id)
        {
            Question q = _context.Question.Where(i => i.IdQuest == id).FirstOrDefault();

            if (q == null)
                throw new NullReferenceException();

            _context.Question.Remove(q);
            _context.SaveChanges();
            return "Question supprimé !";
        }

        public List<Question> GetAllQuestions()
        {
            List<Question> ql = new List<Question>();
            ql = _context.Question.ToList();
            return ql;
        }

        public Question GetQuestionById(int id)
        {
            Question q = new Question();
            if (q == null)
                throw new NullReferenceException();
            q = _context.Question.Where(i => i.IdQuest == id).FirstOrDefault();
            return q;

        }

        public String UpdateQuestion(Question question , int id)
        {

            var itemToUpdate = _context.Question.Where(i => i.IdQuest == id).FirstOrDefault();
            if (itemToUpdate == null)
                throw new NullReferenceException();

            itemToUpdate.Intitule = question.Intitule;
            itemToUpdate.Durée = question.Durée;
            itemToUpdate.Catégorie = question.Catégorie;
            itemToUpdate.Point = question.Point;
            itemToUpdate.NbRep = question.NbRep;
            _context.SaveChanges();
            return "Question  modifié";
        }
    }
}
