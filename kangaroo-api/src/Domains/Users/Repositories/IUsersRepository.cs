using kangaroo_api.Domains.Users.Models;

namespace kangaroo_api.Domains.Users.Repositories;

public interface IUsersRepository
{
    Task<List<User>> findAll();
    
    Task<User> findByEmail(String email);
    Task<User> Create(User user);
    Task<User> Persists(User user);
}