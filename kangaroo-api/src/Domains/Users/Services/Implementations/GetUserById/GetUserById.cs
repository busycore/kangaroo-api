using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Repositories;

namespace kangaroo_api.Domains.Users.Services.Implementations.GetUserById
{
    public class GetUserById : IGetUserById
    {
        private readonly IUsersRepository usersRepository;

        public GetUserById(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<User> execute(int id)
        {
            return await this.usersRepository.findById(id);
        }
    }
}