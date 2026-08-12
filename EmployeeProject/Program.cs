// Program.cs
using System;
using System.Collections.Generic;
using EmployeeProject.Operations;

namespace EmployeeProject
{
  class Program
  {
    static void Main(string[] args)
    {
      var menu = new Menu();

      menu.ShowMainMenu();
      /*
      List<Employee> employees = getService.All();

      foreach (var e in employees)
      {
        Console.WriteLine($"{e.EmployeeID} - {e.FirstName} {e.LastName} - {e.Department} - {e.Salary} - {e.HireDate}");
      }
      */

      //
    }
  }
}