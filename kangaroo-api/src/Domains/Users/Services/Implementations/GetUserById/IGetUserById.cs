using kangaroo_api.Domains.Users.Models;

namespace kangaroo_api.Domains.Users.Services.Implementations.GetUserById
{
    public interface IGetUserById
    {
        Task<User> execute(int id);
    }
}