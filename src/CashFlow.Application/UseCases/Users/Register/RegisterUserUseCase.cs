using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Exception;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Users.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncripter, IUserReadOnlyRepository userReadOnlyRepository)
    {
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestUserJson request)
    {
        await Validate(request);

        var user = _mapper.Map<User>(request);
        user.Password = _passwordEncripter.Encrypter(request.Password); // Encrypt the password

        return new ResponseRegisterUserJson
        {
            Name = request.Name
        };
    }

    private async Task Validate(RequestUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_EXISTS));
        }

        if (!result.IsValid)
        {
            var errorMenssage = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new Exception.ExceptionBase.ErrosOnValidationException(errorMenssage);
        }
    }

}
