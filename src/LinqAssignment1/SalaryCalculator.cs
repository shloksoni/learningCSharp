using System;

namespace LinqAssignment1
{
    internal class SalaryCalculator
    {
        public SalaryCalculator()
        {
            TotalSalary = 0;
            TotalMonthlySalary = 0;
            TotalPerformanceSalary = 0;
            TotalBonusSalary = 0;
            TotalNumberOfMonthlySalaries = 0;
            TotalNumberOfPerformanceSalaries = 0;
            TotalNumberOfBonusSalaries = 0;

        }
        public SalaryCalculator accum(Salary salary)
        {
            // System.Console.WriteLine(typeof(salary.Type));
            if ((int)salary.Type == 0)
            {
                TotalSalary += (salary.Amount * 12);
                TotalMonthlySalary += salary.Amount;
                TotalNumberOfMonthlySalaries++;
            }
            else if ((int)salary.Type == 1)
            {
                TotalSalary += salary.Amount;
                TotalPerformanceSalary += salary.Amount;
                TotalNumberOfPerformanceSalaries++;
                // System.Console.WriteLine(TotalNumberOfPerformanceSalaries);
            }
            else
            {
                TotalSalary += salary.Amount;
                TotalBonusSalary += salary.Amount;
                TotalNumberOfBonusSalaries++;
            }
            return this;
        }
        internal SalaryCalculator compute()
        {
            if (TotalNumberOfMonthlySalaries != 0)
                MeanMonthlySalary = TotalMonthlySalary / TotalNumberOfMonthlySalaries;
            if (TotalNumberOfPerformanceSalaries != 0)
                MeanPerformanceSalary = TotalPerformanceSalary / TotalNumberOfPerformanceSalaries;
            if (TotalNumberOfBonusSalaries != 0)
                MeanBonusSalary = TotalBonusSalary / TotalNumberOfBonusSalaries;
            return this;
        }
        public int TotalSalary;
        int TotalMonthlySalary;
        int TotalPerformanceSalary;
        int TotalBonusSalary;

        int TotalNumberOfMonthlySalaries;
        int TotalNumberOfPerformanceSalaries;

        int TotalNumberOfBonusSalaries;

        public int MeanMonthlySalary, MeanPerformanceSalary, MeanBonusSalary;









    }
}