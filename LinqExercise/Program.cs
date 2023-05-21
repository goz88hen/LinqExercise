using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("Sum of all numbers");
            var sum = numbers.Sum();
            Console.WriteLine(sum);
            Console.WriteLine();    

            //TODO: Print the Average of numbers
            Console.WriteLine("Average of all number: ");
            Console.WriteLine(numbers.Average());
            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Numbers in ascending order.");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in decsending order and print to the console
            Console.WriteLine("Numbers in descending Order");
            var orderedByDesc = numbers.OrderByDescending(x => x);

            foreach(var number in orderedByDesc)
            {
                Console.WriteLine(number);
            }

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine();
            Console.WriteLine("All numbers greater than 6: ");
            numbers.Where( x => x > 6).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Prints only four number: ");
            var prints4 = numbers.OrderBy(x => x).Take(4);
            foreach (var item in prints4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine() ;

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Changing the value of index four to 21: ");           
            numbers.SetValue(21, 4);
            foreach(var item in orderedByDesc)
            {
                Console.WriteLine(item);
            }
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            Console.WriteLine("C or S Employees");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName).ThenBy(emp => emp.YearsOfExperience);
            {
                Console.WriteLine("Over 26");
                foreach (var person in overTwentySix) 
                {
                    Console.WriteLine($"Fullname: {person.FullName} Age: {person.Age} YOE:{person.YearsOfExperience}");
                }
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var yoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            
            var sumOfYOE = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYOE = yoeEmployees.Average(emp => emp.YearsOfExperience);
            Console.WriteLine($"Sum {sumOfYOE} Avg {avgOfYOE}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("first", "lastNAme", 98, 1)).ToList();

            foreach (var emp in yoeEmployees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
