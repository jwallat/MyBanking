using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanking.Model
{
    /**
     * Basic class to model transactions
     */
    class Transaction
    {
        private DateTime date; // Date of the transaction
        private Account sender; // Account which sends the money
        private Account reciever; // Account which recieves the money
        private double amount; // the amount of money, that is 

        public Transaction(Account sender, Account reciever, double amount, DateTime date)
        {
            Sender = sender;
            Reciever = reciever;
            Amount = amount;
            Date = date;
        }

        public DateTime Date { get => date; set => date = value; }
        public double Amount { get => amount; set => amount = value; }
        internal Account Sender { get => sender; set => sender = value; }
        internal Account Reciever { get => reciever; set => reciever = value; }
    }
}
