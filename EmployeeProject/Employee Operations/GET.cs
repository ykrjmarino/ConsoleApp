using System.Collections.Generic;
using Azure.Core;

namespace EmployeeProject.Operations
{
  public class Get
  {
    public List<Employee> All()
    {
      using var db = new AppDb();
      return db.Employees
          .Where(e => e.Status == "active")
          .ToList();
    }

    public int CountAll() //employees
    {
      using var db = new AppDb();
      return db.Employees
          .Count(e => e.Status == "active");
    }

    public decimal averageSalary() //average salary
    {
      using var db = new AppDb();
      return db.Employees
          .Where(e => e.Status == "active")
          .Average(e => e.Salary);
    }

    public Employee? ById(int id)
    {
      using var db = new AppDb();
      return db.Employees
          .Where(e => e.Status == "active")
          .FirstOrDefault(e => e.EmployeeID == id);
    }

    public Employee? InactiveById(int id)
    {
      using var db = new AppDb();
      return db.Employees
          .Where(e => e.Status == "inactive")
          .FirstOrDefault(e => e.EmployeeID == id);
    }

  }
}