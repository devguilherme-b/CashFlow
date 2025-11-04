using Bogus;
using CashFlow.Domain.Entities;
using CommomTestsUtilities.Cryptography;
namespace CommomTestsUtilities.Entities;
public class UserBuilder
{
    public static User Build()
    {
        var passwordEncrypter = new PasswordEncrypterBuilder().Build();
        var user = new Faker<User>()
            .RuleFor(u => u.Id, _ => 1)
            .RuleFor(u => u.Name, faker => faker.Person.FirstName)
            .RuleFor(u => u.Email, (faker, user) => faker.Person.Email)
            .RuleFor(u => u.Password, (_, user) => passwordEncrypter.Encrypter(user.Password))
            .RuleFor(u => u.UserIdentifier, _ => Guid.NewGuid());

        return user;
    }
}
