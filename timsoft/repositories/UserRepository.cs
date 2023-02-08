using timsoft.DataBase;
using timsoft.entities;
using timsoft.Utils;

namespace timsoft.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext dataBase;

        public UserRepository(DataBaseContext dataBase)
        {
            this.dataBase = dataBase;
        }
        public User AddUser(UserForm user)
        {

            User dbuser = new User();
            System.Diagnostics.Debug.WriteLine(user.Username.Length);
            if (user.Nom.ToString().Length < 4)
            {
                throw new Exception("first Name must be longer then 4 caractere ");
            }
            dbuser.Nom = user.Nom;

            if (user.Prénom.Length < 4)
            {
                throw new Exception("LastName must be longer then 4 caractere ");
            }

            dbuser.Prénom = user.Prénom;


            if (user.Username.Length < 4)
            {
                throw new Exception("userName  must be longer then 4 caractere ");
            }



            if (dataBase.Users.Where(u => u.Username.Contains(user.Username)).Count() == 1)
            {
                throw new Exception("UserName Used !!");
            }

         

            dbuser.Username = user.Username;

            if (user.Password.Length < 6)
            {
                throw new Exception(" password must be longer then 6 caractere ");
            }


            dbuser.Password = HashPassword.HashPass(user.Password);

            List<Role> roles = new List<Role> { };
            List<Réclamation> reclamations = new List<Réclamation> { };
            List<UserEpreuve> epreuves = new List<UserEpreuve> { };

            dbuser.Roles =roles;
            dbuser.Réclamation = reclamations;
            dbuser.UserEpreuves = epreuves;
            //dbuser.Roles.Add(role);

            dataBase.Users.Add(dbuser);

            dataBase.SaveChanges();
            return dbuser;
        }
    }
}
