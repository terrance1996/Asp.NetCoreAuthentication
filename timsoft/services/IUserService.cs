using timsoft.entities;
using timsoft.Utils.SignInRequest;

namespace timsoft.services
{
    public interface IUserService
    {
        public string SignIn(SignIn signIn);
        public User AddUser(UserForm user);
    }
}
