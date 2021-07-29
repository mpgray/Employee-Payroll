using Employee_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll
{
    enum State
    {
        UT,WY,NV,CO,ID,AZ,OR,WA,NM,TX
    }
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
        public State Residence { get; set; }
        public EmployeeTaxes Taxes { get; set; }

        private EmployeeTaxes GetTaxes()
        {
            var employeeTaxes = new EmployeeTaxes();
            var pay = new Pay(Pay);
            employeeTaxes.GrossPay = pay.GetGrossPay();

            var taxes = new Taxes(Residence);

            employeeTaxes.StateTax = taxes.GetStateTax(employeeTaxes.GrossPay);
            employeeTaxes.FederalTax = taxes.GetFederalTax(employeeTaxes.GrossPay);

            employeeTaxes.GrossPay = Math.Round(employeeTaxes.GrossPay, 2);
            employeeTaxes.NetPay = Math.Round(employeeTaxes.GrossPay - employeeTaxes.StateTax - employeeTaxes.FederalTax, 2);

            return employeeTaxes;
        }
    }
}
