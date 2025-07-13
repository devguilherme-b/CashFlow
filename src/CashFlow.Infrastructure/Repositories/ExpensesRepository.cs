using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Infrastructure.Repositories;
internal class ExpensesRepository : IExpensesRepository
{
    public void Add(Expense expense)
    {
        var dbContext = new CashFlowDbContext();

        dbContext.Add(expense);

        dbContext.SaveChanges();
    }
}
