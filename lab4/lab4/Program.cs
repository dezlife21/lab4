using System;

namespace laba4
{
    class Tax
    {
        protected int identificationCode;
        protected int birthYear;
        protected double income;
        protected double tax;

        public Tax(int identificationCode, int birthYear, double income)
        {
            this.identificationCode = identificationCode;
            this.birthYear = birthYear;
            this.income = income;
        }

        public virtual void CalculateTax(int currentYear)
        {
            if (currentYear - birthYear < 17)
            {
                tax = 0;
            }
            else if (income < 1000)
            {
                tax = 0;
            }
            else if (income <= 10000)
            {
                tax = 0.2 * income;
            }
            else
            {
                tax = 0.25 * income;
            }
        }

        public virtual void Print()
        {
            Console.WriteLine("Платник податкiв.");
            Console.WriteLine($"Iдентифiкацiйний код: {identificationCode}");
            Console.WriteLine($"Рiк народження: {birthYear}");
            Console.WriteLine($"Дохiд: {income:N2} грн.");
            Console.WriteLine($"Податок: {tax:N2} грн.");
        }
    }

        class Privilege : Tax
    {
        private bool isPrivileged;

        public Privilege(int identificationCode, int birthYear, double income, bool isPrivileged)
            : base(identificationCode, birthYear, income)
        {
            this.isPrivileged = isPrivileged;
        }

        public override void CalculateTax(int currentYear)
        {
            if (currentYear - birthYear < 17)
            {
                tax = 0;
            }
            else if (income < 10000)
            {
                tax = 0;
            }
            else if (income <= 50000)
            {
                tax = isPrivileged ? 0.1 * income : 0.2 * income;
            }
            else
            {
                tax = isPrivileged ? 0.2 * income : 0.25 * income;
            }
        }

        public override void Print()
        {
            Console.WriteLine("Пiльговик.");
            Console.WriteLine($"Iдентифiкацiйний код: {identificationCode}");
            Console.WriteLine($"Рiк народження: {birthYear}");
            Console.WriteLine($"Дохiд: {income:N2}  грн.");
            Console.WriteLine($"Податок: {tax:N2}  грн.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random random = new Random();

            for (int i = 1; i <= 4; i++)
            {
                int randomCode = random.Next(1000, 10000);
                int randomYear = random.Next(2000, 2010);
                double randomIncome = random.Next(500, 50000);
                bool isPrivileged = random.Next(0, 2) == 1;

                Tax taxpayer;

                if (isPrivileged)
                {
                    taxpayer = new Privilege(randomCode, randomYear, randomIncome, isPrivileged);
                }
                else
                {
                    taxpayer = new Tax(randomCode, randomYear, randomIncome);
                }

                taxpayer.CalculateTax(2023);
                taxpayer.Print();
                Console.WriteLine();
            }
        }
    }
}