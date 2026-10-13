using System;
using System.Collections.Generic;
using System.Text;

namespace Week2
{
    public delegate void delNotification(string message);
    //public class Notifications // Publisher
    //{
    //    public event delNotification SendNotificationEvent;
    //    static void Main()
    //    {
    //        EmailNotification email = new EmailNotification();
    //        SMSNotification sms = new SMSNotification();
    //        AppNotification app = new AppNotification();

    //        delNotification delegateObj = new delNotification(email.SendEmail);
    //        delegateObj += sms.SendSMS;
    //        delegateObj += app.SendAppNotification;
    //        // Event calling 
    //        Notifications notifications = new Notifications();
    //        notifications.SendNotificationEvent += delegateObj;
    //        notifications.SendNotificationEvent("Book Issue Successfully ");
    //    }

    //}
    public class EmailNotification
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Email Notification: {message}");
        }
    }

    public class SMSNotification // Subscriber
    {
        public void SendSMS(string message)
        {
            Console.WriteLine($"SMS Notification: {message}");
        }
    }
    public class AppNotification
    {
        public void SendAppNotification(string message)
        {
            Console.WriteLine($"App Notification: {message}");
        }
    }
}


