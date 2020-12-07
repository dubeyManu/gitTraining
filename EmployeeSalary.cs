using System;
using System.Collections.Generic;
using System.Text;

namespace Day_4_Exercies
{
    class EmployeeSalary
    {
        public int EmployeeId { get; set; }
        public string name { get; set; }
        public int BasicSalary { get; private set; }
        public int HRAllowance { get;private set; }
        public int TravelAllowance { get; private set; }
        public int incometaxPercentage { get;private set; }
        public EmployeeSalary(int EmployeeId,string name, int BasicSalary, int HRAllowance, int TravelAllowance,int incometaxPercentage)
        {
            this.EmployeeId = EmployeeId;
            this.name = name;
            this.BasicSalary = BasicSalary;
            this.HRAllowance = HRAllowance;
            this.TravelAllowance = TravelAllowance;
            this.incometaxPercentage = incometaxPercentage;
        }
        public double NetSalary()
        {
            return (this.BasicSalary+this.HRAllowance+this.TravelAllowance)*(100-this.incometaxPercentage)/100;
        }
    }
    class EmployeeSalaryClient
    {
        public static void Main()
        {
            EmployeeSalary e1 = new EmployeeSalary(18840, "Manu", 18000, 2000, 1000, 5);
            Console.WriteLine($"Hi {e1.name}, your net salary is { e1.NetSalary()}.");
        }
    }
}
