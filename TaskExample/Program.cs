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
            var t1 = new Task(() => DoSomeVeryImportantWork(1,1500));

            t1.Start();

            for (int count = 0; count < 100; count++)
            {
                Console.WriteLine("Printing more values  from" + count);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void DoSomeVeryImportantWork(int id, int sleeptime)
        {
            Console.WriteLine("Task {0} is beginning ",id);
            for (int count = 0; count < 100;count++ )
            {
                Console.WriteLine("From the function {0}",count);
            }
            Console.WriteLine("Task {0} has completed", id);
        }
    }
}
