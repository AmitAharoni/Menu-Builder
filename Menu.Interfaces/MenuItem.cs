using System;
using System.Collections.Generic;

namespace Menu.Interfaces
{
     public class MenuItem 
     {
          private string m_Title;
          private bool m_IsMainMenuItem;
          private readonly IAction m_Action;
          private List<MenuItem> m_SubMenu;
          private NotifierToSubscribers<IItemChosenSubscriber> m_ItemSubscribers;
          private NotifierToSubscribers<IBackOrExitOptionChosenSubscriber> m_BackOrExitSubscribers;

          public MenuItem(string i_Title, MainMenu i_Subscriber)
          {
               m_Title = i_Title;
               makeSubscriber(i_Subscriber);
          }

          public MenuItem(string i_Title, IAction i_Action, MainMenu i_Subscriber)
          {
               m_Title = i_Title;
               m_Action = i_Action;
               makeSubscriber(i_Subscriber);
          }

          public MenuItem(string i_Title, List<MenuItem> i_SubMenu, MainMenu i_Subscriber)
          {
               m_Title = i_Title;
               m_SubMenu = i_SubMenu;
               makeSubscriber(i_Subscriber);
          }

          private void makeSubscriber(MainMenu i_Subscriber)
          {
               m_ItemSubscribers = new NotifierToSubscribers<IItemChosenSubscriber>();
               m_ItemSubscribers.AddSubscriber(i_Subscriber);
               m_BackOrExitSubscribers = new NotifierToSubscribers<IBackOrExitOptionChosenSubscriber>();
               m_BackOrExitSubscribers.AddSubscriber(i_Subscriber);
          }

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

          public IAction Action
          {
               get
               {
                    return m_Action;
               }
          }

          private void readInput()
          {
               string userPick;
               int itemNumber;
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
                    itemNumber = int.Parse(userPick) - 1;
                    m_SubMenu[itemNumber].doWhenItemChosen(m_SubMenu[itemNumber]);
               }
          }

          private void doWhenBackExitOptionChosen()
          {
               m_BackOrExitSubscribers.NotifySubscribers(this, false);
          }

          private void doWhenItemChosen(MenuItem i_Item)
          {
               m_ItemSubscribers.NotifySubscribers(i_Item, true);
          }

          private bool checkInputValidation(string i_UserPick)
          {
               bool isValid = true;
               if(int.TryParse(i_UserPick, out int o_res))
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
     }
}
