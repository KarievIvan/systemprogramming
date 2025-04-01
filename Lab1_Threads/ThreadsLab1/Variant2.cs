using System;
using System.Threading;

class MyThread
{
    public long Count;
    public Thread Thrd;

    private static bool stop = false;
    private static object lockObj = new object();

    public MyThread(string name)
    {
        Count = 0;
        Thrd = new Thread(Run);
        Thrd.Name = name;
    }

    void Run()
    {
        while (!stop)
        {
            Count++;
        }

        lock (lockObj)
        {
            Console.WriteLine($"{Thrd.Name} завершився з Count = {Count}");
        }
    }

    public static void StopAll()
    {
        stop = true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Main thread is beginning.\n");

        MyThread mt1 = new MyThread("Потік 1 (Highest)");
        MyThread mt2 = new MyThread("Потік 2 (Lowest)");
        MyThread mt3 = new MyThread("Потік 3 (AboveNormal)");
        MyThread mt4 = new MyThread("Потік 4 (Normal)");
        MyThread mt5 = new MyThread("Потік 5 (BelowNormal)");

        mt1.Thrd.Priority = ThreadPriority.Highest;
        mt2.Thrd.Priority = ThreadPriority.Lowest;
        mt3.Thrd.Priority = ThreadPriority.AboveNormal;
        mt4.Thrd.Priority = ThreadPriority.Normal;
        mt5.Thrd.Priority = ThreadPriority.BelowNormal;

        mt1.Thrd.Start();
        mt2.Thrd.Start();
        mt3.Thrd.Start();
        mt4.Thrd.Start();
        mt5.Thrd.Start();

        Thread.Sleep(5000);
        MyThread.StopAll();

        mt1.Thrd.Join();
        mt2.Thrd.Join();
        mt3.Thrd.Join();
        mt4.Thrd.Join();
        mt5.Thrd.Join();

        long total = mt1.Count + mt2.Count + mt3.Count + mt4.Count + mt5.Count;

        Console.WriteLine("\nРозподіл процесорного часу:");

        Console.WriteLine($"{mt1.Thrd.Name}: {100.0 * mt1.Count / total:F2}%");
        Console.WriteLine($"{mt2.Thrd.Name}: {100.0 * mt2.Count / total:F2}%");
        Console.WriteLine($"{mt3.Thrd.Name}: {100.0 * mt3.Count / total:F2}%");
        Console.WriteLine($"{mt4.Thrd.Name}: {100.0 * mt4.Count / total:F2}%");
        Console.WriteLine($"{mt5.Thrd.Name}: {100.0 * mt5.Count / total:F2}%");

        Console.WriteLine("\nMain thread is completed.");
        Console.ReadLine();
    }
}
