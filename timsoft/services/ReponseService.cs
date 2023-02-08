using timsoft.entities;
using timsoft.repositories;

namespace timsoft.services
{
    public class ReponseService : IReponseService
    {
        private IReponseRepository _repository;

        public ReponseService(ReponseRepository reponseRepository)
        {
            _repository = reponseRepository;

        }
        public Reponse AddReponse(Reponse reponse)
        {
            return _repository.AddReponse(reponse);
        }

        public string DeleteReponse(int id)
        {
            return _repository.DeleteReponse(id);
        }

        public List<Reponse> GetAllReponses()
        {
            return _repository.GetAllReponses();
        }

        public Reponse GetReponseById(int id)
        {
            return _repository.GetReponseById(id);
        }

        public string UpdateReponse(Reponse reponse, int id)
        {
            return _repository.UpdateReponse(reponse ,id);
        }
    }
}
