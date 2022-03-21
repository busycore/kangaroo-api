namespace kangaroo_api.Domains.Users.dtos;

public class GetUserDTO
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
}