using System;
using System.Collections.Generic;
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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var average = numbers.Average();
            Console.WriteLine($"Sum = {sum}. Average = {average}.");
            //Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("Ascending: ");
            
            var ascending = numbers.OrderBy(num => num);
            foreach(var num in ascending)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("");
            Console.WriteLine("Descending: ");
            
            var descending = numbers.OrderByDescending(num => num);
            foreach(var num in descending)
            {
                Console.WriteLine(num);
            }

            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("");
            Console.WriteLine("Every number greater than 6:");
            foreach(var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!*
            //*
            Console.WriteLine("");
            Console.WriteLine("First four numbers in ascending order:");
            foreach(var num in ascending.Take(4))
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("");
            Console.WriteLine("My age and the numbers after in descending order:");
            numbers[4] = 26;
            foreach(var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            Console.WriteLine("");
            Console.WriteLine("C or S employees:");
            foreach(var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);
            Console.WriteLine("");
            Console.WriteLine("Over age 26:");
            foreach(var person in overTwentySix)
            {
                Console.WriteLine($"Full name: {person.FullName} Age: {person.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumOfYOE = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYOE = yoeEmployees.Average(emp => emp.YearsOfExperience);
            Console.WriteLine("");
            Console.WriteLine("Here is the sum and average list dealing with age and experience: ");
            Console.WriteLine($"Sum :{sumOfYOE} Average: {avgOfYOE}");
            Console.WriteLine("");


            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Butt", "Head", 190, 43)).ToList();
            foreach(var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Age} {emp.YearsOfExperience}");
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
