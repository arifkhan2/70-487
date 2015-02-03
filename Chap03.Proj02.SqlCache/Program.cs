using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chap03.Proj02.SqlCache
{
    class Program
    {
        static void Main(string[] args)
        {
            var cacher = new Cacher();

            cacher.Start();

            Console.WriteLine("Watching for changes...");

            while (true)
            {
                if (cacher.HasData)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Cache EMPTY!");
                    Console.ReadLine();
                    cacher.Start();
                }
            }
        }
    }
}
