using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase : IRegisterExpensesUseCase
{
    private readonly IExpensesRepository _repository;
    public RegisterExpenseUseCase(IExpensesRepository repository)
    {
        _repository = repository;
    }
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validation(request);

        var identify = new Expense { 
            Title = request.Title,
            Description = request.Description,
            Date = request.Date,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
            Amount = request.Amount
        };

        _repository.Add(identify);

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
