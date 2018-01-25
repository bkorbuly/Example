using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Repositories;

namespace TestTask.Services
{
    public class TransactionService
    {
        TransactionRepository _transactionRepository;

        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
    }
}
