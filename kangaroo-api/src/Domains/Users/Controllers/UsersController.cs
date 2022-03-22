using AutoMapper;
using kangaroo_api.Domains.Users.dtos;
using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Repositories;
using kangaroo_api.Domains.Users.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        List<User> listOfUsers = await this.userServices.GetAllUsers();
        return Ok(listOfUsers.Select(user => this.mapper.Map<GetUserDTO>(user)).ToList());
    }    
    
    [HttpPost]
    public async Task<ActionResult<GetUserDTO>> CreateUser(CreateUserDTO userDTO)
    {
        User user = this.mapper.Map<User>(userDTO);
        GetUserDTO createdUser = this.mapper.Map<GetUserDTO>(await this.userServices.CreateUser(user));
        return StatusCode(201, createdUser);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<GetUserDTO>> UpdateUser(int id, CreateUserDTO userDTO)
    {
        User user = this.mapper.Map<User>(userDTO);
        return StatusCode(200, this.mapper.Map<GetUserDTO>(await this.userServices.UpdateUser(id, user)));
    }
    
    [HttpPost("login/")]
    public async Task<ActionResult<String>> UserLogin(UserLoginDTO user)
    {
        return StatusCode(200,await this.userServices.login(user.email,user.password)) ;
    }


}