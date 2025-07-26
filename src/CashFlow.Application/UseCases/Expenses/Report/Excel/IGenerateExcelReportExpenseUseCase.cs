namespace CashFlow.Application.UseCases.Expenses.Report.Excel;
public interface IGenerateExcelReportExpenseUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
