using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;

//Chapter 02: Querying and manipulating data by using the Entity Framework
//Objective 2.2: Query and manipulate data by using Entity Data Provider
//Topic: EntityConnection
//Additional Resources: Use the SQL Script attached with this project.
//After creating entity model, make sure to ProviderManifestToken="2008" in the edmx xml file

namespace Chap02.EntityFramework.Obj2_2.DataProvider.EntityConnection1
{
    class Program
    {
        static void Main(string[] args)
        {
       
            // Create an EntityConnection.
            EntityConnection conn =
                new EntityConnection("name=TestModelEntities");

            // Create a long-running context with the connection.
            TestModelEntities context = new TestModelEntities();
                

            try
            {
                // Explicitly open the connection.
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                var transactions = from t in context.Transactions
                                   select t;

                var transaction = context.Transactions
                                    .Where(t => t.TransactionId == 1)
                                    .FirstOrDefault();

       
                // Change the transaction date
                transaction.TransactionDate = System.DateTime.Now;

                // Delete the transaction detail
                context.TransactionDetails.Remove(transaction.TransactionDetails.First());


                // Save changes.
                if (0 < context.SaveChanges())
                {
                    Console.WriteLine("Changes saved.");
                }

                // Create a new TransactionDetail object.
                TransactionDetail detail = new TransactionDetail
                {
                    Detailid = 1,
                    TransactionId = 1,
                    Vendor = "Arif",
                    ItemDescription = "Arif Description"
                };

                transaction.TransactionDetails.Add(detail);
                
                // Save changes again.
                if (0 < context.SaveChanges())
                {
                    Console.WriteLine("Changes saved.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Explicitly dispose of the context and the connection. 
                context.Dispose();
                conn.Dispose();
            }

        }
    }
}
