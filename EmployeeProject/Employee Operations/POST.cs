using System.Collections.Generic;

namespace EmployeeProject.Operations
{
  public class Post
  {
    public void AddEmployee(Employee employee) //doesnt return, just runs... good for post
    {
      //email 
      string alterEmail()
      {
        string emplFirstName = employee.FirstName.ToLower();
        string emplMiddleName = employee.MiddleName.ToLower();
        string emplLastName = employee.LastName.ToLower();

        char first = emplFirstName.FirstOrDefault(); //returns 0 if empty.. sana mafill up-an lahat
        char mid = emplMiddleName.FirstOrDefault();

        return $"{first}{mid}{emplLastName}@company.com";
      }
      //add the email
      employee.Email = alterEmail();

      //send to db
      using var db = new AppDb();
      db.Employees.Add(employee);
      db.SaveChanges();
    }
  }
}