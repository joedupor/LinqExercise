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
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //1. TODO: Print the Sum of numbers

            Console.WriteLine("Given an Array:");

            foreach (var item in numbers)
            {
                Console.WriteLine(item);    //to display each number in the array
            }

            var sum = numbers.Sum(x => x);
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Sum of the Array: {sum}");     //to display the sum of the array at the end

            Console.WriteLine($"Length of the Array: {numbers.Length}");  //this is an extra line I added (not required)


            //2. TODO: Print the Average of numbers

            var avg = numbers.Average(x => x);
            Console.WriteLine($"Avg of the Array: {avg}");

            //3. TODO: Order numbers in ascending order and print to the console

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Array in Ascending Order:");

            var orderAscending = numbers.OrderBy(x => x);    //note there's no word "ascending" in the command
            foreach (var item in orderAscending)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------");
            //4. TODO: Order numbers in descending order and print to the console

            Console.WriteLine("Array in Descending Order:");

            var orderDescending = numbers.OrderByDescending(x => x);
            foreach (var item in orderDescending)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------");

            //5. TODO: Print to the console only the numbers greater than 6

            Console.WriteLine("Print to the console only the numbers greater than 6:");

            foreach (var item in numbers)
            {
                if (item > 6)
                    Console.WriteLine(item);

            }
            Console.WriteLine("-------------------------------");

            //now try it using LINQ

            var greaterThanSix = numbers.Where(x => x > 6);
            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------");
            //6. TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Print the first four ascending numbers:");
            var onlyPrint4 = numbers.OrderBy(x => x).Take(4);
            foreach (var item in onlyPrint4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------");


            //7. TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("Change the value at index 4 to your age, then print the numbers in descending order:");
            numbers.SetValue(52, 4);
            var index4 = numbers.OrderByDescending(x => x);
            foreach (var item in index4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------");

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //8. TODO: Print all the employees' FullName properties to the console only if
            //their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            Console.WriteLine("All employees names with 'C' or 'S':");
            Console.WriteLine();

            employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S'))
                .OrderBy(x => x.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine(x.FullName));

            Console.WriteLine("-------------------------------");


            //9. TODO: Print all the employees' FullName and Age who are over the age 26 to the console
            //and order this by Age first and then by FirstName in the same result.

            Console.WriteLine("All employees over the age of 26:");
            Console.WriteLine();

            employees.Where(x => x.Age > 26)
                .OrderBy(x => x.Age)
                .ThenBy(x => x.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FullName}  {x.Age}"));

            Console.WriteLine("-------------------------------");

            //10. TODO: Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine("Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35:");
            Console.WriteLine();

            var sumOfYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience);
            Console.WriteLine($"{sumOfYOE} = Sum of YOE");

            var avgOfYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience);
            
            var roundedAvg = Math.Round(avgOfYOE, 2);

            Console.WriteLine($"{roundedAvg} = Avg of YOE");
            Console.WriteLine("-------------------------------");


            //11. TODO: Add an employee to the end of the list without using employees.Add()

            var addedEmployee = new Employee();
            addedEmployee.FirstName = "Sid";
            addedEmployee.LastName = "Vicious";
            addedEmployee.Age = 65;
            addedEmployee.YearsOfExperience = 1;

            Console.WriteLine("Added an employee to the end of the list:");
            employees.Append(addedEmployee).ToList().ForEach(x => Console.WriteLine($"{x.FullName}  {x.Age}age  {x.YearsOfExperience}YOE"));
            Console.WriteLine("-------------------------------");

            //Note that in LINQ .Append() appends a value to the END of the sequence temporarily,
            //while .Add() would permanently add to the list.



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
