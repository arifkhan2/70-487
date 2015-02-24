using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Data.Entity;

//Chapter 02: Querying and manipulating data by using the Entity Framework
//Objective 2.2: Query and manipulate data by using Entity Data Provider
//Topic: Asynchronous Operation
//Additional Resources: Use the SQL Script attached with this project.
//Note, you will need .NET 4.5

namespace Chap02.EntityFramework.Obj2_2.DataProvider.AsyncOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = PerformDatabaseOperations();

            Console.WriteLine();
            Console.WriteLine("Quote of the day");
            Console.WriteLine(" Don't worry about the world coming to an end today... ");
            Console.WriteLine(" It's already tomorrow in Australia.");

            task.Wait();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public async static Task PerformDatabaseOperations()
        {
            using (var db = new TestModelEntities())
            {
                db.Transactions.Add(new Transaction
                {
                    TransactionId=4,
                    TransactionDate=System.DateTime.Now,
                    CustomerId = 1,
                    Amount=100
                });
                Console.WriteLine("Calling SaveChanges");

                await db.SaveChangesAsync();
                Console.WriteLine("SaveChanges completed.");

                var transactions = await (from b in db.Transactions
                                          orderby b.TransactionDate
                                          select b).ToListAsync();
                Console.WriteLine();
                Console.WriteLine("All blogs:");
                foreach(var transaction in transactions)
                {
                    Console.WriteLine(" " + transaction.TransactionDate);
                }

               
            }
        }
    }
}