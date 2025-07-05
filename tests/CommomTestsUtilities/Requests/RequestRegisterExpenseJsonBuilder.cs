using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommomTestsUtilities.Requests;
public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(regra => regra.Title, faker => faker.Commerce.ProductName())
            .RuleFor(regra => regra.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(regra => regra.Date, faker => faker.Date.Past())
            .RuleFor(regra => regra.PaymentType, faker => faker.Random.Enum<PaymentType>())
            .RuleFor(regra => regra.Amount, faker => faker.Random.Decimal(min: 1, max: 2000));
    }
}
