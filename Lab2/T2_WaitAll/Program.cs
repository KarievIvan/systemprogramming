using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Завдання 2: Очікування завершення задач\n");

        Task task1 = new Task(() =>
        {
            Console.WriteLine($"Task 1 почалась. ID = {Task.CurrentId}");
            Thread.Sleep(500);
            Console.WriteLine($"Task 1 завершилась. ID = {Task.CurrentId}");
        });

        Task task2 = new Task(() =>
        {
            Console.WriteLine($"Task 2 почалась. ID = {Task.CurrentId}");
            Thread.Sleep(800);
            Console.WriteLine($"Task 2 завершилась. ID = {Task.CurrentId}");
        });

        task1.Start();
        task2.Start();

        // Очікуємо завершення обох задач
        Task.WaitAll(task1, task2);

        Console.WriteLine("Main() завершився після Task.WaitAll().");
        Console.ReadLine();
    }
}
