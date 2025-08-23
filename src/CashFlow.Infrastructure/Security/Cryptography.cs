using CashFlow.Domain.Security.Cryptography;

namespace CashFlow.Infrastructure.Security;
internal class Cryptography : IPasswordEncripter
{
    public string Encrypter(string password)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword("my password"); 

        return passwordHash;
    }
}
