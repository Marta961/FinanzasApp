using Finanzas1.Models;

namespace Finanzas1.Services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction> AddAsync(Transaction item);
        Task UpdateAsync(Transaction item);
        Task DeleteAsync(int id);
    }
}
