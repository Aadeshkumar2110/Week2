using Week2;

abstract class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double BasicSalary { get; set; }
    public abstract double CalculateSalary();
}

public delegate void SalaryCalculatedEventHandler(string mssg);
public class SalaryCalculator
{
    public event SalaryCalculatedEventHandler SalaryCalculated;
    public void Notify()
    {
        EmailNotification email = new EmailNotification();
        SMSNotification sms = new SMSNotification();
        AppNotification app = new AppNotification();

        SalaryCalculatedEventHandler delegateObject= new SalaryCalculatedEventHandler(email.SendEmail);
        delegateObject += sms.SendSMS;
        delegateObject += app.SendAppNotification;
        SalaryCalculated += delegateObject;
        SalaryCalculated("   Salary Successfully Calculated..");
    }
}

class Manager : Employee
{
    public override double CalculateSalary()
    {
        SalaryCalculator notify = new SalaryCalculator();
       
        double salary = BasicSalary + BasicSalary * 0.2 + BasicSalary * 0.1;
        Console.WriteLine("-------------------- Salary Calculating for Manager -------------------");
        Console.WriteLine($"Basic Salary: {BasicSalary}");
        Console.WriteLine($"20% of Basic Salary = HRA: {BasicSalary * 0.2}");  // 20% of Basic Salary
        Console.WriteLine($"10% of Basic Salary = DA: {BasicSalary * 0.1}"); // 10% of Basic Salary
        Console.WriteLine($"Gross Salary: {salary}");
        Console.WriteLine($"20% of Gross Salary = Tax: {salary * 0.2 }"); // 20% of Gross Salary
        Console.WriteLine($"15% of Gross Salary = PF: {salary * 0.15}"); // 15% of Gross Salary
        Console.WriteLine("------------------------------------------------------------------------");
        notify.Notify();
        return salary-salary * 0.2-salary * 0.15;
    }
}
class Developer : Employee
{
    public override double CalculateSalary()
    {
        double salary = BasicSalary + BasicSalary * 0.15 + BasicSalary * 0.05;
        Console.WriteLine("-------------------- Salary Calculating for Developer -------------------");
        Console.WriteLine($"Basic Salary: {BasicSalary}");
        Console.WriteLine($"15% of Basic Salary = HRA: {BasicSalary * 0.15}");  // 15% of Basic Salary
        Console.WriteLine($"5% of Basic Salary = DA: {BasicSalary * 0.05}"); // 5% of Basic Salary
        Console.WriteLine($"Gross Salary: {salary}");
        Console.WriteLine($"15% of Gross Salary = Tax: {salary * 0.15}"); // 15% of Gross Salary
        Console.WriteLine($"10% of Gross Salary = PF: {salary * 0.10}"); // 10% of Gross Salary
        Console.WriteLine("------------------------------------------------------------------------");
        SalaryCalculator notify = new SalaryCalculator();
        notify.Notify();
        return salary - salary * 0.15 - salary * 0.10;
    }
}
class  Accountant : Employee
{
    public double OvertimePay { get; set; }
    public override double CalculateSalary()
    {
        double salary = BasicSalary + BasicSalary * 0.25 + BasicSalary * 0.15;
        Console.WriteLine("-------------------- Salary Calculating for Accountant -------------------");
        Console.WriteLine($"Basic Salary: {BasicSalary}");
        Console.WriteLine($"25% of Basic Salary = HRA: {BasicSalary * 0.25}");  // 25% of Basic Salary
        Console.WriteLine($"15% of Basic Salary = DA: {BasicSalary * 0.15}"); // 15% of Basic Salary
        Console.WriteLine($"Gross Salary: {salary}");
        Console.WriteLine($"25% of Gross Salary = Tax: {salary * 0.25}"); // 25% of Gross Salary
        Console.WriteLine($"20% of Gross Salary = PF: {salary * 0.20}"); // 20% of Gross Salary
        Console.WriteLine("------------------------------------------------------------------------");
        SalaryCalculator notify = new SalaryCalculator();
        notify.Notify();
        return salary - salary * 0.25 - salary * 0.20;
    }

}

class Program
{
    //static void Main(string[] args)
    //{
    //    try
    //    {
    //        Console.WriteLine($"Choose an employee type");
    //        Console.WriteLine($"1. Manager");
    //        Console.WriteLine($"2. Developer");
    //        Console.WriteLine($"3. Accountant");
    //        int choice = ValidateChoice("Enter your choice: ");
    //        Employee employee = CreateEmployee(choice);
    //        DisplayEmployeeDetails(employee);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"An exception error occurred: {ex.Message}");
    //    }
    //}

    public static Employee CreateEmployee(int choice)
    {
        
        Employee employee;
        switch (choice)
        {
            case 1:
                employee = new Manager();
                break;
            case 2:
                employee = new Developer();
                break;
            case 3:
                employee = new Accountant();
                break;
            default:
                throw new Exception("Invalid choice");
        }
        Console.Write("Enter Employee ID: ");
        employee.Id = int.Parse(Console.ReadLine());
        Console.Write("Enter Employee Name: ");
        employee.Name = Console.ReadLine();
        Console.Write("Enter Basic Salary: ");
        employee.BasicSalary = double.Parse(Console.ReadLine());
        return employee;
    }
    public static int ValidateChoice(string mssg )
    {
        Console.Write(mssg);
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            Console.Write("Invalid input. Please enter a valid Input : ");

        }
    }
    public static void DisplayEmployeeDetails(Employee employee)
    {
        Console.WriteLine($"----------------- Employee Details -------------------");
        Console.WriteLine($"Employee ID: {employee.Id}");
        Console.WriteLine($"Employee Name: {employee.Name}");
        Console.WriteLine($"Basic Salary: {employee.BasicSalary}");
        Console.WriteLine("");
        Console.WriteLine($"Total NetSalary: {employee.CalculateSalary()}");
        
    }
}

