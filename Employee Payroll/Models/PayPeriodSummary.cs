using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll.Models
{
    class PayPeriodSummary
    {
        public string Id { get; set; }
        public EmployeeName Name { get; set; }
        public EmployeeTaxes Taxes { get; set; }

    }
}
