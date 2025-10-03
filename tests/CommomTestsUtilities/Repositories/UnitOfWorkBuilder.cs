using CashFlow.Domain.Repositories;
using Moq;

namespace CommomTestsUtilities.Repositories;
public static class UnitOfWorkBuilder
{
    public static IUnitOfWork Build()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        return unitOfWork.Object;
    }
}
