using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Services.Implementations.GetAllUsersService;

namespace kangaroo_api.Domains.Users.Services;

public class UserServices
{
    private readonly IGetAllUsersService getAllUsersService;

    public UserServices(IGetAllUsersService getAllUsersService)
    {
        this.getAllUsersService = getAllUsersService;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await this.getAllUsersService.execute();
    }
}