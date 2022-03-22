using System.Collections.Generic;
using System.Threading.Tasks;
using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Repositories;
using kangaroo_api.Domains.Users.Services.Implementations.GetAllUsersService;
using Moq;
using Xunit;

namespace DefaultNamespace;

public class GetAllUsersServiceTest
{
    
    private Mock<IUsersRepository> _usersRepository;
    private GetAllUsersService getAllUsersService;
    private List<User> mockedUserList = new List<User>()
    {
        new User() {id=1,name="John",email="john@john.com",password="123"},
        new User() {id=2,name="Marie",email="marie@marie.com",password="321"},
        new User() {id=3,name="Will",email="william@will.com",password="231"},
    };

    public GetAllUsersServiceTest()
    {
        {
            _usersRepository = new Mock<IUsersRepository>();
            _usersRepository.Setup(repository => repository.findAll())
                .Returns(Task.FromResult(mockedUserList));
            getAllUsersService = new GetAllUsersService(_usersRepository.Object);
        }
    }

    [Fact(DisplayName = "Should be able to get user by using the user id")]
    public async void ShouldReturnUserById()
    {
        //Arrange
        
        //Act
        List<User> returnedList = await getAllUsersService.execute();
        //Assert
        Assert.Equal(mockedUserList,returnedList);
    }
}