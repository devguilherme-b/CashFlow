using Microsoft.Extensions.Logging;
using Moq;

namespace CommomTestsUtilities.Mapper;
public static class LoggerFactoryBuilder
{
    public static ILoggerFactory Build()
    {
        var loggerFactory = new Mock<ILoggerFactory>();
        loggerFactory
            .Setup(config => config.CreateLogger(It.IsAny<string>()))
            .Returns(new Mock<ILogger>().Object);

        return loggerFactory.Object;
    }
}
