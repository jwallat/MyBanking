using MyBanking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanking
{
    /**
     * Class that models an bank account with all it's features and the contained savings boxes.
     */
    class Account
    {
        public Account(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public double Balance { get; set; }

        public double FreeBalance { get; set; }

        public string Name { get; set; }

        public List<ReoccuringTransaction> ReoccuringTransactions { get; set; }

        public List<Transaction> TransactionHistory { get; set; }

        public void AddTransaction(Transaction t)
        {
            TransactionHistory.Add(t);
        }

        public void AddReoccuringTransaction(ReoccuringTransaction rt)
        {
            ReoccuringTransactions.Add(rt);
        }

        //Contain savings boxes

        //transaction histories

        //current unbound money
    }
}
