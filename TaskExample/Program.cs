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
            var t1 = new Task(() => {
                Console.WriteLine("Task1 is beginning");
                for (int count = 0; count < 100; count++)
                {
                    Console.WriteLine("INSDE THREAD " + count);
                }

                    Console.WriteLine("task 1 has completed");
            });

            t1.Start();
            for (int count = 0; count < 100; count++)
            {
                Console.WriteLine("Printing morev values  from" + count);
               }

                Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
