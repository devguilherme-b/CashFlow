using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;

namespace CashFlow.Domain.Extensions;
public static class PaymentTypeExtensions
{
    public static string PaymentTypeToString(this PaymentType paymentType)
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
}
