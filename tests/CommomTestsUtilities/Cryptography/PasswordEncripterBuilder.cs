using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommomTestsUtilities.Cryptography;
public static class PasswordEncripterBuilder
{
    public static IPasswordEncripter Build()
    {
        var passwordEncripter = new Mock<IPasswordEncripter>();

        // Ensinando o mock a retornar uma senha encriptada qualquer
        passwordEncripter
            .Setup(config => config.Encrypter(It.IsAny<string>()))
            .Returns("!@Builder123");
        passwordEncripter
            .Setup(config => config.Verify(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        return passwordEncripter.Object;
    }
}
