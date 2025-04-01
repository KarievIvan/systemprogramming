using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Завдання 1: Паралельне виконання задач\n");

        // Перша задача
        Task task1 = new Task(() =>
        {
            Console.WriteLine($"Task 1 почалась. ID = {Task.CurrentId}");
            Thread.Sleep(200 * (int)Task.CurrentId);
            Console.WriteLine($"Task 1 завершилась. ID = {Task.CurrentId}");
        });

        // Друга задача
        Task task2 = new Task(() =>
        {
            Console.WriteLine($"Task 2 почалась. ID = {Task.CurrentId}");
            Thread.Sleep(200 * (int)Task.CurrentId);
            Console.WriteLine($"Task 2 завершилась. ID = {Task.CurrentId}");
        });

        task1.Start();
        task2.Start();

        Console.WriteLine("Main() завершився.");
        Console.ReadLine();
    }
}
