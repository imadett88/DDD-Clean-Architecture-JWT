using ManaCars.Domain.Entities;

namespace ManaCars.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}