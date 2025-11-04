using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommomTestsUtilities.Cryptography;
public class PasswordEncrypterBuilder
{
    private readonly Mock<IPasswordEncrypter> _mock;

    public PasswordEncrypterBuilder()
    {
        _mock = new Mock<IPasswordEncrypter>();

        // Ensinando o mock a retornar uma senha encriptada qualquer
        _mock.Setup(passwordEncrypter => passwordEncrypter.Encrypter(It.IsAny<string>())).Returns("!@dGui98gR3"); ;
    }

    public PasswordEncrypterBuilder Verify(string? password = null)
    {
        if(string.IsNullOrWhiteSpace(password) is false)
            _mock.Setup(passwordEncrypter => passwordEncrypter.Verify(password, It.IsAny<string>())).Returns(true);

        return this;
    }

    public IPasswordEncrypter Build() => _mock.Object;
}
