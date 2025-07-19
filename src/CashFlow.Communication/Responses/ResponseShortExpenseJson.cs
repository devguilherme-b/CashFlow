using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Responses;
public class ResponseShortExpenseJson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
