using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll.Models
{
    enum State
    {
        UT,
        WY,
        NV,
        CO,
        ID,
        AZ,
        OR,
        WA, 
        NM,
        TX
    }
    interface IEmployee
    {
        public string Id { get; set; }
        public EmployeeName Name { get; set; }
        public EmployeePay Pay { get; set; }
        public DateTime StartDate { get; set; }
        public State Residence { get; set; }
        public int HoursWorked { get; set; }
     }
}
