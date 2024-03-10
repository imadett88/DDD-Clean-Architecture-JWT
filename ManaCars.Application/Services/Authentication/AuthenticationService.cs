using ManaCars.Application.Common.Interfaces.Authentication;

namespace ManaCars.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(string firstName, string lasName, string email, string password)
    {

        // verify

        // create user

        //create jwt token

        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lasName);


        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lasName,
            email,
            token
        );
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
             email,
             "token"
        );
    }
}