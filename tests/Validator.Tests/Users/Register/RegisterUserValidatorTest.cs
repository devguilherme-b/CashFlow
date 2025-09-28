using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Exception;
using CommomTestsUtilities.Requests;
using Shouldly;

namespace Validator.Tests.Users.Register;
public class RegisterUserValidatorTest
{
    [Fact]
    public void SuccessUserValidator()
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
        request.Name = name; // Sobscreve o nome gerado com um InlineData

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);
        result.Errors.ShouldHaveSingleItem().ErrorMessage.Equals(ResourceErrorMessages.NAME_EMPTY);
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
        request.Email = email; // Sobscreve o email gerado com um InlineData

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);
        result.Errors.ShouldHaveSingleItem().ErrorMessage.Equals(ResourceErrorMessages.EMAIL_EMPTY);
    }

    [Fact]
    public void Error_Email_Invalid()
    {
        // Arrange
        var request = RequestRegisterUserJsonBuilder.Builder();
        var validator = new RegisterUserValidator();
        request.Email = "guilherme.gmail";

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);
        result.Errors.ShouldHaveSingleItem().ErrorMessage.Equals(ResourceErrorMessages.EMAIL_INVALID);
    }

    [Fact]
    public void Error_Password_Empty()
    {
        // Arrange
        var request = RequestRegisterUserJsonBuilder.Builder();
        var validator = new RegisterUserValidator();
        request.Password = "";

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);
        result.Errors.ShouldHaveSingleItem().ErrorMessage.Equals(ResourceErrorMessages.INVALID_PASSWORD);
    }

}
