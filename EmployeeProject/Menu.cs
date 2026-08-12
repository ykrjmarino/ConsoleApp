using System;

namespace EmployeeProject
{
  public class Menu
  {
    private int Choice(string message)
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
        return -1;
      }
      return mainChoice;
    }

    public void ShowMainMenu()
    {
      bool alisNaBa = false;
      do
      {
        Console.WriteLine("========================================"); 
        Console.WriteLine("           Employee Management          "); 
        Console.WriteLine("========================================"); 
        Console.WriteLine(">  [1] View Employee(s)");
        Console.WriteLine(">  [2] Add Employee");
        Console.WriteLine(">  [3] Update Employee");
        Console.WriteLine(">  [0] Exit");//try doing any keys will be the exit button? or just print invalid
        Console.Write(">> ");
        
        int mainChoice = Choice("Input a valid number choice");
        if (mainChoice == -1) continue;

        switch (mainChoice) {
          case 1:
            Console.Clear();
            Console.WriteLine("========================================"); 
            Console.WriteLine("           Employee Management          "); 
            Console.WriteLine("========================================"); 
            Console.WriteLine(">  [1] Search an Employee");
            Console.WriteLine(">  [2] View ALL Employees");
            Console.WriteLine(">  [3] Back Menu");
            Console.Write(">> "); 
            int viewChoice = Choice("Input a valid number choice");
            if (viewChoice == -1) continue;

            switch (viewChoice)
            {
              case 1:  
                Console.Write("Employee ID: ");
                
                do
                {
                  int employeeID = Choice("Input valid Employee ID number");
                  if (employeeID == -1) continue;

                  Console.WriteLine($"Success! Parsed number: {employeeID}");
                  Console.WriteLine("Press Enter to continue...");
                  Console.ReadLine();
                  Console.Clear();
                } while (viewChoice == 3);

                break;
              case 2:  
                Console.WriteLine("pakita lahat here");
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
    
    //  public void ShowInvalid()
    //  {
      
    //  }
    
    //  public void ShowGoodbye() //bye lang...
    //  {
      
    //  }
  }
}
