using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Expenses.GetById;
public interface IGetByIdExpenseUseCase
{
    Task<ResponseExpenseJson> Execute(long id);
}
