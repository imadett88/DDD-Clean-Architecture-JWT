using ManaCars.Domain.Entities;

namespace ManaCars.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}