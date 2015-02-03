using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace Chap03.Proj02.SqlCache
{
    public class Cacher
    {
        private MemoryCache cache = new MemoryCache("test");

        public Boolean HasData
        {
            get { return cache.Contains("data"); }
        }

        public void Start()
        {
            var connectionString = @"Data Source=.;Initial Catalog=CachingTest;Integrated Security=True";
            var list = new NameValueCollection();
            var policy = new CacheItemPolicy();

            SqlDependency.Start(connectionString);

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("SELECT Name, Value FROM dbo.Table_1", connection))
                {
                    var dependency = new SqlDependency(command);

                    connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(reader["Name"].ToString(), reader["Value"].ToString());
                    }

                    var monitor = new SqlChangeMonitor(dependency);

                    policy.ChangeMonitors.Add(monitor);
                }

                cache.Add("data", list, policy);
            }
        }
    }
}
