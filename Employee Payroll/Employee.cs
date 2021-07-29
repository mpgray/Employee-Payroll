using Employee_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll
{
    class Employee
    {
        public Employee(EmployeePay pay)
        {
            Pay = pay;
            Taxes = GetTaxes();
        }

        public string Id { get; set; }
        public EmployeeName Name { get; set; }
        public EmployeePay Pay { get; set; }
        public DateTime StartDate { get; set; }
        public State Residence { get; set; }
        public EmployeeTaxes Taxes { get; set; }

        private EmployeeTaxes GetTaxes()
        {
            var employeeTaxes = new EmployeeTaxes();
            var pay = new Pay(Pay);
            employeeTaxes.GrosPay = pay.GetGrossPay();

            var taxes = new Taxes(Residence);

            employeeTaxes.StateTax = taxes.GetStateTax(employeeTaxes.GrosPay);
            employeeTaxes.FederalTax = taxes.GetFederalTax(employeeTaxes.GrosPay);

            employeeTaxes.NetPay = employeeTaxes.GrosPay - employeeTaxes.StateTax - employeeTaxes.FederalTax;

            return employeeTaxes;
        }
    }
}
