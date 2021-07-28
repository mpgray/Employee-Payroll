using System;
using System.Collections.Generic;
using System.Text;
using Employee_Payroll.Models;

namespace Employee_Payroll
{
    
    class Taxes
    {

        private const double FEDERAL_TAX_RATE = .15;
        private readonly State Residence;


        //Constructor
        public Taxes(State residence) => Residence = residence;
  

        public double GetFederalTax(double grossPay) => grossPay * FEDERAL_TAX_RATE;
        public double GetStateTax(double grossPay) => grossPay * StateTaxRate();


        private double StateTaxRate()
        {
            switch (Residence)
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
