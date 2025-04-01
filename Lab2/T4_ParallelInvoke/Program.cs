using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Завдання 4: Використання Parallel.Invoke()\n");

        Parallel.Invoke(
            () =>
            {
                Console.WriteLine("Задача 1 почалась");
                Thread.Sleep(700);
                Console.WriteLine("Задача 1 завершилась");
            },
            () =>
            {
                Console.WriteLine("Задача 2 почалась");
                Thread.Sleep(500);
                Console.WriteLine("Задача 2 завершилась");
            }
        );

        Console.WriteLine("Main() завершився після Parallel.Invoke().");
        Console.ReadLine();
    }
}
