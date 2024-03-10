namespace ManaCars.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string lasName, string email, string password);
    AuthenticationResult Login(string email, string password);
}