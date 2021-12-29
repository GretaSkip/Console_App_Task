using System;

namespace BVKKMN_Task_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount;
            int term;
            double rate;
            int payday;

            Console.WriteLine("BVKKMN Console Calculator App");
            Console.WriteLine("-----------------------------");

            Console.WriteLine("Type Loan Amount and press Enter");
            amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Type Term in Months and press Enter");
            term = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type Annual Interest Rate % and press Enter");
            rate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Type Payment Date (1-31) and press Enter");
            payday = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("-----------------------------");

            Loan loan = new Loan(amount, term, rate, payday);

            loan.LoanTable();

            Console.ReadKey();
        }
    }
}
