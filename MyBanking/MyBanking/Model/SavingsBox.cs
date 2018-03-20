using MyBanking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanking
{
    /**
     * Logical partition of a bank account. Used to save money for a special re-occuring goal (GEZ). 
     * The contained money is flushed every X months. 
     */
    class SavingsBox : Account
    {
        public SavingsBox(String name, int liveCycle, double balance, double targetBalance) : base(name, balance)
        {
            this.LiveCycle = liveCycle;
            base.Balance = 0;
            this.TargetBalance = targetBalance;
        }

        public int LiveCycle { get; set; }

        public new double Balance { get; set; }

        public double TargetBalance { get; set; }
    }
}
