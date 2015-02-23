using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using System.Data;
using System.Data.Metadata.Edm;

//Chapter 02: Querying and manipulating data by using the Entity Framework
//Objective 2.2: Query and manipulate data by using Entity Data Provider
//Topic: EntityCommand
//Additional Resources: Use the SQL Script attached with this project.
//After creating entity model, make sure to ProviderManifestToken="2008" in the edmx xml file

namespace Chap02.EntityFramework.Obj2_2.DataProvider.EntityDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EntityConnection conn = new EntityConnection("name=TestModelEntities"))
            {
                conn.Open();

                string esqlQuery =
                    @"Select VALUE transaction from TestModelEntities.Transactions As transaction
                    WHERE transaction.CustomerId = @CustomerId and transaction.TransactionId = @TransactionId"; 
                        

                using (EntityCommand cmd = new EntityCommand(esqlQuery, conn))
                {
                    EntityParameter param1 = new EntityParameter();
                    param1.ParameterName = "TransactionId";
                    param1.Value = 1;

                    EntityParameter param2 = new EntityParameter();
                    param2.ParameterName = "CustomerId";
                    param2.Value = 1;

                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);

                    using (DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr["CustomerId"]);
                            Console.WriteLine(rdr["TransactionDate"]);
                        }
                    }
                }
                Console.ReadLine();
            }
          
        }
    }
}
