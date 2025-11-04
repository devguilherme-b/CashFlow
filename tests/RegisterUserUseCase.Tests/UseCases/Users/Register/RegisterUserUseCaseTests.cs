using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using CommomTestsUtilities.Cryptography;
using CommomTestsUtilities.Mapper;
using CommomTestsUtilities.Repositories;
using CommomTestsUtilities.Requests;
using CommomTestsUtilities.Token;

namespace RegisterUserUseCasesTests.UseCases.Users.Register;
public class RegisterUserUseCaseTests
{
	[Fact]
	public async Task Success()
	{
		// Arrange
		var useCase = CreateUseCaseInstance();
		var request = RequestRegisterUserJsonBuilder.Builder();

		// Act
		var result = await useCase.Execute(request);

		// Assert
		Assert.Equal(request.Name, result.Name);
        Assert.NotNull(result.Token);
    }

	[Fact]
	public async Task Error_Name_Empty()
    {
		// Arrange
		var request = RequestRegisterUserJsonBuilder.Builder();
		request.Email = string.Empty;
		var useCase = CreateUseCaseInstance();

		// Act
		var act = async () => await useCase.Execute(request);
		// Assert
		var result = await Assert.ThrowsAsync<ErrosOnValidationException>(act);
		result.GetErrors().Where(ex => ex.Count() == 1 && ex.Contains(ResourceErrorMessages.NAME_EMPTY));

    }

	[Fact]
	public async Task Error_Email_Already_Exist()
	{
		// Arrange
        var request = RequestRegisterUserJsonBuilder.Builder();
		var useCase = CreateUseCaseInstance(request.Email);

        // Act
        var act = async () => await useCase.Execute(request);

        // Assert
		var result = await Assert.ThrowsAsync<ErrosOnValidationException>(act);
        result.GetErrors().Where(ex => ex.Count() == 1 && ex.Contains(ResourceErrorMessages.EMAIL_ALREADY_EXISTS));
    }

    private RegisterUserUseCase CreateUseCaseInstance(string? email = null)
	{
		// Caso real
		var loggerFactory= LoggerFactoryBuilder.Build(); // Mockando o LoggerFactory (Eu improvisei aqui - pois no curso não tinha essa parte)
        var mapper = MapperBuilder.Build(loggerFactory);

		// Mockando as dependências com a biblioteca Moq
		var unitOfWork = UnitOfWorkBuilder.Build();
		var userWriteOnlyRepositoryBuilder = UserWriteOnlyRepositoryBuilder.Build();
		var passwordEncripterBuilder = new PasswordEncrypterBuilder().Build();
		var accessTokenGenerateBuilder = AccessTokenGenerateBuilder.Build();
		var userReadOnlyRepository = new UserReadOnlyRepositoryBuilder();

		if (string.IsNullOrWhiteSpace(email) == false)
		{
			userReadOnlyRepository.ExistActiveUserWithEmail(email);

        }

        return new RegisterUserUseCase(mapper, passwordEncripterBuilder, userReadOnlyRepository.Build(), userWriteOnlyRepositoryBuilder, unitOfWork, accessTokenGenerateBuilder);
	}
}

