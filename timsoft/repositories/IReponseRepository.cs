using timsoft.entities;

namespace timsoft.repositories
{
    public interface IReponseRepository
    {
        Reponse AddReponse(Reponse reponse);
        String UpdateReponse(Reponse reponse, int id);
        List<Reponse> GetAllReponses();
        Reponse GetReponseById(int id);
        string DeleteReponse(int id);
    }
}
