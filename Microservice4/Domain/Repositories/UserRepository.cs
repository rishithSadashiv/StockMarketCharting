using Microservice4.DataContext;
using Microservice4.Domain.Contracts;
using Microservice4.Dtos;
using Microservice4.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Microservice4.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly LoginDBContext context;
        readonly IConfiguration Config;
        public UserRepository(LoginDBContext ctx, IConfiguration config)
        {
            this.context = ctx;
            this.Config = config;
        }
        public bool AddUser(User dto)
        {
            if (context.User.Any(o=> o.Username == dto.Username))
            {
                throw new Exception("Username already taken"); //indicates the username already is taken
            }
            else
            {
                context.User.Add(dto);
                int RowsAffected = context.SaveChanges();
                return RowsAffected > 0;
            }
        }

        public User getUser(int Id)
        {
            var Obj = context.User.Find(Id);
            return Obj;
        }

        public UserValidationResponseModel Login(CredentialsModel cr)
        {
            UserValidationResponseModel result = new UserValidationResponseModel();
            try
            {
                IList<User> Obj = context.User.Where(o => o.Username == cr.Username).ToList();
                
                if (Obj[0].Password == cr.Password)
                {
                    result.Id = Obj[0].Id;
                    result.UserType = Obj[0].UserType;
                    result.Jwt = GenerateToken(Obj[0].UserType, cr.Username);
                }
                else
                {
                    throw new Exception("Invalid Username/Password");
                }
                result.Username = Obj[0].Username;
                return result;
            }
            catch (InvalidCastException)
            {
                throw new Exception("User not found");
            }
        }

        public bool UpdateUser(User user)
        {
            context.User.Update(user);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }


        private string GenerateToken(string userType, string username)
        {
            string token = string.Empty;

            var now = DateTime.Now;

            var claims = new Claim[] {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString()),
            new Claim("UserType", userType)
            };

            var KeyText = Config.GetValue<string>("SecurityKey");
            var KeyBytes = Encoding.ASCII.GetBytes(KeyText);
            var Key = new SymmetricSecurityKey(KeyBytes);

            var Jwt = new JwtSecurityToken(claims: claims,
                                           expires: now.AddMinutes(60),
                                           signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256));
            token = new JwtSecurityTokenHandler().WriteToken(Jwt);

            return token;

        }
    }
}
