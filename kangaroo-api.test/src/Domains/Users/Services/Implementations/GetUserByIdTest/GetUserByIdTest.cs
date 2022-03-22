using System.Collections.Generic;
using System.Threading.Tasks;
using kangaroo_api.Domains.Users.Models;
using kangaroo_api.Domains.Users.Repositories;
using kangaroo_api.Domains.Users.Services.Implementations.GetUserById;
using Moq;
using Xunit;

namespace kangaroo_api.test.Domains.Users.Services.Implementations.GetUserByIdTest;

public class GetUserByIdTest
{
    private Mock<IUsersRepository> _usersRepository;
    private GetUserById getUserByIdService;
    
    public GetUserByIdTest()
    {
        var mockedUserList = new List<User>()
        {
            new User() {id=1,name="John",email="john@john.com",password="123"},
            new User() {id=2,name="Marie",email="marie@marie.com",password="321"},
            new User() {id=3,name="Will",email="william@will.com",password="231"},
        };
        
        
        _usersRepository = new Mock<IUsersRepository>();
        _usersRepository.Setup(repository => repository.findById(It.IsAny<int>()))
            .Returns(Task.FromResult(mockedUserList[1]));
        getUserByIdService = new GetUserById(_usersRepository.Object);
    }

    [Fact(DisplayName = "Should be able to get user by using the user id")]
    public async void ShouldReturnUserById()
    {
        //Arrange
        
        //Act
        User returnedUser = await getUserByIdService.execute(2);
        //Assert
        Assert.Equal("Marie",returnedUser.name);
    }
}