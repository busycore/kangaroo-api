using AutoMapper;
using kangaroo_api.Domains.Users.dtos;
using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace kangaroo_api.Domains.Users.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserServices userServices;
    private readonly IMapper mapper;


    public UsersController(UserServices userServices, IMapper mapper)
    {
        this.userServices = userServices;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        List<User> listOfUsers = await this.userServices.GetAllUsers();
        return Ok(listOfUsers.Select(user => this.mapper.Map<GetUserDTO>(user)).ToList());
    }    
}