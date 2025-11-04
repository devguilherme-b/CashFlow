namespace CashFlow.Domain.Security.Cryptography;
public interface IPasswordEncrypter
{
    string Encrypter(string password);
    bool Verify(string password, string passwordHash);
}
