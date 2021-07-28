using System;

namespace Employee_Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeFile = new ReadEmployeeFile();
            employeeFile.EmployeeFile();
        }
    }
}
