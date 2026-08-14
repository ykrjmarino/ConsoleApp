using System.Collections.Generic;

namespace EmployeeProject.Operations
{
  public class Delete
  {
    public bool DeleteById(int id) //just action of deleting.. will return true or false para masend sa console message
    {
      using var db = new AppDb();
      var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == id); //object 'all its data' sabi ni AI

      if (employee == null) return false;

      //db.Employees.Remove(employee); 
            //tracked entity so it knows what do remove... knows the exact row
      
      employee.Status = "inactive";
      db.SaveChanges();
      return true;
    }
  }
}