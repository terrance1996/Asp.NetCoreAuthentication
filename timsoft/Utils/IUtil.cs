using timsoft.Utils.SignInRequest;

namespace timsoft.Utils
{
    public interface IUtil
    {
        public bool verifyPassword(SignIn signIn);
        public bool verifyUserName(SignIn signIn);
        public string GenerateToken(SignIn signIn);
    }
}
