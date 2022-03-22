using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Services.Implementations.GetAllUsersService;
using kangaroo_api.Domains.Users.Services.Implementations.GetUserByEmailService;

namespace kangaroo_api.Domains.Users.Services;

public class UserServices
{
    private readonly IGetAllUsersService getAllUsersService;
    private readonly IGetUserByEmailService getUserByEmailService;
    
    public UserServices(IGetAllUsersService getAllUsersService, IGetUserByEmailService getUserByEmailService)
    {
        this.getAllUsersService = getAllUsersService;
        this.getUserByEmailService = getUserByEmailService;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await this.getAllUsersService.execute();
    }
    
    public async Task<User> GetUserByEmail(String email)
    {
        return await this.getUserByEmailService.execute(email);
    }
}