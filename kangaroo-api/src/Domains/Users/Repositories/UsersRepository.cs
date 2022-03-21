using kangaroo_api.Domains.Users.Models;
using kangaroo_api.shared.Configurations.DatabaseConfigurations;
using Microsoft.EntityFrameworkCore;

namespace kangaroo_api.Domains.Users.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly DataContext _context;

    public UsersRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<User>> findAll()
    {
        return await this._context.Users.AsNoTracking().ToListAsync();
    }
    
    
}