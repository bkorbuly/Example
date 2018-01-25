using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Entities;

namespace TestTask.Repositories
{
    public class TransactionRepository
    {
        TransactionContext _transactionContext;
        public TransactionRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }


    }
}
