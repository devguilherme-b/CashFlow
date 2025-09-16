using Bogus;
using CashFlow.Communication.Requests;
using System.Net.NetworkInformation;

namespace CommomTestsUtilities.Requests;
public class RequestRegisterUserJsonBuilder
{
    public static RequestUserJson Builder()
    {
        return new Faker<RequestUserJson>()
            .RuleFor(faker => faker.Name, faker => faker.Person.FirstName)
            .RuleFor(faker => faker.Email, faker => faker.Person.Email)
            .RuleFor(faker => faker.Password, faker => faker.Internet.Password(prefix: "@!Gu"));
    }
}
