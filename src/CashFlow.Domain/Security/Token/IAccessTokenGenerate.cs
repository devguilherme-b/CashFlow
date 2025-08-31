using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Security.Token;
public interface IAccessTokenGenerate
{
    string Generate(User user);
}
