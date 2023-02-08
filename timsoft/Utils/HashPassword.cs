using System.Text;

namespace timsoft.Utils
{
    public static class HashPassword
    {
        public static string HashPass(this string value)
        {
            var HashSHA256 = System.Security.Cryptography.SHA256.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value + "MySecretKeyForJWTTokenEncryption");
            var hash = HashSHA256.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
