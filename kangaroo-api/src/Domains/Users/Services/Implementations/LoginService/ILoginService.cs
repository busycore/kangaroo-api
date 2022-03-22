using kangaroo_api.Domains.Users.Models;

namespace kangaroo_api.Domains.Users.Services.Implementations.LoginService;

public interface ILoginService
{
    string execute(User user);
}