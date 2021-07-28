using System;
using System.Collections.Generic;
using System.Text;
using Employee_Payroll.Models;

namespace Employee_Payroll
{
    
    class Taxes
    {
        private readonly IEmployee Employee;
        private const double FEDERAL_TAX = .15;
        
        //Constructor
        public Taxes(IEmployee employee) => Employee = employee;


        private double StateTaxRate()
        {
            switch (Employee.Residence)
            {
                case State.UT:
                case State.WY:
                case State.NV:
                    return .05;
                case State.CO:
                case State.ID:
                case State.OR:
                    return .065;
                case State.WA:
                case State.NM:
                case State.TX:
                    return .07;
                default:
                    return 0;
            }
        }

        
    }
}
