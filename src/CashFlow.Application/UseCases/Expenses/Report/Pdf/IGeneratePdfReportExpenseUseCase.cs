namespace CashFlow.Application.UseCases.Expenses.Report.Pdf;
public interface IGeneratePdfReportExpenseUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
