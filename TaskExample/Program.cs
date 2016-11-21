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
            var t1 =  Task.Factory.StartNew(() => DoSomeVeryImportantWork(1,1500));

            var t2 =  Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));

            var t3 =  Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));

            Console.ReadKey();
        }
         
        static void DoSomeVeryImportantWork(int id, int sleeptime)
        {
            Console.WriteLine("Task {0} is beginning ",id);
            for (int count = 0; count < 100;count++ )
            {
                Console.WriteLine("From the function {0}",id);
            }
            Console.WriteLine("Task {0} has completed", id);
        }
    }
}
