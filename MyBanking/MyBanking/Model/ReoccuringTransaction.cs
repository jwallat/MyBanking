using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanking.Model
{
    /**
     * Special reoccuring transactions. Used for fixed income/expenditure.
     */
    class ReoccuringTransaction : Transaction
    {
        private String reoccurenceRate; // the rate in which the transaction reoccurs

        public ReoccuringTransaction(Account sender, Account reciever, double amount, DateTime date, 
                                        String reoccurenceRate) : base(sender, reciever, amount, date)
        {
            Sender = sender;
            Reciever = reciever;
            Amount = amount;
            Date = date;
            
        }

        public string ReoccurenceRate { get => reoccurenceRate; set => reoccurenceRate = value; }
    }
}
