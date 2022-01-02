using Excel.FinancialFunctions;
using System;

namespace BVKKMN_Task_Console
{
    class Loan
    {
        private double LoanAmount, InterestRate, LoanLength, LoanPayDay;

        public Loan(double amount, double term, double rate, double payDay)
        {
            this.LoanAmount = amount;
            this.LoanLength = term;
            this.InterestRate = rate;
            this.LoanPayDay = payDay;
        }

        public static String GetDate(DateTime value)
        {
            return value.ToString("yyyy-MM-");
        }

        public double GetMonthlyPayment()
        {
            return Financial.Pmt(InterestRate / 100 / 12, LoanLength, LoanAmount, 0, PaymentDue.EndOfPeriod);
        }

        public double GetRate()
        {
            double pmt = GetMonthlyPayment();

            return Financial.Rate(LoanLength, pmt, LoanAmount, 0, PaymentDue.EndOfPeriod);
        }

        public double GetAPR()
        {
            double nominalRate = GetRate();
            return Financial.Effect(nominalRate * 12, 12);
        }

        public void GenerateAPR()
        {
            decimal apr = Math.Round(Convert.ToDecimal(GetAPR()) * 100, 2);
            Console.WriteLine($"APR for this loan is: {apr} %");
        }

        public void LoanTable()
        {
            DateTime initialDate = DateTime.Today;

            string dayValue = Convert.ToString(LoanPayDay);
            string date;

            decimal monthlyPayment = (Math.Round(Convert.ToDecimal(GetMonthlyPayment()), 2)) * -1;
            decimal loanPart = 0;
            decimal newBalance = 0;
            decimal interest = 0;
            decimal loan = Convert.ToDecimal(LoanAmount);


            Console.WriteLine("{0,-10}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|{5,-10}", "Payment No.", "Date", "Part of the Loan", "Interest", "Payment", "Balance");

            for (int i = 1; i <= LoanLength; i++)
            {

                date = GetDate(initialDate.AddMonths(i)) + dayValue;
                interest = Math.Round(loan * Convert.ToDecimal(InterestRate) / 100 / 12, 2);
                loanPart = monthlyPayment - interest;
                newBalance = loan - loanPart;


                Console.WriteLine("{0,-10}{1,10:N2}{2,10:N2}{3,10:N2}{4,10:N2}{5,10:N2}",
                    i, date, loanPart, interest, monthlyPayment, newBalance);

                loan = newBalance;
            }
        }
    }
}
