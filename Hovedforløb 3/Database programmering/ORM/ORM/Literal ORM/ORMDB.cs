using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM.Literal_ORM
{
    public static class ORMDB
    {
        private static void Connect(string statement, Action<SqlCommand> callback)
        {
            string connectionString = 
                "Data Source=DANIEL-SIMONSEN\\MASTERRUNEUWU;" + 
                "Initial Catalog=H3DBProgORM;" + 
                "Trusted_Connection=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            callback(new SqlCommand(statement, conn));
            conn.Close();
        }

        public static int Execute(string statement)
        {
            int result = -1;
            Connect(statement, cmd => { result = cmd.ExecuteNonQuery(); });
            return result;
        }
        public static List<object> Query(string statement)
        {
            List<object> result = new List<object>();
            Connect(statement, cmd =>
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        if (reader[i] != null)
                        {
                            result.Add(reader[i]);
                            i++;
                        }
                    }
                }
            });

            return result;
        }
    }
}
