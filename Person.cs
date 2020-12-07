/*
;==========================================
; Title:  C Sharp Paractical
; Author: Manu Dubey 18840
; Date:   5 Dec 2020
;==========================================
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractical
{
    // Custom named Exception
    class FutureDateOfBirthException : Exception
    {
        public FutureDateOfBirthException(string msg) : base(msg)
        {

        }
    }
    // Custom named Exception
    class InvalidEmailAddressException : Exception
    {
        public InvalidEmailAddressException(string msg) : base(msg)
        {

        }
    }
    // Custom named Exception
    class DateOfBirthTooFarInPastException : Exception
    {
        public DateOfBirthTooFarInPastException(string msg) : base(msg)
        {

        }
    }
    //Class representing a Person.
    class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        private string _emailAddress;

        public string emailAddress
        {
            get 
            { 
                return _emailAddress; 
            }
            set
            {
                /*
                The following code divides the input string by '@' and stores it in array parts.
                We compare length of array, it should be 2 , i.e only one '@' should be present in the array.
                For eg, xyz@abc@def will be split as 3 string elements in array [xyz, abc, def].
                If validations fail a custom exception is thrown.
                */
                string[] parts = value.Split('@');

                if(parts.Length != 2)
                {
                    throw new InvalidEmailAddressException("This is not a valid email address");
                }

                _emailAddress = value;
            }
        }
        private DateTime _dateOfBirth;
        public DateTime dateOfBirth 
        {
            get 
            { 
                return _dateOfBirth; 
            }
            set
            {
                /*
                The following code checks for future date of birth execption 
                and date of birth too far in past exceptions.
                If validations fail a custom exception is thrown.
                */
                if (value > DateTime.Today)
                {
                    throw new FutureDateOfBirthException("You have entered a future date of birth.");
                }
                else if (DateTime.Today.Year- value.Year > 120)
                {
                    throw new DateOfBirthTooFarInPastException("The date of birth is too far in past. Contact System administrator.");
                }
                
                _dateOfBirth=value;
            }
        }

        public Person(string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
        {
                this.firstName = firstName;
                this.lastName = lastName;
                this.emailAddress = emailAddress;
                this.dateOfBirth = dateOfBirth;
        }
        public Person(string firstName, string lastName, string emailAddress)
        {
                this.firstName = firstName;
                this.lastName = lastName;
                this.emailAddress = emailAddress;
        }
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
                this.firstName = firstName;
                this.lastName = lastName;
                this.dateOfBirth = dateOfBirth;
        }
        /*
        The following code creates a boolean read only property Adult which reads dateOfBirth 
        and returns true only if Person is more than 18 years old or not.
        */
        public bool Adult
        {
            get
            {
                if (DateTime.Today >= dateOfBirth.AddYears(18))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /*
        The following code creates a bool read only property Birthday which reads dateOfBirth 
        and returns true only if Today is the birthday of Person.
        */
        public bool Birthday
        {
            get
            {
                if (DateTime.Today.Month == dateOfBirth.Month && DateTime.Today.Date == dateOfBirth.Date)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /*
        Overriding ToString() to get output in desired format.
        */
        public override string ToString()
        {
            return $"{firstName} {lastName} born on {dateOfBirth.ToString("MMMM")} {dateOfBirth.ToString("dd")}th, {dateOfBirth.Year}.";
        }
        
    }
 // Main Program 
    class PersonClient
    {
        public static void Main()
        {
            try
            {
                /*
                The following code creates person to test the working of code. First 3 are under normal condition, and next 3 are under exception conditions
                */
                Person Manu = new Person("Manu", "Dubey", "xyz1@abc.com", new DateTime(1997, 05, 20));
                Console.WriteLine(Manu.ToString());

                Person ManuD = new Person("Manu", "D", new DateTime(1997, 05, 20));
                Console.WriteLine(ManuD.ToString());

                Person ManuDu = new Person("Manu", "Du", "xyz1@abc.com");
                Console.WriteLine(ManuDu.ToString());

                //Person Dubey = new Person("Dubey", "manu", "wrong@id@abc.com", new DateTime(1997, 05, 20));
                //Console.WriteLine(Dubey.ToString());

                //Person Rick = new Person("Rick", "S", "x1y1@abc1.com", new DateTime(2021, 05, 20));
                //Console.WriteLine(Rick.ToString());

                Person Morty = new Person("Morty", "S", "x2y2z@abc.com", new DateTime(1800, 05, 20));
                Console.WriteLine(Morty.ToString());
            }
            catch (FutureDateOfBirthException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidEmailAddressException ex1)
            {
                Console.WriteLine(ex1.Message);
            }
            catch (DateOfBirthTooFarInPastException ex2)
            {
                Console.WriteLine(ex2.Message);
            }
        }
    }
}
