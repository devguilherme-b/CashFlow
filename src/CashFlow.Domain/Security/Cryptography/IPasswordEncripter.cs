namespace CashFlow.Domain.Security.Cryptography;
public interface IPasswordEncripter
{
    string Encrypter(string password);
    bool Verify(string password, string passwordHash);
}
