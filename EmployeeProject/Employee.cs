// Employee.cs

using System;

namespace EmployeeProject
{
  public class Employee
  {
    public int EmployeeID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public required decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Status { get; set; } = "active";
  }
}