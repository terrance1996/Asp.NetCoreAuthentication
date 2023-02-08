using timsoft.DataBase;
using timsoft.entities;

namespace timsoft.repositories
{
    public class Type_EpreuveRepository : IType_EpreuveRepository
    {

        private DataBaseContext _context;
        public Type_EpreuveRepository(DataBaseContext dataBaseContext)
        {

            _context = dataBaseContext;

        }
        public Type_Epreuve AddType_Epreuve(Type_Epreuve type_Epreuve)
        {
            _context.Type_Epreuve.Add(type_Epreuve);
            _context.SaveChanges();
            return type_Epreuve;
        }

            public string DeleteType_Epreuve(int id)
        {
            Type_Epreuve t = _context.Type_Epreuve.Where(i => i.IdType == id).FirstOrDefault();

            if (t == null)
                throw new NullReferenceException();

            _context.Type_Epreuve.Remove(t);
            _context.SaveChanges();
            return "Type_Epreuve supprimé !";
        }

        public List<Type_Epreuve> GetAllType_Epreuves()
        {
            List<Type_Epreuve> tl = new List<Type_Epreuve>();
            tl = _context.Type_Epreuve.ToList();
            return tl;
        }

        public Type_Epreuve GetType_EpreuveById(int id)
        {
            Type_Epreuve t = new Type_Epreuve();
            if (t == null)
                throw new NullReferenceException();
            t = _context.Type_Epreuve.Where(i => i.IdType == id).FirstOrDefault();
            return t;
        }

        public string UpdateType_Epreuve(Type_Epreuve type_Epreuve, int id)
        {
            var itemToUpdate = _context.Type_Epreuve.Where(i => i.IdType == id).FirstOrDefault();
            if (itemToUpdate == null)
                throw new NullReferenceException();

            itemToUpdate.Type = type_Epreuve.Type;
            _context.SaveChanges();
            return "Type_Epreuve modifié";
        }
    }
}
