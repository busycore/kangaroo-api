using System.Net;
using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Repositories;
using kangaroo_api.Domains.Users.Services.Implementations.CreateUserService;
using kangaroo_api.Domains.Users.Services.Implementations.GetAllUsersService;
using kangaroo_api.Domains.Users.Services.Implementations.GetUserByEmailService;
using kangaroo_api.Domains.Users.Services.Implementations.GetUserById;
using kangaroo_api.shared.Configurations.Errors.Exceptions;

namespace kangaroo_api.Domains.Users.Services;

public class UserServices
{
    private readonly IGetAllUsersService getAllUsersService;
    private readonly IGetUserByEmailService getUserByEmailService;
    private readonly ICreateUserService createUserService;
    private readonly IGetUserById getUserByIdService;
    private readonly IUsersRepository usersRepository;
    public UserServices(IGetAllUsersService getAllUsersService, IGetUserByEmailService getUserByEmailService,ICreateUserService createUserService, IGetUserById getUserByIdService, IUsersRepository usersRepository)
    {
        this.getAllUsersService = getAllUsersService;
        this.getUserByEmailService = getUserByEmailService;
        this.createUserService = createUserService;
        this.getUserByIdService = getUserByIdService;
        this.usersRepository = usersRepository;
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
    async public Task<User> GetUserById(int id)
    {
        var userExists = await this.getUserByIdService.execute(id);
        if (userExists == null)
        {
            throw new HttpException(HttpStatusCode.NotFound, "User Not Found.");
        }
        return userExists;
    }
    async public Task<User> UpdateUser(int id, User user)
    {
        var userExists = await this.GetUserById(id);

        userExists.name = user.name;
        userExists.password = user.password;

        return await this.usersRepository.Persists(userExists);
    }
}