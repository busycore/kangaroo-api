using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Repositories;

namespace kangaroo_api.Domains.Users.Services.Implementations.GetUserByEmailService
{
    public class GetUserByEmailService : IGetUserByEmailService
    {

        private readonly IUsersRepository usersRepository;

        public GetUserByEmailService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public Task<User> execute(string email)
        {
            return this.usersRepository.findByEmail(email);
        }
    }
}