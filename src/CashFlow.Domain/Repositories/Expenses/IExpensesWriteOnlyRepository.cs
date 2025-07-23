using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);

    /// <summary>
    /// This function returns TRUE if the deletions was successful otherwise returns False.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>True, False</returns>
    Task<bool> Delete(long id);
}
