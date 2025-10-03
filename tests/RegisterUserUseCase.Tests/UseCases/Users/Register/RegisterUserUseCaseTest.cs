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
	}

	private RegisterUserUseCase CreateUseCaseInstance()
	{
		// Caso real
		var mapper = MapperBuilder.Build();

		// Mockando as dependências com a biblioteca Moq
		var unitOfWork = UnitOfWorkBuilder.Build();
		var userWriteOnlyRepositoryBuilder = UserWriteOnlyRepositoryBuilder.Build();
		var passwordEncripterBuilder = PasswordEncripterBuilder.Build();
		var accessTokenGenerateBuilder = AccessTokenGenerateBuilder.Build();

        return new RegisterUserUseCase(mapper, passwordEncripterBuilder, null, userWriteOnlyRepositoryBuilder, unitOfWork, accessTokenGenerateBuilder);
	}
}

