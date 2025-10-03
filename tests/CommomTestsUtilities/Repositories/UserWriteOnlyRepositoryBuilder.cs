using CashFlow.Domain.Repositories.Users;
using Moq;

namespace CommomTestsUtilities.Repositories;
public static class UserWriteOnlyRepositoryBuilder
{
    public static IUserWriteOnlyRepository Build()
    {
        var userWriteOnlyRepository = new Mock<IUserWriteOnlyRepository>();
        return userWriteOnlyRepository.Object;
    }
}
