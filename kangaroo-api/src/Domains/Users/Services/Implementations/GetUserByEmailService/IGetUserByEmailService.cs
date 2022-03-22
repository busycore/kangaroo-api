using kangaroo_api.Domains.Users.Models;

namespace kangaroo_api.Domains.Users.Services.Implementations.GetUserByEmailService
{
    public interface IGetUserByEmailService
    {
        Task<User> execute(String email);
    }
}