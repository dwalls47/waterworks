using Grpc.Core;
using GrpcService.Data;
using GrpcService.Models;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;
using System.Linq;
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

            //  TODO: Verify HashedPassword
            //  TODO: Generate JWT (claims)

            _logger.LogInformation("Sending login response");

            if (user != null)
            {
                output.AccessToken = user.HashedPassword;
            }

            return Task.FromResult(output);
        }
    }
}
