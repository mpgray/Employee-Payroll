using Employee_Payroll.Models;
using System;
using System.Collections.Generic;

namespace Employee_Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeFile = new EmployeeFile();
            var employeeList = employeeFile.ReadEmployeeFile();
            var payPeriodSummaryList = new List<PayPeriodSummary>();
            foreach (var employee in employeeList)
            {
                payPeriodSummaryList.Add(
                    new PayPeriodSummary
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Taxes = employee.Taxes
                    }
                ); 
            }
            employeeFile.WriteEmployeePayPeriodSummary(payPeriodSummaryList);
        }
    }
}
