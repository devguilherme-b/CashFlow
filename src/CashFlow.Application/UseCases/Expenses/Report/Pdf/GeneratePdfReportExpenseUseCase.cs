using CashFlow.Application.UseCases.Expenses.Report.Pdf.Colors;
using CashFlow.Application.UseCases.Expenses.Report.Pdf.Fonts;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Extensions;
using CashFlow.Domain.Repositories.Expenses;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Expenses.Report.Pdf;
public class GeneratePdfReportExpenseUseCase : IGeneratePdfReportExpenseUseCase
{
    private const string CURRENCY_FORMAT = "R$";
    private const int HIGHT_ROW_EXPENSE_TABLE = 40;
    private readonly IExpensesReadOnlyRepository _repository;
    public GeneratePdfReportExpenseUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;

        GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
    }
    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);

        if (expenses.Count == 0)
            return [];

        var document = CreateDocument(month);

        var page = CreatePage(document);
        CreateHeaderWithProfilePhotoAndName(page);

        var totalExpenses = expenses.Sum(expense => expense.Amount);
        CreateParagraphWithTotalSpend(page, month, totalExpenses);

        foreach (var expense in expenses)
        {
            var table = CreateExpenseTable(page);

            var row = table.AddRow();

            AddExpenseTitle(row.Cells[0] ,expense.Title);

            row.Cells[3].AddParagraph(ResourceReportGenerateMessage.AMOUNT);
            AddStyleForAmountHeader(row.Cells[3]);

            row = table.AddRow();
            row.Cells[0].AddParagraph(expense.Date.ToString("D"));
            AddStyleForInformation(row.Cells[0]);

            row.Cells[1].AddParagraph(expense.Date.ToString("t"));
            AddStyleForInformation(row.Cells[1]);

            row.Cells[2].AddParagraph(expense.PaymentType.PaymentTypeToString());
            AddStyleForInformation(row.Cells[2]);

            if (string.IsNullOrWhiteSpace(expense.Description) == false)
            {
                var description = table.AddRow();

                description.Cells[0].AddParagraph(expense.Description);
                description.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 10, Color = ColorsHelp.BLACK };
                description.Format.Shading.Color = ColorsHelp.LIGHT_GRAY;
                description.VerticalAlignment = VerticalAlignment.Center;
                row.Cells[0].MergeRight = 2;
                row.Cells[3].MergeDown = 1;
            }

            row.Cells[3].AddParagraph($"-{expense.Amount} {CURRENCY_FORMAT}");
            AddStyleForAmount(row.Cells[3]);

            row = table.AddRow();
            row.Height = HIGHT_ROW_EXPENSE_TABLE;
        }

        return RenderDocument(document);
    }

    private Document CreateDocument(DateOnly month)
    {
        var document = new Document();

        document.Info.Title = $"{ResourceReportGenerateMessage.EXPENSE_FOR} {month:Y}";
        document.Info.Author = "Guilherme Barbosa - DEVguilherme";

        var style = document.Styles.Normal;
        style!.Font.Name = FontHelper.RALEWAY_REGULAR;
        style!.Font.Color = ColorsHelp.BLACK;

        return document;
    }
    private Section CreatePage(Document document)
    {
        var section = document.AddSection();

        section.PageSetup = document.DefaultPageSetup.Clone();
        section.PageSetup.PageFormat = PageFormat.A4;

        section.PageSetup.RightMargin = 40;
        section.PageSetup.LeftMargin = 40;
        section.PageSetup.TopMargin = 80;
        section.PageSetup.BottomMargin = 80;

        return section;
    }
    private void CreateHeaderWithProfilePhotoAndName(Section page)
    {
        var table = page.AddTable();
        table.AddColumn();
        table.AddColumn("300");

        var row = table.AddRow();

        var assembly = Assembly.GetExecutingAssembly();
        var directory = Path.GetDirectoryName(assembly.Location);
        var filePath = Path.Combine(directory!, "Logo", "logo.jpg");
        row.Cells[0].AddImage(filePath);

        row.Cells[1].AddParagraph("Hi, Guilherme Barbosa");
        row.Cells[1].Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 16 };
        row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
    }
    private void CreateParagraphWithTotalSpend(Section page, DateOnly month, decimal totalExpenses)
    {
        var paragraph = page.AddParagraph();

        paragraph.Format.SpaceBefore = "40";
        paragraph.Format.SpaceAfter = "40";

        var title = string.Format(ResourceReportGenerateMessage.TOTAL_SPEND_IN, month.ToString("Y"));
        paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });
        paragraph.AddLineBreak();
       
        paragraph.AddFormattedText($"{totalExpenses} {CURRENCY_FORMAT}", new Font { Name = FontHelper.WORKSANS_BLACK, Size = 40 });
    }
    private Table CreateExpenseTable(Section page)
    {
        var table = page.AddTable();

        table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
        table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;

        table.LeftPadding = 0;
        table.RightPadding = 0;
        table.BottomPadding = 0;
        table.TopPadding = 0;

        return table;
    }
    private void AddExpenseTitle(Cell cell, string title)
    {
        cell.AddParagraph(title);
        cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14, Color = ColorsHelp.BLACK };
        cell.Format.Shading.Color = ColorsHelp.LIGHT_RED;
        cell.VerticalAlignment = VerticalAlignment.Center;
        cell.MergeRight = 2;
    }
    private void AddStyleForAmountHeader(Cell cell)
    {
        cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14, Color = ColorsHelp.WHITE };
        cell.Format.Shading.Color = ColorsHelp.DARK_RED;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }
    private void AddStyleForInformation(Cell cell)
    {
      cell.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 12, Color = ColorsHelp.BLACK };
      cell.Format.Shading.Color = ColorsHelp.LIGHT_GREEN;
      cell.VerticalAlignment = VerticalAlignment.Center;
    }
    private void AddStyleForAmount(Cell cell)
    {
         cell.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 14, Color = ColorsHelp.DARK_RED };
         cell.Format.Shading.Color = ColorsHelp.WHITE;
         cell.VerticalAlignment = VerticalAlignment.Center;
    }
    private byte[] RenderDocument(Document document)
    {
        var renderer = new PdfDocumentRenderer
        {
            Document = document,
        };

        renderer.RenderDocument();

        using var file = new MemoryStream();
        renderer.PdfDocument.Save(file);

        return file.ToArray();
    }
}