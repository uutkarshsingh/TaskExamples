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
            var t1 =  Task.Factory.StartNew(() => DoSomeVeryImportantWork(1,1500)).ContinueWith((prevTack)=>MoreImportantWork(1,1500));

            var t2 =  Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000)).ContinueWith((prevTack)=>MoreImportantWork(2,3000));

            var t3 =  Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000)).ContinueWith((prevTack)=>MoreImportantWork(3,1000));

            var taskList = new List<Task>() {t1,t2,t3};

            Task.WaitAll(taskList.ToArray());

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
