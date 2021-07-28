using Employee_Payroll.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll
{
    class ReadEmployeeFile
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PayType PayType { get; set; }
        public double PayAmount { get; set; }
        public DateTime StartDate { get; set; }
        public State Residence { get; set; }
        public int HoursWorked { get; set; }


        public List<Employee> EmployeeFile()
        {
            var employeeList = new List<Employee>();

            using TextFieldParser parser = new TextFieldParser(@"c:\proj\Employees.txt");
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
                switch (employee[3])
                {
                    case "S":
                        PayType = PayType.Salary;
                        break;
                    case "H":
                        PayType = PayType.Hourly;
                        break;
                    default:
                        break;
                }

                PayAmount = Convert.ToDouble(employee[4]);
                StartDate = Convert.ToDateTime(employee[5]);
                switch (employee[6])
                {
                    case "UT":
                        Residence = State.UT;
                        break;
                    case "WY":
                        Residence = State.WY;
                        break;
                    case "NV":
                        Residence = State.NV;
                        break;
                    case "CO":
                        Residence = State.CO;
                        break;
                    case "ID":
                        Residence = State.ID;
                        break;
                    case "AZ":
                        Residence = State.AZ;
                        break;
                    case "OR":
                        Residence = State.OR;
                        break;
                    case "WA":
                        Residence = State.WA;
                        break;
                    case "NM":
                        Residence = State.NM;
                        break;
                    case "TX":
                        Residence = State.TX;
                        break;
                    default:
                        break;
                }
                HoursWorked = Convert.ToInt32(employee[7]);
                employeeList.Add(
                    new Employee { Id = Id, 
                                   Name = new EmployeeName { FirstName = FirstName, LastName = LastName},
                                   Pay = new EmployeePay { Amount = PayAmount, Type = PayType, HoursWorked = HoursWorked },
                                   Residence = Residence
                                  }

                    );
            }

            return employeeList;
        }
    }
}
