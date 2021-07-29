using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll.Models
{
    class Pay
    {
        private readonly EmployeePay _paycheck;
        public Pay(EmployeePay paycheck) => _paycheck = paycheck;

        public double GetGrossPay()
        {
            return _paycheck.Type switch
            {
                PayType.Hourly => HourlyGrossPay(),
                PayType.Salary => SalaryGrossPay(),
                _ => 0
            };
        }

        private double HourlyGrossPay()
        {
            var grossPay = _paycheck.Amount * _paycheck.HoursWorked;
            // Overtime of first 10 hours at a rate of 150%
            if (_paycheck.HoursWorked > 80)
                grossPay += (_paycheck.Amount * (_paycheck.HoursWorked - 80)) * .5;
            // Additional overtime at a rate of 175%
            if (_paycheck.HoursWorked > 90)
                grossPay += (_paycheck.Amount * (_paycheck.HoursWorked - 90)) * .25;
            return grossPay;
        }
        private double SalaryGrossPay() => _paycheck.Amount / 26;
        
    }
}
