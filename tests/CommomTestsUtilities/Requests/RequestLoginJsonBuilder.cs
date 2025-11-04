using Bogus;
using CashFlow.Communication.Requests;
using System.Net.NetworkInformation;

namespace CommomTestsUtilities.Requests;
public class RequestLoginJsonBuilder
{
    public static RequestLoginJson Build()
    {
        return new Faker<RequestLoginJson>()
            .RuleFor(config => config.Password, faker => faker.Internet.Password(prefix: "@Gu8"))
            .RuleFor(config => config.Email, faker => faker.Person.Email);
    }
}
