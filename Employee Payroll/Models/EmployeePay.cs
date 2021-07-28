using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll.Models
{
    enum PayType
    {
        Hourly,
        Salary
    }
    class EmployeePay
    {
        public PayType Type { get; set; }
        public double Amount {get; set;}
        public int HoursWorked { get; set; }
    }
}
