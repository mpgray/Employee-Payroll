using Employee_Payroll.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll
{
    class ReadEmployeeFile: IEmployee
    {
        public IEmployee EmployeeData { get; private set; }

        public string Id { get => EmployeeData.Id; set => EmployeeData.Id = value; }
        public EmployeeName Name { get => EmployeeData.Name; set => EmployeeData.Name = value; }
        public EmployeePay Pay { get => EmployeeData.Pay; set => EmployeeData.Pay = value; }
        public DateTime StartDate { get => EmployeeData.StartDate; set => EmployeeData.StartDate = value; }
        public State Residence { get => EmployeeData.Residence; set => EmployeeData.Residence = value; }

        public ReadEmployeeFile(IEmployee employee) => EmployeeData = employee;
        public void EmployeeFile()
        {
            using TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                string[] employee = parser.ReadFields();
                if (employee == null || employee.Length < 9)
                    break;

                Id = employee[0];
                Name.FirstName = employee[1];
                Name.LastName = employee[2];
                switch (employee[3])
                {
                    case "S":
                        Pay.Type = PayType.Salary;
                        break;
                    case "H":
                        Pay.Type = PayType.Hourly;
                        break;
                    default:
                        break;
                }

                Pay.Amount = Convert.ToDouble(employee[4]);
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
                Pay.HoursWorked = Convert.ToInt32(employee[7]);
            }
        }
    }
}
