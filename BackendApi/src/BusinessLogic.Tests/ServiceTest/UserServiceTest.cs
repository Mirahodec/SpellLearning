using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;

namespace BusinessLogic.Tests.ServiceTest
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsyncNullUserShouldThrowArgumentNullException()
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            // arrange
            var newUser = new User()
            {
                Username = "testuser",
                Email = "test@example.com",
                PasswordHash = "hashedpassword"
                // остальные поля можно оставить по умолчанию
            };

            // act
            await service.Create(newUser);

            // assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser()
        {
            // arrange
            var newUser = new User()
            {
                Username = "",
                Email = "",
                PasswordHash = ""
            };

            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            // assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        // Данные для Theory-теста
        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new User() { Username = "", Email = "valid@example.com", PasswordHash = "pass" } },
                new object[] { new User() { Username = "user", Email = "", PasswordHash = "pass" } },
                new object[] { new User() { Username = "user", Email = "valid@example.com", PasswordHash = "" } },
                new object[] { new User() { Username = null!, Email = "valid@example.com", PasswordHash = "pass" } },
                new object[] { new User() { Username = "user", Email = null!, PasswordHash = "pass" } },
                new object[] { new User() { Username = "user", Email = "valid@example.com", PasswordHash = null! } }
            };
        }
    }
}