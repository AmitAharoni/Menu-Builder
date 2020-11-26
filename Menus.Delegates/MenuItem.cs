using System;
using System.Collections.Generic;

namespace Menus.Delegates
{
     public delegate void ItemWasChosenDelegate(MenuItem i_Item);

     public delegate void BackExitOptionWasChosenDelegate(MenuItem i_Item);

     public class MenuItem
     {
          private string m_Title;
          private bool m_IsMainMenuItem;
          private List<MenuItem> m_SubMenu;
          private Action<MenuItem> m_Action;
          
          public event ItemWasChosenDelegate m_ItemWasChosen;

          public event BackExitOptionWasChosenDelegate m_BackExitOptionWasChosen;
          
          public string Title
          {
               get
               {
                    return m_Title;
               }

               set
               {
                    m_Title = value;
               }
          }

          public List<MenuItem> SubMenu
          {
               get
               {
                    return m_SubMenu;
               }

               set
               {
                    m_SubMenu = value;
               }
          }

          public bool IsMainMenuItem
          {
               get
               {
                    return m_IsMainMenuItem;
               }

               set
               {
                    m_IsMainMenuItem = value;
               }
          }

          public bool isLeafItem
          {
               get
               {
                    return m_SubMenu == null;
               }
          }
                            
          public event ItemWasChosenDelegate ItemWasChosen
          {
               add
               {
                    m_ItemWasChosen += value;
               }

               remove
               {
                    m_ItemWasChosen -= value;
               }
          }

          public event BackExitOptionWasChosenDelegate BackExitOptionWasChosen
          {
               add
               {
                    m_BackExitOptionWasChosen += value;
               }

               remove
               {
                    m_BackExitOptionWasChosen -= value;
               }
          }

          public event Action<MenuItem> Action
          {
               add
               {
                    m_Action += value;
               }

               remove
               {
                    m_Action -= value;
               }
          }

          public MenuItem(string i_Title, MainMenu i_Menu)
          {
               m_Title = i_Title;
               m_IsMainMenuItem = false;
               i_Menu.Subscrice(this);
          }

          public MenuItem(string i_Title, List<MenuItem> i_SubMenu, MainMenu i_Menu)
          {
               m_Title = i_Title;
               m_SubMenu = i_SubMenu;
               i_Menu.Subscrice(this);
          }

          private void readInput()
          {
               string userPick;
               do
               {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please select menu OPTION");
                    Console.ForegroundColor = ConsoleColor.White;
                    userPick = Console.ReadLine();
               }
               while(checkInputValidation(userPick) == false);

               if(userPick == "0")
               {
                    doWhenBackExitOptionChosen();
               }
               else
               {
                    m_SubMenu[int.Parse(userPick) - 1].doWhenItemChosen();
               }
          }

          private bool checkInputValidation(string i_userPick)
          {
               bool isValid = true;
               if(int.TryParse(i_userPick, out int o_res))
               {
                    if(o_res < 0 || m_SubMenu.Count < o_res)
                    {
                         isValid = false;
                         Console.WriteLine("Input ERROR! No such option in menu!");
                    }
               }
               else
               {
                    isValid = false;
                    Console.WriteLine("Input ERROR! Input must be number!");
               }

               return isValid;
          }

          public void Show()
          {
               int i = 1;
               string outputmsg, backOrExit;

               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine(m_Title);
               Console.ForegroundColor = ConsoleColor.White;
               if(IsMainMenuItem == true)
               {
                    backOrExit = "EXIT";
               }
               else
               {
                    backOrExit = "BACK";
               }

               Console.WriteLine("OPTION 0: {0}", backOrExit);

               foreach(MenuItem Item in m_SubMenu)
               {
                    outputmsg = string.Format(
@"OPTION {0}: {1}",
(i++).ToString(),
Item.m_Title);
                    Console.WriteLine(outputmsg);
               }

               Console.WriteLine();
               readInput();
          }

          public void DoInvoke()
          {
               Console.ForegroundColor = ConsoleColor.Yellow;
               m_Action?.Invoke(this);
               Console.ForegroundColor = ConsoleColor.White;
          }
          
          private void doWhenItemChosen()
          {
               OnItemChosen();
          }

          private void doWhenBackExitOptionChosen()
          {
               OnBackExitOptionWChosen();
          }

          protected virtual void OnItemChosen()
          {
               m_ItemWasChosen?.Invoke(this);
          }

          protected virtual void OnBackExitOptionWChosen()
          {
               m_BackExitOptionWasChosen?.Invoke(this);
          }
     }
}
