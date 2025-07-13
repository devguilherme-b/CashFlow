using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesRepository
{
    void Add(Expense expense);
    //void Read(Expense expense);
    //void Update(Expense expense);
    //void Delete(Expense expense);
}
