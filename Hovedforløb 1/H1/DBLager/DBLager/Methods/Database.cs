using System;
using System.Data.SqlClient;
using DanhoLibrary;

namespace DBLager.Methods
{
    class Database
    {
        public string TableName 
        { 
            get => _tableName; 
            set => _tableName = value; 
        }
        private static string _tableName;

        /// <summary>
        /// Communicates with database
        /// </summary>
        /// <param name="query">Query so DB understands wyd</param>
        public static void ExecuteQuery(string query)
        {
            using ( SqlConnection conn = new SqlConnection("Server=localhost;Database=EHandel;Trusted_Connection=true"))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine($"{reader[0]}: {reader[1]} ({reader[2]})");
            }
        }
        
        #region Create, Update, Delete, View
        public void Create() => 
            ExecuteQuery($"INSERT INTO {_tableName} VALUES ({GetPropertyValues()})");
        public void Update() =>
            ExecuteQuery($"UPDATE {_tableName} SET {GetSetCondition()} WHERE {GetWhereCondition()}");
        public void Delete() => 
            ExecuteQuery($"DELETE FRFOM {_tableName} WHERE {GetWhereCondition()}");
        public void ViewTable() =>
            ExecuteQuery($"SELECT * FROM {_tableName}");
        #endregion

        #region Helper Methods
        /// <summary>
        /// The new values for the table properties
        /// </summary>
        /// <returns></returns>
        private string GetPropertyValues()
        {
            Console.WriteLine($"What should the value for {GetTableProperties()} be?");
            switch (GetTableProperties())
            {
                case "Amount": return Console.ReadLine();
                case "Location": return $"'{Console.ReadLine()}'";
                case "Name": return $"'{Console.ReadLine()}'";
                default: return "invalid";
            }
        }
        /// <summary>
        /// Changes current property value to defined value
        /// </summary>
        /// <returns></returns>
        private static string GetSetCondition()
        {
            Console.Write($"What do you want to change {GetTableProperties()} into?: ");
            return $"{GetTableProperties()} = {Console.ReadLine()}";
        }
        /// <summary>
        /// Gets the property that's available for change, depending on <see cref="_tableName"/>
        /// </summary>
        /// <returns></returns>
        private static string GetTableProperties() =>
            (_tableName == "STOCKITEM") ? "Amount" : 
            (_tableName == "LOCATION") ? "Location" : "Name";
        /// <summary>
        /// Comparing prop1 to prop2
        /// </summary>
        /// <returns></returns>
        private string GetWhereCondition()
        {
            Console.WriteLine("Where ID = ?");
            var IDNum = $"AND ID = {Console.ReadLine()}";

            if (_tableName != "STOCKITEM")
                return $"ID = STOCKITEM.ID {IDNum}";

            Console.WriteLine("What would you like to compare?");
            ConsoleItems.ListOptions(new string[] { "Art_ID", "Loc_ID", "Amount" }, out int Conversion);

            if (Conversion != 3 && Conversion < 3)
                return (Conversion == 1) ? $"ID = Art_ID {IDNum}" : $"ID = Loc_ID {IDNum}";

            Console.Write("Amount = ");
            return $"Amount = {Console.ReadLine()}";
        }
        #endregion
    }
}