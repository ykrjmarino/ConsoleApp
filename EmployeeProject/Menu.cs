using System;
using EmployeeProject.Operations;
using Microsoft.VisualBasic;

namespace EmployeeProject
{
  public class Menu
  {
    private static int Choice(string message) //for letters only
    {
      if (!int.TryParse(Console.ReadLine(), out int mainChoice) || (mainChoice < 0)) { //+positive number onli
        Console.Clear();
        Console.WriteLine("========================================"); 
        Console.WriteLine("                 Invalid!               "); 
        Console.WriteLine("========================================"); 
        Thread.Sleep(600); Console.Clear();
        Console.Clear();
        Console.WriteLine("========================================"); 
        Console.WriteLine($"       {message}      "); 
        Console.WriteLine("========================================"); 
        Thread.Sleep(900); Console.Clear();
        return -143;
      }
      return mainChoice;
    }

    private static void ClearTerminal()
    {
      Console.WriteLine("Press Enter to continue...");
      Console.ReadLine();
      Console.Clear();
    }

    private static void ConsoleViewingEmployee()
    {
      Console.Clear();
      Console.WriteLine("========================================"); 
      Console.WriteLine("           Viewing of Employees         "); 
      Console.WriteLine("========================================"); 
      Console.WriteLine(">  [1] Search an Employee");
      Console.WriteLine(">  [2] View ALL Employees");
      Console.WriteLine(">  [3] Back Menu");
      Console.Write(">> "); 
    }

    private static void ConsoleEmployeeDetails(Employee e)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("┌──────────────────────────────────────────────┐");
        Console.WriteLine("│               EMPLOYEE DETAILS               │");
        Console.WriteLine("├──────────────────────────────────────────────┤");
        Console.WriteLine($"│ ID:          {e.EmployeeID,-31} │");
        Console.WriteLine($"│ Name:        {$"{e.FirstName} {e.MiddleName.FirstOrDefault()}. {e.LastName}",-31} │");
        Console.WriteLine($"│ Email:       {e.Email,-31} │");
        Console.WriteLine($"│ Department:  {e.Department,-31} │");
        Console.WriteLine($"│ Salary:      {e.Salary,-31:C2} │");
        Console.WriteLine($"│ Hire Date:   {e.HireDate,-31:yyyy-MM-dd} │");
        Console.WriteLine($"│ Status:      {e.Status,-31} │");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("└──────────────────────────────────────────────┘");
        Console.ResetColor();
    }

    private static void ConsoleMenuChoices(Get getFromDb)
    {
      int totalActive = getFromDb.CountAll(); 
      decimal avgSalary = getFromDb.averageSalary();

      Console.Clear();
      Console.WriteLine("┌────────────────────┐  ┌────────────────────┐");
      Console.WriteLine("│  Active Employees  │  │   Average Salary   │");
      Console.WriteLine("├────────────────────┤  ├────────────────────┤");
      Console.WriteLine($"│{totalActive,-19} │  │{$"₱{avgSalary:N2}",-19} │");
      Console.WriteLine("└────────────────────┘  └────────────────────┘");
      Console.WriteLine();
      Console.WriteLine("========================================"); 
      Console.WriteLine("           Employee Management          "); 
      Console.WriteLine("========================================"); 
      Console.WriteLine(">  [1] View Employee(s)");
      Console.WriteLine(">  [2] Add Employee");
      Console.WriteLine(">  [3] Update Employee");
      Console.WriteLine(">  [4] Delete Employee");
      Console.WriteLine(">  [5] Restore Employee");
      Console.WriteLine(">  [0] Exit");
      Console.Write(">> ");
    }

    private static void ConsoleChoosePatch()
    {
      Console.WriteLine("========================================"); 
      Console.WriteLine("             Update Employee            ");
      Console.WriteLine("========================================");
      Console.WriteLine(">  [1] First Name");
      Console.WriteLine(">  [2] Middle Name");
      Console.WriteLine(">  [3] Last Name");
      Console.WriteLine(">  [4] Department");
      Console.WriteLine(">  [5] Salary");
      Console.WriteLine(">  [6] Email");
      Console.WriteLine(">  [0] Back");
      Console.Write(">> ");
    }

