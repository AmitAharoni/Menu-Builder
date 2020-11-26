using System;
using System.Collections.Generic;

namespace Menu.Interfaces
{
     public class MainMenu : IItemChosenSubscriber, IBackOrExitOptionChosenSubscriber
     {
          private MenuItem m_MenuItem;
          private MenuItem m_PrevMenuLevel;

          public MainMenu(string i_Title)
          {
               m_MenuItem = new MenuItem(i_Title, this);
               m_MenuItem.SubMenu = new List<MenuItem>();
               m_PrevMenuLevel = null;
               m_MenuItem.IsMainMenuItem = true;
          }

          public MenuItem Item
          {
               get
               {
                    return m_MenuItem;
               }

               set
               {
                    m_MenuItem = value;
               }
          }

          public void Show()
          {
               while(m_MenuItem != null)
               {
                    m_MenuItem.Show();
               }
          }

          void IItemChosenSubscriber.ItemWasChosen(MenuItem i_Item)
          {
               Console.Clear();
               if(i_Item.isLeafItem == true)
               {
                    i_Item.Action.DoInvoke();
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
               }
               else
               {
                    m_PrevMenuLevel = m_MenuItem;
                    m_MenuItem = i_Item;
                    i_Item.Show();
               }
          }

          void IBackOrExitOptionChosenSubscriber.BackOrExitOptionWasChosen()
          {
               if(m_PrevMenuLevel == m_MenuItem)
               {
                    m_MenuItem = null;
               }
               else
               {
                    m_MenuItem = m_PrevMenuLevel;
               }

               Console.Clear();
          }
     }
}