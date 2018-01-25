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
        List<Transaction> newtransactions;
        List<Transaction> transactionlist;

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

        public List<Transaction> MatchTransactions()
        {
            transactionlist = _transactionRepository.GetAllTransactions();
            string[] rawinformation = new string[transactionlist.Count() * 3];
            int j = 0;
            for (int i = 0; i < transactionlist.Count(); i++)
            {
                rawinformation[j++] = transactionlist[i].Source;
                rawinformation[j++] = transactionlist[i].Destiny;
                rawinformation[j++] = transactionlist[i].Amount;
            }

            for (int i = 0; i < rawinformation.GetLength(0); i+=4)
            {
                if((rawinformation[i] == rawinformation[i + 4]) && (rawinformation[i + 1] == rawinformation[i + 3]))
                {
                    int AmountOne = int.Parse(rawinformation[i + 2]);
                    int AmountTwo =int.Parse(rawinformation[i + 5]);
                    int netAmount = AmountOne + AmountTwo;
                    if (Math.Abs(AmountOne) < Math.Abs(AmountTwo))
                        newtransactions.Add(new Transaction() { Amount = netAmount.ToString(), Destiny = rawinformation[i + 2], Source = rawinformation[i] });
                    else
                        newtransactions.Add(new Transaction() { Amount = netAmount.ToString(), Destiny = rawinformation[i], Source = rawinformation[i + 2] });
                }
                else
                    newtransactions.Add(new Transaction() { Amount = rawinformation[i + 2], Destiny = rawinformation[i + 1], Source = rawinformation[i] });

            }
            return newtransactions;
        }
    }
}
