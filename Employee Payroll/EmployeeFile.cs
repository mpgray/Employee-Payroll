using Employee_Payroll.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Employee_Payroll
{
    class EmployeeFile
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PayType PayType { get; set; }
        public double PayAmount { get; set; }
        public DateTime StartDate { get; set; }
        public State Residence { get; set; }
        public int HoursWorked { get; set; }


        public List<Employee> ReadEmployeeFile(string path)
        { 
            var employeeList = new List<Employee>();
           
                using var parser = new TextFieldParser(path);
           
            
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                string[] employee = parser.ReadFields();
                if (employee == null || employee.Length < 8)
                    break;

                Id = employee[0];
                FirstName = employee[1];
                LastName = employee[2];
                PayType = GetPayType(employee[3]);
                PayAmount = Convert.ToDouble(employee[4]);
                StartDate = Convert.ToDateTime(employee[5]);
                Residence = GetResidence(employee[6]);      
                HoursWorked = Convert.ToInt32(employee[7]);

                var employeePay = new EmployeePay { Amount = PayAmount, Type = PayType, HoursWorked = HoursWorked };
                employeeList.Add(
                    new Employee(employeePay) { Id = Id, 
                                   Name = new EmployeeName { FirstName = FirstName, LastName = LastName},
                                   Residence = Residence
                                  }

                    );
            }
            return employeeList;
       
          
        }

        public void WriteEmployeePayPeriodSummary(List<PayPeriodSummary> payPeriodSummaryList, string path)
        {
            using var writer = new StreamWriter(path);
            foreach (var payPeriodSummary in payPeriodSummaryList)
            {
                writer.WriteLine(payPeriodSummary.Id + "," + payPeriodSummary.Name.FirstName + "," + payPeriodSummary.Name.LastName + "," + payPeriodSummary.Taxes.GrossPay + "," + payPeriodSummary.Taxes.FederalTax + "," + payPeriodSummary.Taxes.StateTax + "," + payPeriodSummary.Taxes.NetPay);
            }
        }

        private State GetResidence(string residence)
        {
            var state = residence switch
            {
                "UT" => State.UT,
                "WY" => State.WY,
                "NV" => State.NV,
                "CO" => State.CO,
                "ID" => State.ID,
                "AZ" => State.AZ,
                "OR" => State.OR,
                "WA" => State.WA,
                "NM" => State.NM,
                "TX" => State.TX,
                _ => State.UT,
            };
            return state;
        }

        private PayType GetPayType(string payType)
        {
            return payType == "H" ? PayType.Hourly : PayType.Salary;
        }


    }
}
