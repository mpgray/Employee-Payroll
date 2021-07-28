using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll.Models
{
    class EmployeeTaxes
    {
        public double GrosPay { get; set; }
        public double FederalTax { get; set; }
        public double StateTax { get; set; }
        public double NetPay { get; set; }
    }
}
