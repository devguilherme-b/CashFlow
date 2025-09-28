using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.Register;
public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED);
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_EMPTY)
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator) // O CurrentValidator sempre será o validador acima da linha do CurrentValidator, ou seja, o EmailAddress
            .WithMessage(ResourceErrorMessages.EMAIL_INVALID);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestUserJson>());
    }
}
