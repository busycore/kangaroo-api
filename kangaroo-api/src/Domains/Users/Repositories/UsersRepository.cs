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
    
    Task<User> IUsersRepository.findByEmail(String email)
    {
        Task<User> foundUser = this._context.Users.FirstOrDefaultAsync(user => user.email == email);
        return foundUser;
    }
    public async Task<User> Create(User user)
    {
        return await Task.Run(async () =>
        {
            var createdUser = this._context.Add(user);
            return await this.Persists(createdUser.Entity);
        });

    }
    
    public async Task<User> Persists(User user)
    {
        return await Task.Run(async () =>
        {
            await this._context.SaveChangesAsync();
            return user;
        });
    }
    
    public async Task<User> findById(int id)
    {
        return await this._context.Users.FirstOrDefaultAsync(user => user.id == id);
    }

}