using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanking.Model
{
    /// <summary>
    /// Data class to model transactions
    /// </summary>
    class Transaction
    {
        public Transaction(Account sender, Account reciever, double amount, DateTime date)
        {
            Sender = sender;
            Reciever = reciever;
            Amount = amount;
            Date = date;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        internal Account Sender { get; set; }

        internal Account Reciever { get; set; }

        public string Info { get; set; }

        public override string ToString()
        {
            return "Transaction(" + Sender.Name + ", " + Reciever.Name + ", " + Amount + ", " + Date + ")";
        }
    }
}
