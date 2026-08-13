using System;
using EmployeeProject.Operations;
using Microsoft.VisualBasic;

namespace EmployeeProject
{
  public class Menu
  {
    private static int Choice(string message) //for letters only
    {
      if (!int.TryParse(Console.ReadLine(), out int mainChoice)) {
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
        Console.WriteLine($"│ Name:        {$"{e.FirstName} {e.LastName}",-31} │");
        Console.WriteLine($"│ Department:  {e.Department,-31} │");
        Console.WriteLine($"│ Salary:      {e.Salary,-31:C2} │");
        Console.WriteLine($"│ Hire Date:   {e.HireDate,-31:yyyy-MM-dd} │");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("└──────────────────────────────────────────────┘");
        Console.ResetColor();
    }

    private static void ConsoleMenuChoices()
    {
      Console.WriteLine("========================================"); 
      Console.WriteLine("           Employee Management          "); 
      Console.WriteLine("========================================"); 
      Console.WriteLine(">  [1] View Employee(s)");
      Console.WriteLine(">  [2] Add Employee");
      Console.WriteLine(">  [3] Update Employee");
      Console.WriteLine(">  [0] Exit");
      Console.Write(">> ");
    }

    private void SearchEmployee(int viewChoice, Get getFromDb)
    {
      Console.Write("Employee ID: ");
                
        do
        {
          int employeeID = Choice("Input valid Employee ID number");
          if (employeeID == -143) continue;
          
          Employee foundEmployee = getFromDb.ById(employeeID);

          if (foundEmployee == null) {
            Console.WriteLine("Invalid Emplyee ID"); 
            ClearTerminal();
            continue;
          }
          
          // Console.WriteLine($"{foundEmployee.EmployeeID} || {foundEmployee.FirstName} {foundEmployee.LastName} {foundEmployee.Department} {foundEmployee.Salary} {foundEmployee.HireDate}");

          ConsoleEmployeeDetails(foundEmployee);

          ClearTerminal();

        } while (viewChoice == 3);
    }

    private void ShowAllEmployee(Get getFromDb)
    {
      List<Employee> employees = getFromDb.All();

      foreach (Employee e in employees)
      {
        // Console.WriteLine($"{e.EmployeeID} || {e.FirstName} {e.LastName} {e.Department} {e.Salary} {e.HireDate}");

        ConsoleEmployeeDetails(e);
      }
      ClearTerminal();
    }

    public void ShowMainMenu()
    {
      bool alisNaBa = false;
      var getFromDb = new Get();
      do
      {
        ConsoleMenuChoices();
        
        int mainChoice = Choice("Input a valid number choice");
        if (mainChoice == -143) continue;

        switch (mainChoice) {
          case 1:
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
          case 2:
            Console.WriteLine("Add Employee");
            break;
          case 3:
            Console.WriteLine("Update Employee");
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

