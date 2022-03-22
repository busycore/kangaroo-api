using kangaroo_api.Domains.Users.Models;

namespace kangaroo_api.Domains.Users.Services.Implementations.CreateUserService
{
    public interface ICreateUserService
    {
        Task<User> execute(User user);
    }
}