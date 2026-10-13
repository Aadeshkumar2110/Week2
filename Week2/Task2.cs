using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Week2
{
    public interface ITask2
    {
        void Pay(double amount);
    }

    public class  UPI : ITask2
    {
       public void Pay( double amount)
        {
            Console.Write("Enter UPI ID: ");
            string upiId = Console.ReadLine();
            if (upiId.Length >= 3 && upiId.Length <= 50 && upiId.Contains("@"))
            {
                Payment.PendingPayment();
                Task.Delay(10000).Wait();
                Console.WriteLine($"     Payment of {amount} Rs done using UPI with UPI ID: {upiId}");
            }
            else
            {
                Console.WriteLine("     Invalid UPI ID");
            }
        }
    }
    public class CreditCard : ITask2
    {
        public void Pay( double amount)
        {
            Console.Write("Enter Credit Card Number: ");
            long cardNumber = long.Parse(Console.ReadLine());
            if(cardNumber.ToString().Length <= 16 && cardNumber.ToString().Length >= 13)
            {
                Payment.PendingPayment();
                Thread.Sleep(10000);
                Console.WriteLine($"   Payment of {amount} Rs done using Credit Card");
            }
            else
            {
                Console.WriteLine("    Invalid Credit Card Number");
            }
        }
    }
    public class DebitCard : ITask2
    {
        public void Pay( double amount)
        {
            Console.Write("Enter Debit Card Number: ");
            long cardNumber = long.Parse(Console.ReadLine());
            if (cardNumber.ToString().Length <= 16 && cardNumber.ToString().Length >= 13)
            {
                Payment.PendingPayment();
                Thread.Sleep(10000);
                Console.WriteLine($"   Payment of {amount} Rs done using Debit Card");
            }
            else
            {
                Console.WriteLine("    Invalid Debit Card Number");
            }
        }
    }
    public class NetBanking : ITask2
    {
        public void Pay( double amount)
        {
            Console.Write("Enter Bank Name: ");
            string bankName = Console.ReadLine();
            Console.Write("Enter Account Number: ");
            long accountNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter IFSC Code: ");
            string ifscCode = Console.ReadLine();
            if (accountNumber.ToString().Length == 12 && ifscCode.Length == 11)
            { 
                Payment.PendingPayment();
                Thread.Sleep(10000);
                Console.WriteLine($"    Payment of {amount} Rs done using Net Banking at {bankName}");
            }
            else
            {
                Console.WriteLine("     Invalid Account Details");
            }
        }
    }
   
    public class Payment
    {
        //static void Main(string[] args)
        //{
        //    ITask2 payment;
        //    Console.WriteLine("Enter Payment Amount: ");
        //    double amount = double.Parse(Console.ReadLine());
        //    Console.WriteLine("------------- Select Payment Method -------------");
        //    Console.WriteLine("1. UPI");
        //    Console.WriteLine("2. Credit Card");
        //    Console.WriteLine("3. Debit Card");
        //    Console.WriteLine("4. Net Banking");
        //    Console.WriteLine("5. Exit");
        //    Console.WriteLine("");
        //    int choice = Program.ValidateChoice("Enter your choice : ");
        //    switch (choice)
        //    {
        //        case 1:
        //            payment = new UPI();
        //            break;
        //        case 2:
        //            payment = new CreditCard();
        //            break;
        //        case 3:
        //            payment = new DebitCard();
        //            break;
        //        case 4:
        //            payment = new NetBanking();
        //            break;
        //        case 5:
        //            Console.WriteLine("Failed to exit...");
        //            return;
        //        default:
        //            Console.WriteLine("Invalid choice. Defaulting to UPI.");
        //            payment = new UPI();
        //            break;
        //    }
        //    payment.Pay(amount);
        //}

        public static void PendingPayment()
        {
            Console.WriteLine("Please Wait Don't Skip Payment \n Pending.... ");
        }
    }
}
