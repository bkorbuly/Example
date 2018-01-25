using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Entities;
using TestTask.Interfaces;
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

        public void Add(ITransaction transaction)
        {
            if(transaction.GetType() == typeof(NewTransaction))
                _transactionContext.NewTransactions.Add((NewTransaction)transaction);
            else
                _transactionContext.Transactions.Add((Transaction)transaction);
            _transactionContext.SaveChanges();

        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactionContext.Transactions.Select(x => x).ToList();
        }

        public List<NewTransaction> GetAllNewTransactions()
        {
            return _transactionContext.NewTransactions.Select(x => x).ToList();
        }

        public void Delete()
        {
            _transactionContext.Transactions.RemoveRange(_transactionContext.Transactions);
            _transactionContext.NewTransactions.RemoveRange(_transactionContext.NewTransactions);
            _transactionContext.SaveChanges();
        }
    }
}
