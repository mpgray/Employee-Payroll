using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll.Models
{
    class Pay
    {
        private readonly EmployeePay Paycheck;
        public Pay(EmployeePay paycheck) => Paycheck = paycheck;

        public double GetPay()
        {
            if (Paycheck.Type == PayType.Hourly)
                return HourlyGrossPay();
            if (Paycheck.Type == PayType.Salary)
                return SalaryGrossPay();
            return 0;
        }

        private double HourlyGrossPay()
        {
            var grossPay = Paycheck.Amount * Paycheck.HoursWorked;
            // Overtime of first 10 hours at a rate of 150%
            if (Paycheck.HoursWorked > 80)
                grossPay += (Paycheck.Amount * (Paycheck.HoursWorked - 80)) * .5;
            // Additional overtime at a rate of 175%
            if (Paycheck.HoursWorked > 90)
                grossPay += (Paycheck.Amount * (Paycheck.HoursWorked - 80)) * .25;
            return grossPay;
        }
        private double SalaryGrossPay() => Paycheck.Amount / 26;
        
    }
}
