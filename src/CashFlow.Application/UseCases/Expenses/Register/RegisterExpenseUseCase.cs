using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validation(request);
        return new ResponseRegisterExpenseJson();
    }

    private void Validation(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            // I used LINQ here
            var errorMenssage = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrosOnValidationException(errorMenssage);
        }
    }
}
