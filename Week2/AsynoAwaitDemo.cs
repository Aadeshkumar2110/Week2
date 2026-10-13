namespace Week2
{
    public class AsynoAwaitDemo
    {
        public static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Console.ReadLine();
        }

        public static async void Task1()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Task 1 is running...");
                Thread.Sleep(3000);
                Console.WriteLine("Task 1 is completed.");
            });
        }
        public static async void Task2()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Task 2 is running...");
                Thread.Sleep(2000);
                Console.WriteLine("Task 2 is completed.");
            });
        }
        public static async void Task3()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Task 3 is running...");
                Thread.Sleep(5000);
                Console.WriteLine("Task 3 is completed.");
            });
        }
        public static async void Task4()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Task 4 is running...");
                Thread.Sleep(1000);
                Console.WriteLine("Task 4 is completed.");
            });
        }
    }
}