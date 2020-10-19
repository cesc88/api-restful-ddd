using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api_Restful.Domain.Entities;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Domain.Repository;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private SigningConfiguration _signing;
        private TokenConfigurations _token;
        private IConfiguration _configuration;

        public LoginService(IUserRepository repository,
                            IConfiguration configuration,
                            SigningConfiguration signing,
                            TokenConfigurations token)
        {
            _repository = repository;
            _configuration = configuration;
            _signing = signing;
            _token = token;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            var baseUser = new UserEntity();

            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Authenticate fail"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                        }
                    );

                    DateTime createdDate = DateTime.Now;
                    DateTime expirationDate = createdDate + TimeSpan.FromSeconds(_token.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createdDate, expirationDate, handler);
                    return SuccessObject(createdDate, expirationDate, token, user);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Authenticate fail"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createdDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _token.Issuer,
                Audience = _token.Audience,
                SigningCredentials = _signing.SigningCredentials,
                Subject = identity,
                NotBefore = createdDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createdDate, DateTime expirationDate, string token, LoginDto user)
        {
            return new
            {
                authenticated = true,
                created = createdDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = "Success logged user"
            };
        }
    }
}
