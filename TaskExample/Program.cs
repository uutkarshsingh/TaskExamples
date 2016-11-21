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
            var intList = new List<int>() { 1, 2, 323, 3, 4, 54, 1, 55, 7767, 345 };

            //Blocking function that is mentioned below . You won't be able to go to the last comment before below class.
            Parallel.For(0, 100, (i) => Console.WriteLine(i));

            Console.WriteLine("WRITING THE END OF THE PROGRAM");
            Console.ReadKey();
        }
         
        static void DoSomeVeryImportantWork(int id, int sleeptime)
        {
            Console.WriteLine("Task {0} PRIMARY beginning ",id);
            Thread.Sleep(sleeptime);
            for (int count = 0; count < 50;count++ )
            {
                Console.WriteLine("PRIMARY WORK LOOP {0}",id);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("Task {0} PRIMARY completed", id);
        }

        static void MoreImportantWork(int id , int sleepTime)
        {
            Console.WriteLine(" {0}  SECONDARY WORK STARTED ",id);
            Thread.Sleep(sleepTime);
            for(int count=0 ;  count <50 ; count++)
            {
                Console.WriteLine("secondary work loop {0}", id);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            }           
            Console.WriteLine("Task {0} SECONDARY completed",id);
        }
    }
}
