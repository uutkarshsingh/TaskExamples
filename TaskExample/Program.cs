using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();

            try
            {
                var t1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 1200,source.Token)).ContinueWith((prevTask) =>MoreImportantWork(1, 3000,source.Token));

                Thread.Sleep(1500);
                
                source.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
            }
            
            Console.WriteLine("WRITING THE END OF THE PROGRAM");

            Console.ReadKey();
        }
         
        static void DoSomeVeryImportantWork(int id, int sleeptime,CancellationToken token)
        {
            Console.WriteLine("Task {0} PRIMARY beginning ",id);
            Thread.Sleep(sleeptime);
            for (int count = 0; count < 50;count++ )
            {
                Console.WriteLine("PRIMARY WORK LOOP {0}",id);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation requested");

                    token.ThrowIfCancellationRequested();
                }

            }
            Console.WriteLine("Task {0} PRIMARY completed", id);
        }

        static void MoreImportantWork(int id , int sleepTime,CancellationToken token)
        {
            try
            {
                Console.WriteLine(" {0}  SECONDARY WORK STARTED ", id);
                Thread.Sleep(sleepTime);
                for (int count = 0; count < 50; count++)
                {
                    Console.WriteLine("secondary work loop {0}", id);

                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Cancellation requested");

                        token.ThrowIfCancellationRequested();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("EXception thrown by the application");
            }
            Console.WriteLine("Task {0} SECONDARY completed",id);
        }
    }
}
