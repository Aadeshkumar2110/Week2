using System;
using System.Collections.Generic;
using System.Text;

namespace Week2
{
    public delegate string DelGetName(string name);  // Delegate
    public class X   // Subscriber
    {
        public string getName(string name)
        {
            return name;
        }
    }

    public class EventHandling  // Publisher
    {
        static event DelGetName myEvent;  // Event
        //static void Main(string[] args)
        //{
        //    X x = new X();
        //    DelGetName del = new DelGetName(x.getName);  // Create delegate instance
        //    EventHandling.myEvent += del;  // Subscribe to event
        //    Console.WriteLine(EventHandling.myEvent("Books Issues Successfully"));  // Raise event
        //}
    }
}
