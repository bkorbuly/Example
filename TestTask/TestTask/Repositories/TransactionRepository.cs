using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Entities;
using TestTask.Models;

namespace TestTask.Repositories
{
    public class TransactionRepository
    {
        TransactionContext _transactionContext;

        public TransactionRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public void Add(Transaction transaction)
        {
            _transactionContext.Transactions.Add(transaction);
            _transactionContext.SaveChanges();
        }
    }
}
