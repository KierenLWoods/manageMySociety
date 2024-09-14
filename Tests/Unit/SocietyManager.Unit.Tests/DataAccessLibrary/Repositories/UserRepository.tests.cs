using DataAccessLibrary.Repositories;
using Microsoft.VisualBasic;
using Moq;

public class UserRepositoryTests : IDisposable
{
    Mock<IUserRepository> mockObject;

    public UserRepositoryTests()
    {
        mockObject = new Mock<IUserRepository>();
        mockObject
            .Setup(userRepo => userRepo.InsertUserRecord(new UserSignUpModel { }))
            .ReturnsAsync(123);
    }

    public void Dispose() { }

    [Fact]
    public async void InsertUserRecordReturnsUserId()
    {
        // Given
        IUserRepository repository = mockObject.Object;
        // When
        int userId = await repository.InsertUserRecord(new UserSignUpModel { });

        // Then
        Assert.IsType<int>(userId);
    }
}
