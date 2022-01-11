using System;
using System.Collections.Generic;

namespace FuncActionPredicate_Delegate
{
    class Program
    {





        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1, out TResult>(T1 arg);
        delegate TResult Func2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);




        static void Main(string[] args)
        {
            MathClass mathClass = new MathClass();

            // a method attached to func mathing the parameters and return type
            Func<int, int, int> calc1 = mathClass.Sum;


            // anonymous delegate
            Func<int, int, int> calc2 = delegate (int a, int b) { return a + b; };

            // lambda expression
            Func<int, int, int> calc3 = (a, b) => { return a + b; };

            // Creating custom Func and using it
            Func2<int, int, int> calc4 = (a, b) => { return a + b; };
            Func2<int> consoleHiLine = () => { return 4; };
            Func2<int, int> anotherFunc2 = a => { return a; };
            Func<int, int, int> calc;

            int result = calc1(2, 2);
            int resul2 = calc2(2, 2);
            int result3 = calc3(2, 2);
            //Console.WriteLine($"Result: {result}");



            //Action

            Action<int, string, string, char, bool,decimal> displayEmplyeeRecors = (arg1, arg2, arg3, arg4, arg5, arg6) =>
               {
                   Console.WriteLine($"Id:{arg1}{Environment.NewLine}First Name:{arg2}{Environment.NewLine}Last Name:{arg3}{Environment.NewLine}Salary:{arg4}Gender:{arg5}{Environment.NewLine}Manager:{arg6}");
               };


            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, FirstName = "Bob", Lastname = "Brown", Gender = 'M', Manager = true , Salary = 23223.32M});
            employees.Add(new Employee { Id = 1, FirstName = "Katheryn", Lastname = "Alvey", Gender = 'F', Manager = false , Salary = 33333.33M});
            employees.Add(new Employee { Id = 1, FirstName = "Danielle", Lastname = "Shumate", Gender = 'F', Manager = true , Salary = 333333});
            employees.Add(new Employee { Id = 1, FirstName = "Jose", Lastname = "Preciado", Gender = 'M', Manager = true , Salary = 344344266});
            employees.Add(new Employee { Id = 1, FirstName = "Marco", Lastname = "Preciado", Gender = 'M', Manager = true , Salary = 990888});
            employees.Add(new Employee { Id = 1, FirstName = "Sean", Lastname = "Robbins", Gender = 'M', Manager = true , Salary = 111111111});

            List<Employee> employeesFiltered = employees.FilterEmployees(a => a.Manager == true);


            foreach (Employee employee in employeesFiltered)
            {
                displayEmplyeeRecors(employee.Id, employee.FirstName, employee.Lastname, employee.Gender, employee.Manager, employee.Salary);
            }


            Console.ReadKey();
        }

        static List<Employee> FilterEmployees(List<Employee> employees,Predicate<Employee> predicate)
        {
            List<Employee> employeesFiltered = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    employeesFiltered.Add(employee);
                }
            }

            return employeesFiltered;
        }

    }

    public static class Extensions
    {
        public static List<Employee> FilterEmployees(this List<Employee> employees,Predicate<Employee> predicate)
        {
            List<Employee> employeesFiltered = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    employeesFiltered.Add(employee);
                }
            }

            return employeesFiltered;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public decimal Salary { get; set; }
        public char Gender { get; set; }
        public bool Manager { get; set; }
    }

    public class MathClass
    {
        public int Sum(int a,int b)
        {
            return a + b;
        }


    }
}
