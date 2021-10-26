using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DanielsPasswords.Database
{
    public class SQLSaver : DatabaseSaver<Login>
    {
        public static readonly int MaxChars = 50;

        public string TableName { get; private set; }

        public string DataSource { get; private set; }
        public string InitialCatalog { get; private set; }
        public string TrustedConnection { get; private set; }
        protected string ConnectionString =>
            $"Data Source={DataSource};" +
            $"Initial Catalog={InitialCatalog};" +
            $"Trusted_Connection={TrustedConnection};";

        public SQLSaver(string dataSource, string initialCatalog, bool trustedConnection, string tableName)
        {
            DataSource = dataSource;
            InitialCatalog = initialCatalog;
            TableName = tableName;
            TrustedConnection = trustedConnection ? "true" : "false";

            Cache = FetchData();
        }

        private T Connect<T>(string statement, Func<SqlCommand, T> cb)
        {
            SqlConnection conn = new(ConnectionString);
            conn.Open();
            T result = cb(new SqlCommand(statement, conn));
            conn.Close();
            return result;
        }
        private async Task<T> ConnectAsync<T>(string statement, Func<SqlCommand, T> cb)
        {
            SqlConnection conn = new(ConnectionString);
            await conn.OpenAsync();
            T result = cb(new SqlCommand(statement, conn));
            await conn.CloseAsync();
            return result;
        }
        private List<Login> OnConnected(SqlCommand cmd)
        {
            List<Login> result = new();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0] != null)
                {
                    string username = reader[0] as string;
                    string password = reader[1] as string;

                    result.Add(new Login(username, password));
                }
            }
            return result;
        }

        protected List<Login> Query(string statement) => Connect(statement, OnConnected);
        protected async Task<List<Login>> QueryAsync(string statement) => await ConnectAsync(statement, OnConnected);

        public override List<Login> FetchData() => FetchData("1 = 1");
        public List<Login> FetchData(string filter = "")
        {
            try
            {
                return Cache = Query(
                    $"SELECT * FROM {TableName} WHERE {(filter == string.Empty ? "1 = 1" : filter)}"
                );
            }
            catch (Exception e)
            {
                if (e.Message == $"Invalid object name '{TableName}'.")
                {
                    Query($"CREATE TABLE {TableName} (" +
                        $"Username VARCHAR({MaxChars}) NOT NULL, " +
                        $"Password VARCHAR({MaxChars}) NOT NULL" +
                    ")");
                    return FetchData(filter);
                }

                Console.WriteLine(e);
                Console.ReadLine();
                return null;
            }
        }

        public override List<Login> AddData(Login login) => Cache = Query(
            $"INSERT INTO {TableName} VALUES('{login.Username}', '{login.Password}')"
        );
        public override List<Login> DeleteData(Login login) => Cache = Query(
            $"DELETE FROM {TableName} WHERE Username = {login.Username} AND Password = {login.Password}"
        );

        public override void Die() => Cache = Query(
            $"DROP TABLE {TableName}"
        );
    }
}
