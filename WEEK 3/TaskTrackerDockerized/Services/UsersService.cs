using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskTracker.Infrastructure;
using TaskTracker.Interfaces;
using TaskTracker.Models;
using TaskTracker.Repository;

namespace TaskTracker.Services
{
    public class UsersService : IUserService
    {
        private readonly TaskTrackerRepository _repository;
        private readonly IConfigurationSection _secretKey;
        public UsersService(TaskTrackerContext dbContext, IConfiguration config)
        {
            _repository = new TaskTrackerRepository(dbContext);
            _secretKey = config.GetSection("SecretKey");
        }
        public string Login(string username, string password)
        {
            User user = _repository.FindUserByUsername(username);
            if (user.Password == password)
            {
                List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Role,"user") };
                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.Value));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "server",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signingCredentials
                    );
                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions); 
                return tokenString;
            }
            else
            {
                throw new Exception("Invalid password!");
            }
        }

        public User Register(User user)
        {
            return _repository.Register(user);
        }
    }
}
