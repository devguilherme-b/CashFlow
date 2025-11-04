using CashFlow.Application.UseCases.Login;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using CommomTestsUtilities.Cryptography;
using CommomTestsUtilities.Entities;
using CommomTestsUtilities.Repositories;
using CommomTestsUtilities.Requests;
using CommomTestsUtilities.Token;
using Shouldly;

namespace UseCases.Tests.Login.DoLogin;
public class DoLoginUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        // Arrange
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;
        var usesCase = CreateUseCaseInstance(user, request.Password);
        // Act
        var result = await usesCase.Execute(request);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(user.Name, result.Name);
        Assert.False(string.IsNullOrWhiteSpace(result.Token));
    }

    [Fact]
    public async Task Error_User_Not_Found()
    {
        // Arrange
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        var usesCase = CreateUseCaseInstance(user, request.Password);
        // Act
        var act = async () => await usesCase.Execute(request);
        var result = await act.ShouldThrowAsync<InvalidLoginException>();
        // Assert
        Assert.True(result.GetErrors().Count == 1 && result.GetErrors().Contains(ResourceErrorMessages.INVALID_EMAIL_OR_PASSWORD));
    }

    [Fact]
    public async Task Error_Password_Not_Match()
    {
        // Arrange
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;
        var usesCase = CreateUseCaseInstance(user);
        // Act
        var act = async () => await usesCase.Execute(request);
        var result = await act.ShouldThrowAsync<InvalidLoginException>();
        // Assert
        Assert.True(result.GetErrors().Count == 1 && result.GetErrors().Contains(ResourceErrorMessages.INVALID_EMAIL_OR_PASSWORD));
    }

    private DoLoginUseCase CreateUseCaseInstance(CashFlow.Domain.Entities.User user, string? password = null)
    {
        var readOnlyRepository = new UserReadOnlyRepositoryBuilder().GetUserByEmail(user).Build();
        var passwordEncrypter = new PasswordEncrypterBuilder().Verify(password).Build();
        var tokenGenerator = AccessTokenGenerateBuilder.Build();

        return new DoLoginUseCase(readOnlyRepository, passwordEncrypter, tokenGenerator);
    }
}
