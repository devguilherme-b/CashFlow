namespace CashFlow.Domain.Security.Cryptography;
public interface IPasswordEncripter
{
    string Encrypter(string password);
}
