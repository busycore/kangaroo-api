using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Repositories;

namespace kangaroo_api.Domains.Users.Services.Implementations.GetAllUsersService;

public class GetAllUsersService : IGetAllUsersService
{
    private readonly IUsersRepository usersRepository;

    public GetAllUsersService(IUsersRepository usersRepository)
    {
        this.usersRepository = usersRepository;
    }

    public Task<List<User>> execute()
    {
        return this.usersRepository.findAll();
    }

}