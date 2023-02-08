using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using timsoft.DataBase;
using timsoft.entities;
using timsoft.Utils.SignInRequest;

namespace timsoft.Utils
{
    public class Util : IUtil
    {
        private readonly DataBaseContext _context;
        private readonly IConfiguration _config;

        public Util()
        {
        }

        public Util(DataBaseContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public bool verifyPassword(SignIn signIn)
        {

            var user = _context.Users.Where(u => u.Username == signIn.UserName)
                   .FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            string h_pass = HashPassword.HashPass(signIn.Password);

            if (h_pass == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verifyUserName(SignIn signIn)
        {
            var user = _context.Users
                     .Where(u => u.Username == signIn.UserName)
                     .FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }




        public string GenerateToken(SignIn signIn)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var user = _context.Users
                    .Where(u => u.Username == signIn.UserName)
                    .FirstOrDefault();
            var roles = new List<String> { };
            var userRoles = _context.Users
                       .Where(u => u.Username == signIn.UserName)
                       .SelectMany(u => u.Roles);

            if (userRoles.Count() > 0)
            {
                foreach (Role role in userRoles)
                {
                    roles.Add(role.RoleName);
                }
                // System.Diagnostics.Debug.WriteLine(roles);
            }

            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name,user.Username)
            };




            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }



            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1500),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
