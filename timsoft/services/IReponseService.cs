using timsoft.entities;

namespace timsoft.services
{
    public interface IReponseService
    {
        Reponse AddReponse(Reponse reponse);
        String UpdateReponse(Reponse reponse, int id);
        List<Reponse> GetAllReponses();
        Reponse GetReponseById(int id);
        String DeleteReponse(int id);
    }
}
