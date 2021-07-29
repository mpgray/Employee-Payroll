using System;
using System.Collections.Generic;
using System.Text;
using Employee_Payroll.Models;

namespace Employee_Payroll
{
    
    class Taxes
    {

        private const double FEDERAL_TAX_RATE = .15;
        private readonly State _residence;

        public Taxes(State residence) => _residence = residence;
  

        public double GetFederalTax(double grossPay) => Math.Round(grossPay * FEDERAL_TAX_RATE, 2);
        public double GetStateTax(double grossPay) => Math.Round(grossPay * StateTaxRate(), 2);


        private double StateTaxRate()
        {
            switch (_residence)
            {
                case State.UT:
                case State.WY:
                case State.NV:
                    return .05;
                case State.CO:
                case State.ID:
                case State.OR:
                case State.AZ:
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