    private static (string FirstName, string MiddleName,string LastName, string Department, decimal Salary, DateTime HireDate) ConsoleAddEmployee() //(string, decimal..) are the types before the name
    {
      Console.Clear();
      Console.WriteLine("========================================"); 
      Console.WriteLine("             Create an Employee         "); 
      Console.WriteLine("========================================"); 

      Console.Write(">  First Name: "); 
      string firstNameInput = Console.ReadLine() ?? "";

      Console.Write(">  Middle Name: ");
      string middleNameInput = Console.ReadLine() ?? "";

      Console.Write(">  Last Name: ");
      string lastNameInput = Console.ReadLine() ?? "";
        
      Console.Write(">  Department: ");
      string departmentInput = Console.ReadLine() ?? "";

      Console.Write(">  Salary: ");
      decimal salaryInput;
      while (!decimal.TryParse(Console.ReadLine(), out salaryInput) || salaryInput < 0)
      { 
        Console.WriteLine("Invalid salary! Please enter a positive number");
        Console.Write(">  Salary: ");
      }
      DateTime hireDate = DateTime.Now; 

      return (firstNameInput, middleNameInput, lastNameInput, departmentInput, salaryInput, hireDate);
    }
    
    private void SearchEmployee(int viewChoice, Get getFromDb)
    {
      Console.Write(">  Employee ID: ");
      int employeeID;
        do
        {
          while (!int.TryParse(Console.ReadLine(), out employeeID)) //while the input is not a number(s)
          { 
            Console.WriteLine("Invalid ID! Input valid Employee ID number");
            Console.Write(">  Employee ID: ");
          }
          
          Employee? foundEmployee = getFromDb.ById(employeeID);

          if (foundEmployee == null) {
            Thread.Sleep(500); Console.Clear();
            Console.WriteLine($"Employee ID: {employeeID}"); 
            Console.WriteLine("========================================"); 
            Console.WriteLine("           No Employee Found...         "); 
            Console.WriteLine("========================================"); 
            ClearTerminal();
            continue;
          }
          
          ConsoleEmployeeDetails(foundEmployee);

          ClearTerminal();

        } while (viewChoice == 3);
    }

    private void ShowAllEmployee(Get getFromDb)
    {
      List<Employee> employees = getFromDb.All();

      foreach (Employee e in employees)
      {
        ConsoleEmployeeDetails(e);
      }
      ClearTerminal();
    }

