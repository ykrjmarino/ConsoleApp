using System.Collections.Generic;

namespace EmployeeProject.Operations
{
  public class Update //patch talaga
  {
    public void UpdateEmployee(int employeeID, int patchChoice, string? newValue, decimal? newSalaryValue)
    {
      using var db = new AppDb();
      var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);

      if (employee == null) return;

      switch (patchChoice)
      {
        case 1: // First Name
          employee.FirstName = newValue ?? employee.FirstName;
          break;
        case 2: // Middle Name
          employee.MiddleName = newValue ?? employee.MiddleName;
          break;
        case 3: // Last Name
          employee.LastName = newValue ?? employee.LastName;
          break;
        case 4: // Department
          employee.Department = newValue ?? employee.Department;
          break;
        case 5: // Salary
          employee.Salary = newSalaryValue ?? employee.Salary;
          break;
        case 6: // Email
          employee.Email = newValue ?? employee.Email;
          break;
        default:
          break;
      }

      db.SaveChanges();
    }

    public bool RestoreById(int id) //just action of deleting.. will return true or false para masend sa console message
    {
      using var db = new AppDb();
      var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == id); //object 'all its data' sabi ni AI

      if (employee == null) return false;

      //db.Employees.Remove(employee); 
            //tracked entity so it knows what do remove... knows the exact row
      
      employee.Status = "active";
      db.SaveChanges();
      return true;
    }
  }
}