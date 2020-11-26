using System;
using System.Collections.Generic;

namespace Menu.Interfaces
{
     public class NotifierToSubscribers<T>
     {
          private List<T> m_SubscribersList;

          public void AddSubscriber(T i_Subscriber)
          {
               if(m_SubscribersList == null)
               {
                    m_SubscribersList = new List<T>();
               }

               m_SubscribersList.Add(i_Subscriber);
          }

          public void RemoveSubscriber(T i_Subscriber)
          {
               m_SubscribersList.Remove(i_Subscriber);
          }

          public void NotifySubscribers(MenuItem i_Item, bool i_isItem)
          {
               foreach(T Subscriber in m_SubscribersList)
               {
                    if(i_isItem == true)
                    {
                         (Subscriber as IItemChosenSubscriber).ItemWasChosen(i_Item);
                    }
                    else
                    {
                         (Subscriber as IBackOrExitOptionChosenSubscriber).BackOrExitOptionWasChosen();
                    }
               }
          }
     }
}
