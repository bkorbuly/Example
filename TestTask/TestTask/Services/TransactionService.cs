using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Interfaces;
using TestTask.Models;
using TestTask.Repositories;

namespace TestTask.Services
{
    public class TransactionService
    {
        static string path = @"C:\Users\Balazs\Test\TestTask\proba\files";
        TransactionRepository _transactionRepository;
        List<NewTransaction> newtransactions = new List<NewTransaction>();
        List<Transaction> transactionList = new List<Transaction>();

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

        public List<NewTransaction> MatchTransactions()
        {
            transactionList = _transactionRepository.GetAllTransactions();
            string[] rawinformation = new string[transactionList.Count() * 3];
            int j = 0;
            for (int i = 0; i < transactionList.Count(); i++)
            {
                rawinformation[j++] = transactionList[i].Source;
                rawinformation[j++] = transactionList[i].Destiny;
                rawinformation[j++] = transactionList[i].Amount;
            }

            for (int i = 0; i < rawinformation.GetLength(0) - 3; i+=3)
            {
                for(int k = i; k <rawinformation.GetLongLength(0) - 3; k += 3)
                {
                    if ((rawinformation[i] == rawinformation[k + 4]) && (rawinformation[i + 1] == rawinformation[k + 3]))
                    {
                        int AmountOne = int.Parse(rawinformation[i + 2]);
                        int AmountTwo = int.Parse(rawinformation[i + 5]);
                        int netAmount = AmountOne + AmountTwo;
                        if (Math.Abs(AmountOne) < Math.Abs(AmountTwo))
                            newtransactions.Add(new NewTransaction() { Amount = netAmount.ToString(), Destiny = rawinformation[k + 2], Source = rawinformation[i] });
                        else
                            newtransactions.Add(new NewTransaction() { Amount = netAmount.ToString(), Destiny = rawinformation[i], Source = rawinformation[k + 2] });
                    }
                    else
                        newtransactions.Add(new NewTransaction() { Amount = rawinformation[i + 2], Destiny = rawinformation[i + 1], Source = rawinformation[i] });
                }
            }
            return newtransactions;
        }

        public void NewAdd()
        {
            foreach (NewTransaction newtransaction in newtransactions)
                _transactionRepository.Add(newtransaction);
        }

        public List<NewTransaction> GetAllNewTransactions()
        {
            return _transactionRepository.GetAllNewTransactions();
        }

        public void Delete()
        {
            _transactionRepository.Delete();
        }
    }
}
