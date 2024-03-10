using ManaCars.Domain.Entities;

namespace ManaCars.Application.Services.Authentication;


public record AuthenticationResult(
      User User,
    string Token
);