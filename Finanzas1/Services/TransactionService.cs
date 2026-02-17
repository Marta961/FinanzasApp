using Microsoft.EntityFrameworkCore;
using Finanzas1.Data;
using Finanzas1.Models;

namespace Finanzas1.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly FinanceContext _db;

        public TransactionService(FinanceContext db) => _db = db;

        public Task<List<Transaction>> GetAllAsync()
            => _db.Transactions.OrderByDescending(t => t.Date).ToListAsync();

        public async Task<Transaction> AddAsync(Transaction item)
        {
            _db.Transactions.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Transaction item)
        {
            _db.Transactions.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            if (entity is null) return;

            _db.Transactions.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
