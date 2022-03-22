using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Repositories;

namespace kangaroo_api.Domains.Users.Services.Implementations.CreateUserService
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IUsersRepository usersRepository;

        public CreateUserService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public Task<User> execute(User user)
        {
            return this.usersRepository.Create(user);
        }
    }
}