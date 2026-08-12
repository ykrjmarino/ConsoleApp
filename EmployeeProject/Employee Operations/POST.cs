using System.Collections.Generic;

namespace EmployeeProject.Operations
{
  public class Post
  {
    public void AddEmployee(Employee employee) //doesnt return, just runs... good for post
    {
      using var db = new AppDb();
      db.Employees.Add(employee);
      db.SaveChanges();
    }
  }
}