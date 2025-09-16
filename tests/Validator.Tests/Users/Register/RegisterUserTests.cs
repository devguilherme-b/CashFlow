using CashFlow.Application.UseCases.Users.Register;
using CommomTestsUtilities.Requests;

namespace Validator.Tests.Users.Register;
public class RegisterUserTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var request = RequestRegisterUserJsonBuilder.Builder();
        var validator = new RegisterUserValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("           ")]
    public void Error_Name_Empty(string name)
    {
        // Arrange
        var request = RequestRegisterUserJsonBuilder.Builder();
        var validator = new RegisterUserValidator();
        request.Name = name;

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("           ")]
    public void Error_Email_Empty(string email)
    {
        // Arrange
        var request = RequestRegisterUserJsonBuilder.Builder();
        var validator = new RegisterUserValidator();
        request.Email = email;

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);
    }
}
