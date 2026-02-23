using Castle.Core.Configuration;
using Moq;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.UsersRepository;
using StudentGradebookApi.Services.UserServices;
using StudentGradebookApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradebookApi.Tests.Services.User
{
    public class GetUserAsyncTests
    {
        private readonly Mock<IUsersRepository> _mockUserRepo;
        private readonly UserService _userService;

        public GetUserAsyncTests()
        {
            _mockUserRepo = new Mock<IUsersRepository>();
            _userService = new UserService(null, _mockUserRepo.Object);
        }

        public static class UserBuilder
        {
            public static WebUsers Build()
            {
                return new WebUsers
                {
                    Id = 1,
                    Email = "email@email.com",
                    Role = "demo",
                };
            }
        }
        
        [Fact]
        public async Task GetUserByIdAsync_ValidId_ReturnsWebUsers()
        {
            //Arrange
            var user = UserBuilder.Build();
            _mockUserRepo.Setup(user => user.GetByIdAsync(1))
                .ReturnsAsync(user);

            //Act
            var result = await _userService.GetUserByIdAsync(1);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Equal(1, result.Data.Id);
            _mockUserRepo.Verify(repo => repo.GetByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetUserByIdAsync_WhenUserDoesNotExist_ReturnsFailure()
        {
            //Arrange
            _mockUserRepo.Setup(user => user.GetByIdAsync(1))
                .ReturnsAsync((WebUsers)null);

            //Act
            var result = await _userService.GetUserByIdAsync(1);

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(Errors.UserErrors.UserNotFound, result.Error);
            _mockUserRepo.Verify(repo => repo.GetByIdAsync(1), Times.Once);
        }
    }
}
