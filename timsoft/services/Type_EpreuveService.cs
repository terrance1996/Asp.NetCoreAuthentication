using timsoft.entities;
using timsoft.repositories;

namespace timsoft.services
{
    public class Type_EpreuveService : IType_EpreuveService
    {
        private IType_EpreuveRepository _repository;

        public Type_EpreuveService(Type_EpreuveRepository type_EpreuveRepository)
        {
            _repository = type_EpreuveRepository ;

        }
        public Type_Epreuve AddType_Epreuve(Type_Epreuve type_Epreuve)
        {
            return _repository.AddType_Epreuve(type_Epreuve);

        }

        public string DeleteType_Epreuve(int id)
        {
            return _repository.DeleteType_Epreuve(id);

        }

        public List<Type_Epreuve> GetAllType_Epreuves()
        {
            return _repository.GetAllType_Epreuves();

        }

        public Type_Epreuve GetType_EpreuveById(int id)
        {
            return _repository.GetType_EpreuveById(id);

        }

        public string UpdateType_Epreuve(Type_Epreuve type_Epreuve, int id)
        {
            return _repository.UpdateType_Epreuve(type_Epreuve , id);

        }
    }
}
