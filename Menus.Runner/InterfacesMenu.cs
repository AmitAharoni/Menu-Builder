using Menu.Interfaces;
using System;
using System.Collections.Generic;

namespace Menus.Runner
{
     public class InterfacesMenu
     {
          internal static void CreateInterfacesMenuForTest(MainMenu i_Menu)
          {
               CountCapital count = new CountCapital(); 
               MenuItem CountCapital = new Menu.Interfaces.MenuItem("Count Capital", count, i_Menu);
               ShowVersion version = new ShowVersion();
               Menu.Interfaces.MenuItem ShowVersion = new Menu.Interfaces.MenuItem("Show Version", version, i_Menu);
               List<Menu.Interfaces.MenuItem> digitAndVersion = new List<Menu.Interfaces.MenuItem>();
               digitAndVersion.Add(CountCapital);
               digitAndVersion.Add(ShowVersion);
               Menu.Interfaces.MenuItem option1 = new Menu.Interfaces.MenuItem("Version and Digits", digitAndVersion, i_Menu);
               i_Menu.Item.SubMenu.Add(option1);

               ShowTime time = new ShowTime();
               Menu.Interfaces.MenuItem showTime = new Menu.Interfaces.MenuItem("Show Time", time, i_Menu);
               ShowDate date = new ShowDate();
               Menu.Interfaces.MenuItem showDate = new Menu.Interfaces.MenuItem("Show Date", date, i_Menu);
               List<Menu.Interfaces.MenuItem> dateAndTime = new List<Menu.Interfaces.MenuItem>();
               dateAndTime.Add(showTime);
               dateAndTime.Add(showDate);
               Menu.Interfaces.MenuItem option2 = new Menu.Interfaces.MenuItem("Show Date/Time", dateAndTime, i_Menu);
               i_Menu.Item.SubMenu.Add(option2);
          }

          internal static void RunInterfacesMenu(Menu.Interfaces.MainMenu i_InterfacesMenu)
          {
               i_InterfacesMenu.Show();
               EndOfMenu();
          }

          internal struct CountCapital : Menu.Interfaces.IAction
          {
               void Menu.Interfaces.IAction.DoInvoke()
               {
                    int counterUpperCaseLetters = 0;

                    Console.ForegroundColor = ConsoleColor.Yellow;
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
                    Console.ForegroundColor = ConsoleColor.White;
               }
          }

          internal struct ShowTime : Menu.Interfaces.IAction
          {
               void Menu.Interfaces.IAction.DoInvoke()
               {
                    DateTime time = DateTime.Now;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("The Time is:{0}", time.ToShortTimeString());
                    Console.ForegroundColor = ConsoleColor.White;
               }
          }

          internal struct ShowDate : Menu.Interfaces.IAction
          {
               void Menu.Interfaces.IAction.DoInvoke()
               {
                    DateTime now = DateTime.Today;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("The Date is:{0}", now.ToShortDateString());
                    Console.ForegroundColor = ConsoleColor.White;
               }
          }

          internal struct ShowVersion : Menu.Interfaces.IAction
          {
               void Menu.Interfaces.IAction.DoInvoke()
               {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Version: 20.2.4.30620");
                    Console.ForegroundColor = ConsoleColor.White;
               }
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