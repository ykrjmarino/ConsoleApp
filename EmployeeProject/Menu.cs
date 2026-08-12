using System;

namespace EmployeeProject
{
  public class Menu
  {
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
        //guard
        if (!int.TryParse(Console.ReadLine(), out int mainChoice)) {
          Console.Clear();
          Console.WriteLine("========================================"); 
          Console.WriteLine("                 Invalid!               "); 
          Console.WriteLine("========================================"); 
          Thread.Sleep(600); Console.Clear();
          Console.Clear();
          Console.WriteLine("========================================"); 
          Console.WriteLine("       Input a valid number choice      "); 
          Console.WriteLine("========================================"); 
          Thread.Sleep(700); Console.Clear();
          continue;
        }

        switch (mainChoice) {
          case 1:
            Console.WriteLine("View Employee(s)");
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
    
   public void ShowInvalid()
   {
     
   }
   
   public void ShowGoodbye() //bye lang...
   {
    
   }
  }
}
