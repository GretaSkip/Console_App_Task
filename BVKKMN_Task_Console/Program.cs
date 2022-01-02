using System;

namespace BVKKMN_Task_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount;
            double term;
            double rate;
            double payDay;

            ;

            Console.WriteLine("Loan Calculator App");
            Console.WriteLine("-----------------------------");

            Console.WriteLine("Type Loan Amount (EUR) and press Enter");
            amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Type Term in Months and press Enter");
            term = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Type Annual Interest Rate (%) and press Enter");
            rate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Type Payment Date (1-31) and press Enter");
            payDay = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("-----------------------------");

            Loan loan = new Loan(amount, term, rate, payDay);

            loan.LoanTable();

            Console.WriteLine("-----------------------------");

            loan.GenerateAPR();

            Console.ReadKey();
        }
    }
}
