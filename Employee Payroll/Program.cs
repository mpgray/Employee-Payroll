using Employee_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee_Payroll
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Out.WriteLine("Employee Payroll:");
            Console.Out.WriteLine("Where is the .txt file located? Include the filename in path [Default is Employees.txt in the same path]");
            var inputPath = Console.In.ReadLine();
            if (string.IsNullOrWhiteSpace(inputPath))
                inputPath = "Employees.txt";

            Console.Out.WriteLine("Where would you like the .txt outputted? Include the filename in path [Default is PaySummary.txt in the same path]");
            var outputPath = Console.In.ReadLine();
            if (string.IsNullOrWhiteSpace(outputPath))
                outputPath = "PaySummary.txt";

            var employeeFile = new EmployeeFile();
            Console.Out.WriteLine("Reading and parsing file, please wait...");
            var employeeList = employeeFile.ReadEmployeeFile(inputPath);
            var payPeriodSummaryList = employeeList.Select(employee => new PayPeriodSummary {Id = employee.Id, Name = employee.Name, Taxes = employee.Taxes}).ToList();
            Console.Out.WriteLine("Now Writing to file, please wait...");
            employeeFile.WriteEmployeePayPeriodSummary(payPeriodSummaryList.OrderByDescending(a => a.Taxes.GrossPay).ToList(), outputPath);
            Console.Out.WriteLine("Done.");
            Console.In.ReadLine();
        }
    }
}
