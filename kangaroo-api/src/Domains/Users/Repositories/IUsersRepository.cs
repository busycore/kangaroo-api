using kangaroo_api.Domains.Users.Models;

namespace kangaroo_api.Domains.Users.Repositories;

public interface IUsersRepository
{
    Task<List<User>> findAll();
}