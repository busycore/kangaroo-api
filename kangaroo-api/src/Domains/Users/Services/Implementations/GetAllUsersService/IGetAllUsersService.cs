using kangaroo_api.Domains.Users.Models;

namespace kangaroo_api.Domains.Users.Services.Implementations.GetAllUsersService;

public interface IGetAllUsersService
{
    Task<List<User>> execute();

}