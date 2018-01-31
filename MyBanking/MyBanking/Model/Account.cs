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
        private String name; // name of the account
        private double balance; // the balance of the bank account
        private double freeBalance; // the current unbound balance
        private List<ReoccuringTransaction> reoccuringTransactions;
        private List<Transaction> transactionHistory;

        public Account(string name, double balance)
        {
            this.name = name;
            this.balance = balance;
        }

        public double Balance { get => balance; set => balance = value; }
        public double FreeBalance { get => freeBalance; set => freeBalance = value; }
        public string Name { get => name; set => name = value; }
        public List<ReoccuringTransaction> ReoccuringTransactions { get => reoccuringTransactions; set => reoccuringTransactions = value; }
        public List<Transaction> TransactionHistory { get => transactionHistory; set => transactionHistory = value; }

        public void addTransaction(Transaction t)
        {
            TransactionHistory.Add(t);
        }

        public void addReoccuringTransaction(ReoccuringTransaction rt)
        {
            ReoccuringTransactions.Add(rt);
        }

        //Contain savings boxes

        //transaction histories

        //current unbound money
    }
}
