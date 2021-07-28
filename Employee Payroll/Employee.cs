using Employee_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll
{
    class Employee
    {
        public Employee()
        {
            GetTaxes();
        }

        public string Id { get; set; }
        public EmployeeName Name { get; set; }
        public EmployeePay Pay { get; set; }
        public DateTime StartDate { get; set; }
        public State Residence { get; set; }
        public EmployeeTaxes Taxes { get; set; }

        private void GetTaxes()
        {
            var pay = new Pay(Pay);
            Taxes.GrosPay = pay.GetGrossPay();

            var taxes = new Taxes(Residence);
            Taxes.StateTax = taxes.GetStateTax(Taxes.GrosPay);
            Taxes.FederalTax = taxes.GetFederalTax(Taxes.GrosPay);

            Taxes.NetPay = Taxes.GrosPay - Taxes.StateTax - Taxes.FederalTax;
        }
    }
}
