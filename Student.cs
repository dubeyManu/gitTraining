using System;

namespace Day_4_Exercies
{
    abstract class Student
    {
        public string name { get; set; }
        public int regno { get; set; }
        public Student(string name,int regno)
        {
            this.name = name;
            this.regno = regno;
        }
        public virtual string Display()
        {
            return $"Hi! {this.name}, Reg No. = {this.regno},Type = {this.GetType()}, Average = {this.GetAvg()}";
        }
        public abstract double GetAvg();
        
    }
    class ScienceStudent:Student
    {
        public int physics { get; set; }
        public int chemistry { get; set; }
        public int maths { get; set; }

        public ScienceStudent(string name, int regno, int physics, int chemistry, int maths):base(name,regno)
        {
            this.physics = physics;
            this.chemistry = chemistry;
            this.maths = maths;
        }
        public override string Display()
        {
            return $"{base.Display()}, Physics = {physics}, Chemistry = {chemistry}, Maths = {maths}.";
        }
        public override double GetAvg()
        {
            return (this.physics + this.chemistry + this.maths) / 3;
        }
    }
    class CommerceStudent : Student
    {
        public int economics { get; set; }
        public int accounts { get; set; }
        public int banking { get; set; }

        public CommerceStudent(string name, int regno, int economics, int accounts, int banking) : base(name, regno)
        {
            this.economics = economics;
            this.accounts = accounts;
            this.banking = banking;
        }
        public override string Display()
        {
            return $"{base.Display()}, Economics = {economics}, Accounts = {accounts}, Banking = {banking}.";
        }
        public override double GetAvg()
        {
            return (this.economics+this.accounts+this.banking)/3;
        }
    }
    class StudentClient
    {
        static void Main(string[] args)
        {
            Student s1 = new ScienceStudent("Manu", 1140, 100, 50, 0);
            Student s2 = new CommerceStudent("Dubey", 18840, 75, 50, 25);
            Console.WriteLine(s1.Display());
            Console.WriteLine(s2.Display());


        }
    }
}