    private void UpdateEmployee(Get getFromDb, Update updateDb)
    {
      //ask for employee ID to update
      Console.Write(">  Employee ID: ");
      int employeeID;
      while (!int.TryParse(Console.ReadLine(), out employeeID)) //while the input is not a number(s)
      { 
        Console.WriteLine("Invalid ID! Input valid Employee ID number");
        Console.Write(">  Employee ID: ");
      }
      
      Employee? foundEmployee = getFromDb.ById(employeeID);

      if (foundEmployee == null) {
        Thread.Sleep(500); Console.Clear();
        Console.WriteLine($"Employee ID: {employeeID}"); 
        Console.WriteLine("========================================"); 
        Console.WriteLine("           No Employee Found...         "); 
        Console.WriteLine("========================================"); 
        ClearTerminal();
        return;
      }
      
      Thread.Sleep(800); Console.Clear();
      ConsoleEmployeeDetails(foundEmployee);

      //choose what field to change
      ConsoleChoosePatch();
      int patchChoice;
      while (!int.TryParse(Console.ReadLine(), out patchChoice)) 
      { //while the input is not a number(s)
        Console.WriteLine("Invalid Choice!");
        Console.Write(">> ");
      }

      switch (patchChoice)
      {
        case 1: // First Name
          Console.Write(">  First Name: ");
          string firstName = Console.ReadLine() ?? "";

          updateDb.UpdateEmployee(employeeID, patchChoice, firstName, null);
          Console.WriteLine("Updated successfully!"); ClearTerminal();
          break;
        case 2: // Middle Name
          Console.Write(">  Middle Name: ");
          string midName = Console.ReadLine() ?? "";

          updateDb.UpdateEmployee(employeeID, patchChoice, midName, null);
          Console.WriteLine("Updated successfully!"); ClearTerminal();
          break;
        case 3: // Lst Name
          Console.Write(">  Last Name: ");
          string lastName = Console.ReadLine() ?? "";

          updateDb.UpdateEmployee(employeeID, patchChoice, lastName, null);
          Console.WriteLine("Updated successfully!"); ClearTerminal();
          break;
        case 4: // Dept
          Console.Write(">  Department: ");
          string dept = Console.ReadLine() ?? "";

          updateDb.UpdateEmployee(employeeID, patchChoice, dept, null);
          Console.WriteLine("Updated successfully!"); ClearTerminal();
          break;
        case 5: // Salary
          Console.Write(">  Salary: ");
          decimal salaryInput;
          while (!decimal.TryParse(Console.ReadLine(), out salaryInput) || salaryInput < 0)
          { 
            Console.WriteLine("Invalid salary! Please enter a positive number");
            Console.Write(">  Salary: ");
          }
          updateDb.UpdateEmployee(employeeID, patchChoice, null, salaryInput);
          Console.WriteLine("Updated successfully!"); ClearTerminal();
          break;
        case 6: // Email
          Console.Write(">  Email: ");
          string email = Console.ReadLine() ?? "";
          updateDb.UpdateEmployee(employeeID, patchChoice, email, null);
          Console.WriteLine("Updated successfully!"); ClearTerminal();
          break;
        case 0:
          Console.Clear();
          break;
        default:
          Console.WriteLine("Invalid! Input numbers from the options.");
          Thread.Sleep(800); Console.Clear();
          break;
      }
    }

    private void DeleteEmployee(Get getFromDb, Delete deleteFromDb)
    {
      //ask for employee ID to delete (soft) naol
      Console.Write(">  Employee ID: ");
      int employeeID;
      while (!int.TryParse(Console.ReadLine(), out employeeID)) //while the input is not a number(s)
      { 
        Console.WriteLine("Invalid ID! Input valid Employee ID number");
        Console.Write(">  Employee ID: ");
      }
      
      Employee? foundEmployee = getFromDb.ById(employeeID); //returns the employee details

      if (foundEmployee == null) {
        Thread.Sleep(500); Console.Clear();
        Console.WriteLine($"Employee ID: {employeeID}"); 
        Console.WriteLine("========================================"); 
        Console.WriteLine("           No Employee Found...         "); 
        Console.WriteLine("========================================"); 
        ClearTerminal();
        return;
      }
      
      Thread.Sleep(800); Console.Clear();
      ConsoleEmployeeDetails(foundEmployee);

      Console.WriteLine("Are you sure you want to delete? (You got two choices: yes or !yes)");
      Console.Write(">> ");

      while (true) 
      { 
        string? shouldDelete = Console.ReadLine();

        if (shouldDelete?.Trim().ToLower() == "yes")
        {
          bool deletedEmployee = deleteFromDb.DeleteById(employeeID); //return true of false
          //stores and executes

          if (deletedEmployee) Console.WriteLine("Employee successfully deleted!");
          else Console.WriteLine("Employee not found or deletion failed.");

          ClearTerminal();
          break;
        } 
        if (shouldDelete?.Trim().ToLower() == "!yes"){
          Console.WriteLine("Canceled action. Employee not deleted.");
          ClearTerminal();
          break;
        }
        Console.WriteLine("Invalid Input! Please type 'yes' or '!yes'");
        Console.Write(">> ");
      }   
    }

