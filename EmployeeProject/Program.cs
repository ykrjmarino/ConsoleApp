using System;
using System.Collections.Generic;

namespace EmployeeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var getService = new Get();
            List<Employee> employees = getService.All();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.Id} - {e.FirstName} {e.LastName} - {e.Department} - {e.Salary} - {e.HireDate}");
            }
        }
    }
}