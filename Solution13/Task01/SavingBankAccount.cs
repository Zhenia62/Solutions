using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_defined_exceptions;

namespace Task01
{
    public class SavingBankAccount : BankAccount
    {
        protected int withdrawCount = 0;

        public SavingBankAccount(string accountOwnerName, string accountNumber)
            : base(accountOwnerName, accountNumber)
        {
            this.MinAccountBalance = 20000m;
            this.MaxDepositAmount = 50000m;
            InteresetRate = 3.5m;
        }

        public override void Deposit(decimal amount)
        {
            try
            {
                if (amount >= MaxDepositAmount)
                {
                    throw new LimitExeption($"You can not deposit amount greater than {MaxDepositAmount.ToString()}");
                }
                AccountBalance = AccountBalance + amount;
                TransactionSummary = string.Format("{0}\n Deposit:{1}", TransactionSummary, amount);
            }
            catch (LimitExeption ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public override void Withdraw(decimal amount)
        {
            try
            {
                if (withdrawCount > 3)
                {
                    throw new LimitExeption("You can not withdraw amount more than thrice");
                }

                if (AccountBalance - amount <= MinAccountBalance)
                {
                    throw new BalanceExeption("You can not withdraw amount from your Savings Account as Minimum Balance limit is reached");
                }

                AccountBalance = AccountBalance - amount;
                withdrawCount++;

                TransactionSummary = string.Format("{0}\n Withdraw:{1}", TransactionSummary, amount);
            }
            catch (LimitExeption ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (BalanceExeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void GenerateAccountReport()
        {
            Console.WriteLine("Saving Account Report");
            base.GenerateAccountReport();

            try
            {
                if (AccountBalance < 15000)
                {
                    throw new BalanceExeption("Insifficient amount of funds to generate report");
                }

                Console.WriteLine("Sending Email for Account {0}", AccountNumber);
            }
            catch (BalanceExeption ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
