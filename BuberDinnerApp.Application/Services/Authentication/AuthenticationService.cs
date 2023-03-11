using BuberDinnerApp.Application.Common.interfaces.Authentication;
using BuberDinnerApp.Application.Dtos.Authentication;

namespace BuberDinnerApp.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator _jwtTokenGenerator)
        {
            jwtTokenGenerator = _jwtTokenGenerator;
        }

        public AuthenticationResult Login(string Email, string Password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "FirstName",
                "LastName",
                Email,
                Password,
                "Token"
                );
        }

        public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
        {
            //check if user already exists 
            // create new user
            //create jwt token 
            var userId = Guid.NewGuid();
            var token = jwtTokenGenerator.GenerateToken(userId, FirstName, LastName);
            return new AuthenticationResult(
                userId,
                FirstName,
                LastName,
                Email,
                Password,
                token
                );
        }
    }
}
