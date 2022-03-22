using System.Net;
using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Services.Implementations.CreateUserService;
using kangaroo_api.Domains.Users.Services.Implementations.GetAllUsersService;
using kangaroo_api.Domains.Users.Services.Implementations.GetUserByEmailService;
using kangaroo_api.shared.Configurations.Errors.Exceptions;

namespace kangaroo_api.Domains.Users.Services;

public class UserServices
{
    private readonly IGetAllUsersService getAllUsersService;
    private readonly IGetUserByEmailService getUserByEmailService;
    private readonly ICreateUserService createUserService;
    
    public UserServices(IGetAllUsersService getAllUsersService, IGetUserByEmailService getUserByEmailService,ICreateUserService createUserService)
    {
        this.getAllUsersService = getAllUsersService;
        this.getUserByEmailService = getUserByEmailService;
        this.createUserService = createUserService;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await this.getAllUsersService.execute();
    }
    
    public async Task<User> GetUserByEmail(String email)
    {
        return await this.getUserByEmailService.execute(email);
    }
    
    async public Task<User> CreateUser(User user)
    {
        var userEmailAlreadyExists = await this.GetUserByEmail(user.email);
        if (userEmailAlreadyExists != null)
        {
            throw new HttpException(HttpStatusCode.Conflict, "This email is already registered.");
        }
        return await this.createUserService.execute(user);
    }
}