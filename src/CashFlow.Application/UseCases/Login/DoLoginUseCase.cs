using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Token;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Login;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerate _accessTokenGenerate;

    public DoLoginUseCase(
        IUserReadOnlyRepository repository, 
        IPasswordEncripter passwordEncripter, 
        IAccessTokenGenerate accessTokenGenerate)
    {
        _repository = repository;
        _passwordEncripter = passwordEncripter;
        _accessTokenGenerate = accessTokenGenerate;
    }
    public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);
        if (user is null)
            throw new InvalidLoginException();

        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);
        if (passwordMatch == false)
            throw new InvalidLoginException();

        return new ResponseRegisterUserJson
        {
            Name = user.Name,
            Token = _accessTokenGenerate.Generate(user)
        };
    }
}
