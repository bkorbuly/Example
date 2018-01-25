using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                string contents = File.ReadAllText(file);
            }
        }
    }
}
