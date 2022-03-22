using System.Text;
using kangaroo_api.Domains.Users.Repositories;
using kangaroo_api.Domains.Users.Services;
using kangaroo_api.Domains.Users.Services.Implementations.CreateUserService;
using kangaroo_api.Domains.Users.Services.Implementations.GetAllUsersService;
using kangaroo_api.Domains.Users.Services.Implementations.GetUserByEmailService;
using kangaroo_api.Domains.Users.Services.Implementations.GetUserById;
using kangaroo_api.Domains.Users.Services.Implementations.LoginService;
using kangaroo_api.shared.Configurations.DatabaseConfigurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<IGetAllUsersService, GetAllUsersService>();
builder.Services.AddTransient<IGetUserByEmailService, GetUserByEmailService>();
builder.Services.AddTransient<ICreateUserService, CreateUserService>();
builder.Services.AddTransient<IGetUserById, GetUserById>();
builder.Services.AddTransient<ILoginService, LoginService>();

//Repositories
builder.Services.AddTransient<IUsersRepository, UsersRepository>();


//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Database
builder.Services.AddDbContext<DataContext>(options =>
{
    var connection = builder.Configuration.GetConnectionString("SqliteConnection");
    options.UseSqlite(connection);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Security:JWT_SECRET").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
