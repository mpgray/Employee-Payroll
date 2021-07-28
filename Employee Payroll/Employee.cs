using Employee_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll
{
    class Employee: IEmployee, IPayPeriodSummary
    {
        private readonly IEmployee EmployeeData;
        public IPayPeriodSummary payPeriodSummary;
        public Employee(IEmployee employee) => EmployeeData = employee;

        public string Id { get => EmployeeData.Id; set => EmployeeData.Id = value; }
        public EmployeeName Name { get => EmployeeData.Name; set => EmployeeData.Name = value; }
        public EmployeePay Pay { get => EmployeeData.Pay; set => EmployeeData.Pay = value; }
        public DateTime StartDate { get => EmployeeData.StartDate; set => EmployeeData.StartDate = value; }
        public State Residence { get => EmployeeData.Residence; set => EmployeeData.Residence = value; }
        public EmployeeTaxes Taxes { get => payPeriodSummary.Taxes; set => payPeriodSummary.Taxes = value; }


    }
}
