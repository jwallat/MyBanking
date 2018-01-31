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
        private int liveCycle; // flush afterwards
        private double balance; // current money in the savings box
        private double targetBalance; // amount of money that is targeted 

        public SavingsBox(String name, int liveCycle, double balance, double targetBalance) : base(name, balance)
        {
            this.liveCycle = liveCycle;
            base.Balance = 0;
            this.targetBalance = targetBalance;
        }

        public int LiveCycle { get => liveCycle; set => liveCycle = value; }
        public new double Balance { get => balance; set => balance = value; }
        public double TargetBalance { get => targetBalance; set => targetBalance = value; }
    }
}
