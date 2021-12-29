using System;

namespace BVKKMN_Task_Console
{
    class Loan
    {
        private double LoanAmount, InterestRate;
        private int LoanLength, LoanPayDay;

        public Loan(double amount, int term, double rate, int payday)
        {
            this.LoanAmount = amount;
            this.LoanLength = term;
            this.InterestRate = rate;
            this.LoanPayDay = payday;
        }

        public double GetMonthlyPayment()
        {
            return (LoanAmount * InterestRate / 1200 * Math.Pow(1 + InterestRate, LoanLength)) / (Math.Pow(1 + InterestRate, LoanLength) - 1);
        }

        public void LoanTable()
        {
            double monthlyPayment = GetMonthlyPayment();
            double principalPaid = 0;
            double newBalance = 0;
            double interestPaid = 0;
            double principal = LoanAmount;
            double totalinterest = 0;
            double loanLeft = 0;

            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}", "Payment No.", "Part of the Loan", "Interest Paid", "Payment", "Balance");
            for (int month = 1; month <= LoanLength; month++)
            {
                totalinterest += interestPaid;
                interestPaid = principal * InterestRate;
                principalPaid = monthlyPayment - interestPaid;
                newBalance = principal - principalPaid;
                loanLeft = newBalance - monthlyPayment;


                Console.WriteLine("{0,-10}{1,10}{2,10}{3,10}{4,10}",
                    month, loanLeft, interestPaid, monthlyPayment, newBalance);

                principal = newBalance;
            }
        }
    }
}
