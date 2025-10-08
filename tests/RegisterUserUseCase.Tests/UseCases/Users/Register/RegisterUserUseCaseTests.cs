using CashFlow.Application.UseCases.Users.Register;
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

	private RegisterUserUseCase CreateUseCaseInstance()
	{
		// Caso real
		var loggerFactory= LoggerFactoryBuilder.Build(); // Mockando o LoggerFactory (Eu improvisei aqui - pois no curso não tinha essa parte)
        var mapper = MapperBuilder.Build(loggerFactory);

		// Mockando as dependências com a biblioteca Moq
		var unitOfWork = UnitOfWorkBuilder.Build();
		var userWriteOnlyRepositoryBuilder = UserWriteOnlyRepositoryBuilder.Build();
		var passwordEncripterBuilder = PasswordEncripterBuilder.Build();
		var accessTokenGenerateBuilder = AccessTokenGenerateBuilder.Build();
		var userReadOnlyRepository = new UserReadOnlyRepositoryBuilder().Build();

        return new RegisterUserUseCase(mapper, passwordEncripterBuilder, userReadOnlyRepository, userWriteOnlyRepositoryBuilder, unitOfWork, accessTokenGenerateBuilder);
	}
}

