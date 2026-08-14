using System.Collections.Generic;

namespace EmployeeProject.Operations
{
  public class Post
  {
    public void AddEmployee(Employee employee) //doesnt return, just runs... good for post
    {
      //email 
      string AlterEmail()
      {
        string emplFirstName = employee.FirstName.ToLower();
        string emplMiddleName = employee.MiddleName.ToLower();
        string emplLastName = employee.LastName.ToLower();

        char first = emplFirstName.FirstOrDefault(); //returns 0 if empty.. sana mafill up-an lahat
        char mid = emplMiddleName.FirstOrDefault();

        string baseEmail = $"{first}{mid}{emplLastName}";
        string altered = $"{baseEmail}@company.com";

        //fetch DB emails if there's a dupe.. we count
        using var db = new AppDb();
        List<string> similarEmails = db.Employees
          .Where(e => e.Email.StartsWith(baseEmail)) //starts with same email
          .Select(e => e.Email)
          .AsEnumerable()
          .Where(e => (e[baseEmail.Length] == '@') || (char.IsDigit(e[baseEmail.Length]))) //if same length, check iss '@' or number kasunod,, meaning dupli
          .ToList();
        
        if (similarEmails.Count >= 1)
        {
          altered = $"{baseEmail}{similarEmails.Count}@company.com";
        }
        return altered;
      }
      
      //add the email
      employee.Email = AlterEmail();

      //send to db
      using var db = new AppDb();
      db.Employees.Add(employee);
      db.SaveChanges();
    }
  }
}