using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using kangaroo_api.Domains.Users.Models;
using Microsoft.IdentityModel.Tokens;

namespace kangaroo_api.Domains.Users.Services.Implementations.LoginService;

public class LoginService : ILoginService
{
    private readonly IConfiguration _configuration;

    public LoginService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string execute(User user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.name),
            new Claim(ClaimTypes.Role,"Admin")
        };

        String JwtSecret = _configuration.GetSection("Security:JWT_SECRET").Value;
            
        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(JwtSecret));
        
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        
        var Token = new JwtSecurityToken(claims: claims, 
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials:credentials);

        string jwt = new JwtSecurityTokenHandler().WriteToken(Token);
            
        return jwt;
    }
}