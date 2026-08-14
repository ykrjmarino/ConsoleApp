using System.Collections.Generic;

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

    public Employee? ById(int id)
    {
      using var db = new AppDb();
      return db.Employees
          .Where(e => e.Status == "active")
          .FirstOrDefault(e => e.EmployeeID == id);
    }

  }
}