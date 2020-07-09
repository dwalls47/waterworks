using Grpc.Core;
using GrpcService.Data;
using GrpcService.Models;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class AuthenticationService : Authentication.AuthenticationBase
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly WaterWorksDbContext _context;

        public AuthenticationService(ILogger<AuthenticationService> logger, WaterWorksDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
        {
            //  https://dev.to/techschoolguru/use-grpc-interceptor-for-authorization-with-jwt-1c5h
            var output = new LoginResponse();

            var user = _context.Users.Where(u => u.UserName == request.Username).FirstOrDefault<User>();

            #region JWT
            if (user != null)
            {
                //  https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp
                //  SequentialEqual
                string hashedPassword;
                using (var algorithm = new Rfc2898DeriveBytes(
                    Encoding.UTF8.GetBytes(request.Password),
                    Convert.FromBase64String(user.Salt),
                    user.Iterations,
                    HashAlgorithmName.SHA256))
                {
                    hashedPassword = Convert.ToBase64String(algorithm.GetBytes(32));
                }
                if (hashedPassword == user.HashedPassword)
                {
                    //  https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api
                    //  Generate JWT with Claims
                    var tokenHandler = new JwtSecurityTokenHandler();
                    // Define const Key this should be private secret key  stored in some safe place
                    var keyRaw = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
                    var key = Encoding.UTF8.GetBytes(keyRaw); //    or _appSettings.Secret
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.UserName)
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    output.AccessToken = tokenHandler.WriteToken(token);

                    //  TODO: Refresh Tokens: https://jasonwatmore.com/post/2020/05/25/aspnet-core-3-api-jwt-authentication-with-refresh-tokens
                }
            }
            #endregion

            _logger.LogInformation("Sending login response");

            return Task.FromResult(output);
        }
    }
}
