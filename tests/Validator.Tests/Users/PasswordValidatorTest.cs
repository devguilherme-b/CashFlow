using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests;
using FluentValidation;

namespace Validator.Tests.Users;
public class PasswordValidatorTest
{
    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("g")]
    [InlineData("gg")]
    [InlineData("ggg")]
    [InlineData("gggg")]
    [InlineData("ggggg")]
    [InlineData("gggggg")]
    [InlineData("ggggggg")]
    [InlineData("gggggggg")]
    [InlineData("GGGGGGGG")]
    [InlineData("GGGGgggg")]
    [InlineData("GGGGgg58")]
    public void Error_Password_Invalid(string password)
    {
        // Arrange
        var validator = new PasswordValidator<RequestUserJson>();

        // Act
        var result = validator
            .IsValid(new ValidationContext<RequestUserJson>(new RequestUserJson()), password);

        // Assert
        Assert.False(result);
    }
}
