using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.Repositories;

namespace TestTask.Services
{
    public class TransactionService
    {
        static string path = @"C:\Users\Balazs\Test\TestTask\proba\files";
        TransactionRepository _transactionRepository;

        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void ReadFile()
        {
            foreach (string file in Directory.EnumerateFiles(path, "*.csv"))
            {
                Transaction transaction = new Transaction();
                string contents = File.ReadAllText(file);
                string[] seperate = contents.Split(";");
                transaction.Source = seperate[0];
                transaction.Destiny = seperate[1];
                transaction.Amount = seperate[2];
                _transactionRepository.Add(transaction);
            }
        }
    }
}
