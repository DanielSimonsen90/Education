using DanhoLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ORM.Literal_ORM.Types;

namespace ORM.Literal_ORM
{
    public abstract class MyORM
    {
        public Dictionary<string, Field> this[string tableName] => TableCheck(tableName);

        private static readonly Dictionary<string, Dictionary<string, Field>> tables = new Dictionary<string, Dictionary<string, Field>>();
        private static Dictionary<string, Field> TableCheck(string tableName)
        {
            if (!tables.ContainsKey(tableName))
                tables[tableName] = new Dictionary<string, Field>();
            return tables[tableName];
        }

        private static readonly Dictionary<string, Field> primaryKeys = new Dictionary<string, Field>();

        protected static void Number(string tableName, string propertyName, Func<MyORM, float> getter) => TableCheck(tableName)[propertyName] = new Number(getter);
        protected static void Text(string tableName, string propertyName, Func<MyORM, string> getter) => TableCheck(tableName)[propertyName] = new Text(getter);
        protected static void PrimaryKey(string tableName, string propertyName) => primaryKeys[tableName] = TableCheck(tableName)[propertyName];

        public int ID { get; set; } = 0;
        public abstract string TableName { get; }

        public void Insert()
        {
            StringBuilder fields = new StringBuilder(),
                values = new StringBuilder();
            Field pk = primaryKeys[TableName];

            foreach (var kvp in this[TableName])
            {
                if (kvp.Value.Equals(pk)) continue;

                fields.Append($", {kvp.Key}");
                values.Append($", {kvp.Value.GetSQLValue(this)}");
            }


            string sql = $@"INSERT INTO {TableName} ({fields.ToString().Substring(2)}) VALUES ({values.ToString().Substring(2)})";
            Console.WriteLine(sql);
        }
        public void Set()
        {
            throw new NotImplementedException();
        }
        public void Update()
        {
            Field primaryKey = primaryKeys[TableName];
            string pkName = string.Empty;
            string pkValue = primaryKey.GetSQLValue(this);

            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this[TableName])
            {
                if (kvp.Value.Equals(primaryKey))
                {
                    pkName = kvp.Key;
                    continue;
                }

                sb.Append($", {kvp.Key} = {kvp.Value.GetSQLValue(this)}");
            }

            string sql = $@"UPDATE {TableName} SET {sb.ToString().Substring(2)} WHERE {pkName} = {pkValue}";
            Console.WriteLine(sql);
        }
        public void Delete()
        {
            Field pk = primaryKeys[TableName];

            string pkName = string.Empty;
            foreach (var kvp in this[TableName])
            {
                if (!kvp.Value.Equals(pk)) continue;
                pkName = kvp.Key;
                break;
            }

            string sql = $"DELETE FROM {TableName} WHERE {pkName} = {pk.GetSQLValue(this)}";
            Console.WriteLine(sql);
        }
    }
}