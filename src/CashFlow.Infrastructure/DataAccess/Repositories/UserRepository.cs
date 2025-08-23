using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly CashFlowDbContext _dbcontext;
    public UserRepository(CashFlowDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task Add(User user)
    {
        await _dbcontext.Users.AddAsync(user);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbcontext.Users.AnyAsync(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)); // Using OrdinalIgnoreCase to ensure email comparison is case-insensitive and culture-invariant
    }
}
