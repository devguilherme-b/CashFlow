using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Application.UseCases.Users.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    public RegisterUserUseCase(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestUserJson request)
    {
        Validate(request);

        var entity = _mapper.Map<User>(request);

        return new ResponseRegisterUserJson
        {
            Name = request.Name
        };
    }

    private void Validate(RequestUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        if (!result.IsValid)
        {
            var errorMenssage = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new Exception.ExceptionBase.ErrosOnValidationException(errorMenssage);
        }
    }

}
