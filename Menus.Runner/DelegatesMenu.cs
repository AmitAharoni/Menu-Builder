using System;
using System.Collections.Generic;

namespace Menus.Runner
{
     public class DelegatesMenu
     {
          internal static void CreateDelegatesMenuForTest(Delegates.MainMenu i_DelegatesMenu)
          {
               List<Delegates.MenuItem> digitAndVersion = new List<Delegates.MenuItem>();
               Delegates.MenuItem countCapital = new Delegates.MenuItem("Count Capital", i_DelegatesMenu);
               countCapital.Action += CountCapitalAction;
               Delegates.MenuItem showVersion = new Delegates.MenuItem("Show Version", i_DelegatesMenu);
               showVersion.Action += ShowVersionAction;
               digitAndVersion.Add(countCapital);
               digitAndVersion.Add(showVersion);
               Delegates.MenuItem option1 = new Delegates.MenuItem("Version and Digits", digitAndVersion, i_DelegatesMenu);
               i_DelegatesMenu.Item.SubMenu.Add(option1);

               List<Delegates.MenuItem> dateAndTime = new List<Delegates.MenuItem>();
               Delegates.MenuItem showTime = new Delegates.MenuItem("Show Time", i_DelegatesMenu);
               showTime.Action += ShowTimeAction;
               Delegates.MenuItem showDate = new Delegates.MenuItem("Show Date", i_DelegatesMenu);
               showDate.Action += ShowDateAction;
               dateAndTime.Add(showTime);
               dateAndTime.Add(showDate);
               Delegates.MenuItem option2 = new Delegates.MenuItem("Show Date/Time", dateAndTime, i_DelegatesMenu);
               i_DelegatesMenu.Item.SubMenu.Add(option2);
          }

          internal static void RunDelegatesMenu(Delegates.MainMenu i_DelegatesMenu)
          {
                i_DelegatesMenu.Show();
               EndOfMenu();
          }

          internal static void ShowVersionAction(Delegates.MenuItem i_Item)
          {
               Console.Write("Version: 20.2.4.30620");
          }

          internal static void ShowTimeAction(Delegates.MenuItem i_Item)
          {
               DateTime time = DateTime.Now;

               Console.Write("The Time is:{0}", time.ToShortTimeString());
          }

          internal static void ShowDateAction(Delegates.MenuItem i_Item)
          {
               DateTime now = DateTime.Today;

               Console.Write("The Date is:{0}", now.ToShortDateString());
          }

          internal static void CountCapitalAction(Delegates.MenuItem i_Item)
          {
               int counterUpperCaseLetters = 0;

               Console.WriteLine("Please enter english string (count UPPER-CASE letters)");
               Console.ForegroundColor = ConsoleColor.White;
               string stringToCheck = Console.ReadLine();

               foreach(char c in stringToCheck)
               {
                    if(char.IsUpper(c) == true)
                    {
                         counterUpperCaseLetters++;
                    }
               }

               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.Write("There are {0} upper-case letters", counterUpperCaseLetters);
          }

          private static void EndOfMenu()
          {
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.Write("BYE BYE");
               System.Threading.Thread.Sleep(2000);
               Console.ForegroundColor = ConsoleColor.White;
          }
     }
}
