using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Report.Excel;
public class GenerateExcelReportExpenseUseCase : IGenerateExcelReportExpenseUseCase
{
    private const string CURRENCY_FORMAT = "R$";
    private readonly IExpensesReadOnlyRepository _repository;
    public GenerateExcelReportExpenseUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }
    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);

        if (expenses.Count == 0)
            return [];

        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        InsertFormat(workbook);
        InsertHeader(worksheet);

        var line = 2;
        foreach (var expense in expenses)
        {
            worksheet.Cell($"A{line}").Value = expense.Title;
            worksheet.Cell($"B{line}").Value = expense.Date;
            worksheet.Cell($"C{line}").Value = expense.Amount;

            worksheet.Cell($"C{line}").Style.NumberFormat.Format = $"- {CURRENCY_FORMAT} #,##0.00";

            worksheet.Cell($"D{line}").Value = ConvertPaymentType(expense.PaymentType);
            worksheet.Cell($"E{line}").Value = expense.Description;

            worksheet.Cells($"A{line}:E{line}").Style.Fill.BackgroundColor = XLColor.FromHtml("#F2F2F2");

            worksheet.Cells($"A{line}:B{line}").Style.Font.FontColor = XLColor.FromHtml("#161616");
            worksheet.Cell($"C{line}").Style.Font.FontColor = XLColor.FromHtml("#FF0000");
            worksheet.Cells($"D{line}:E{line}").Style.Font.FontColor = XLColor.FromHtml("#161616");

            line++;
        }

        worksheet.Columns().AdjustToContents();

        var file = new MemoryStream();
        workbook.SaveAs(file);

        return file.ToArray();
    }
    private string ConvertPaymentType(PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash => ResourceReportGenerateMessage.CASH,
            PaymentType.CreditCard => ResourceReportGenerateMessage.CREDITCARD,
            PaymentType.DebitCard => ResourceReportGenerateMessage.DEBITCARD,
            PaymentType.EletronicTransfer => ResourceReportGenerateMessage.ELETRONICTRANSFER,
            PaymentType.Pix => ResourceReportGenerateMessage.PIX,
            _ => string.Empty
        };
    }
    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = ResourceReportGenerateMessage.TITLE;
        worksheet.Cell("B1").Value = ResourceReportGenerateMessage.DATE;
        worksheet.Cell("C1").Value = ResourceReportGenerateMessage.AMOUNT;
        worksheet.Cell("D1").Value = ResourceReportGenerateMessage.PAYMENT_TYPE;
        worksheet.Cell("E1").Value = ResourceReportGenerateMessage.DESCRIPTION;

        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#5C0000");
        worksheet.Cells("A1:E1").Style.Font.FontColor = XLColor.FromHtml("#F2F2F2");
        worksheet.Cells("A1:E1").Style.Font.Bold = true;

        worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }
    private void InsertFormat(XLWorkbook workbook)
    {
        workbook.Author = "Guilherme Barbosa - DEVguilherme";
        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Times New Roman";
    }
}