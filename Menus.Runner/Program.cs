using System;

namespace Menus.Runner
{
     public class Program
     {
          public static void Main()
          {
               Menu.Interfaces.MainMenu interfacesMenu1 = new Menu.Interfaces.MainMenu("Interfaces Menu");
               InterfacesMenu.CreateInterfacesMenuForTest(interfacesMenu1);
               InterfacesMenu.RunInterfacesMenu(interfacesMenu1);

               Console.Clear();

               Delegates.MainMenu delegatesMenu1 = new Delegates.MainMenu("Deletgates Menu");
               DelegatesMenu.CreateDelegatesMenuForTest(delegatesMenu1);
               DelegatesMenu.RunDelegatesMenu(delegatesMenu1);
          }
     }
}