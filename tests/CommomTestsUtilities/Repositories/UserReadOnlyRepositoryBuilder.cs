using CashFlow.Domain.Repositories.Users;
using Moq;

namespace CommomTestsUtilities.Repositories;
public class UserReadOnlyRepositoryBuilder
{
    private readonly Mock<IUserReadOnlyRepository> _repository;
    public UserReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<IUserReadOnlyRepository>();
    }

    public IUserReadOnlyRepository Build()
    {
        return _repository.Object;
    }
}