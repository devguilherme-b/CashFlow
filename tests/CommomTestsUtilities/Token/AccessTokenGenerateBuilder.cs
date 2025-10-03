using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Token;
using Moq;

namespace CommomTestsUtilities.Token;
public static class AccessTokenGenerateBuilder
{
    public static IAccessTokenGenerate Build()
    {
        var accessTokenGenerate = new Mock<IAccessTokenGenerate>();

        accessTokenGenerate
            .Setup(config => config.Generate(It.IsAny<User>())).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.KMUFsIDTnFmyG3nMiGM6H9FNFUROf3wh7SmqJp-QV30");

        return accessTokenGenerate.Object;
    }
}