    private void RestoreEmployee(Get getFromDb, Update updateDb)
    {
      //ask for employee ID to delete (soft) naol
      Console.Write(">  Employee ID: ");
      int employeeID;
      while (!int.TryParse(Console.ReadLine(), out employeeID)) //while the input is not a number(s)
      { 
        Console.WriteLine("Invalid ID! Input valid Employee ID number");
        Console.Write(">  Employee ID: ");
      }
      
      Employee? foundEmployee = getFromDb.InactiveById(employeeID); //returns the employee details

      if (foundEmployee == null) {
        Thread.Sleep(500); Console.Clear();
        Console.WriteLine($"Employee ID: {employeeID}"); 
        Console.WriteLine("========================================"); 
        Console.WriteLine("           No Employee Found...         "); 
        Console.WriteLine("========================================"); 
        ClearTerminal();
        return;
      }
      
      Thread.Sleep(800); Console.Clear();
      ConsoleEmployeeDetails(foundEmployee);

      Console.WriteLine("Are you sure you want to restore this Employee? (You got two choices: yes or !yes)");
      Console.Write(">> ");

      while (true) 
      { 
        string? shouldRestore = Console.ReadLine();

        if (shouldRestore?.Trim().ToLower() == "yes")
        {
          bool restoredEmployee = updateDb.RestoreById(employeeID); //return true of false
          //stores and executes

          if (restoredEmployee) Console.WriteLine("Employee successfully restored!");
          else Console.WriteLine("Employee not found or restoration failed.");

          ClearTerminal();
          break;
        } 
        if (shouldRestore?.Trim().ToLower() == "!yes"){
          Console.WriteLine("Canceled action. Employee not restored.");
          ClearTerminal();
          break;
        }
        Console.WriteLine("Invalid Input! Please type 'yes' or '!yes'");
        Console.Write(">> ");
      }   
    }


    public void ShowMainMenu()
    {
      bool alisNaBa = false;
      var getFromDb = new Get();
      var postToDb = new Post();
      var updateDb = new Update(); 
      var deleteFromDb = new Delete();

      do
      {
        ConsoleMenuChoices(getFromDb);
        
        int mainChoice = Choice("Input a valid number choice");
        if (mainChoice == -143) continue;

        switch (mainChoice) {
          case 1: //GET --- SearchEmployee(viewChoice, getFromDb); ShowAllEmployee(getFromDb);
            ConsoleViewingEmployee();
            int viewChoice = Choice("Input a valid number choice");
            if (viewChoice == -143) continue;

            switch (viewChoice)
            {
              case 1:  //view one employee
                SearchEmployee(viewChoice, getFromDb);
                break;
              case 2:  //view all employee
                ShowAllEmployee(getFromDb);
                break;
              case 3:  
                Console.Clear();
                break;
              default:
                Console.WriteLine("Invalid! Input numbers from the options.");
                Thread.Sleep(800); Console.Clear();
                break;
            }
            break;
          case 2: //POST --- postToDb.AddEmployee(newEmpl);
            var (firstName, middleName, lastName, department, salary, hireDate) = ConsoleAddEmployee();

            Employee newEmpl = new Employee
            {
              FirstName = firstName,
              MiddleName = middleName,
              LastName = lastName,
              Department = department,
              Salary = salary,
              HireDate = hireDate
            };

            postToDb.AddEmployee(newEmpl);
            Console.WriteLine("Employee added successfully!");
            ClearTerminal();
            break;
          case 3: //UPDATE (patch talaga) --- UpdateEmployee(getFromDb, updateDb);
              UpdateEmployee(getFromDb, updateDb);
            break;
          case 4: //DELETE --- DeleteEmployee(getFromDb, deleteFromDb);
              DeleteEmployee(getFromDb, deleteFromDb);
            break;
          case 5:
              RestoreEmployee(getFromDb, updateDb);
              break;
          case 0:
            Console.Clear();
            Console.WriteLine("              bye.            ");
            Thread.Sleep(800); Console.Clear();
            alisNaBa = true;
            break;
          default:
            Console.WriteLine("Invalid! Input numbers from the options.");
            Thread.Sleep(800); Console.Clear();
          break;
        }

      } while (!alisNaBa); //not true => false
    }
  }
}

