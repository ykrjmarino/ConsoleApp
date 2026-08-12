// using System.Collections.Generic;

// namespace EmployeeProject.Operations
// {
//   public class Get
//   {
//     public List<Employee> All()
//     {
//       using var db = new AppDb();
//       return db.Employees.ToList();
//     }

//     public Employee GetById(int id)
//     {
//       using var db = new AppDb();
//       return db.Employees.FirstOrDefault(e => e.EmployeeID == id);
//     }

//   }
// }