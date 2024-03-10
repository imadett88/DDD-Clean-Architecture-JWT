using ManaCars.Application.Common.Interfaces.Authentication;
using ManaCars.Application.Common.Interfaces.Persistence;
using ManaCars.Domain.Entities;

namespace ManaCars.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Register(string firstName, string lasName, string email, string password)
    {

        // verify

        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }

        // create user

        var user = new User
        {
            FirstName = firstName,
            LastName = lasName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //create jwt token

        //Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token
        );
    }

    public AuthenticationResult Login(string email, string password)
    {
        // check
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email doeas not exist");
        }

        // validate
        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        // create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
          user,
          token
        );
    }
}