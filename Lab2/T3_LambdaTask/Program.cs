using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Завдання 3: Створення задачі через лямбда-вираз\n");

        // Одразу створюємо й запускаємо задачу
        Task task = Task.Run(() =>
        {
            Console.WriteLine($"Task почалась. ID = {Task.CurrentId}");
            Thread.Sleep(700);
            Console.WriteLine($"Task завершилась. ID = {Task.CurrentId}");
        });

        // Чекаємо завершення задачі
        task.Wait();

        Console.WriteLine("Main() завершився після task.Wait().");
        Console.ReadLine();
    }
}
