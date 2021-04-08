using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using static ORM.Literal_ORM.Types;

namespace ORM.Literal_ORM
{
    public abstract partial class MyORM : ICRUD
    {
        public Dictionary<string, Field> this[string tableName] => TableCheck(tableName);

        public int ID { get; set; } = 0;
        public abstract string TableName { get; }

        public ICRUD CreateTable()
        {
            //Table exists
            try
            {
                if (ORMDB.Query($"SELECT * FROM {TableName}")[0] == null) throw new Exception("No table found");
                return this;
            }
            catch (Exception) { }

            Field primaryKey = primaryKeys[TableName];
            string pkName = string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this[TableName])
            {
                if (kvp.Value.Equals(primaryKey)) pkName = kvp.Key;
                sb.Append($", {kvp.Key} {kvp.Value.SQLType} {(kvp.Value.Equals(primaryKey) ? "IDENTITY(1, 1)" : "")}");
            }

            string columns = sb.ToString().Substring(2);

            ORMDB.Execute($"CREATE TABLE {TableName} ({columns}, PRIMARY KEY ({pkName}))");
            return this;
        }
        public ICRUD Insert()
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

            ORMDB.Execute($"INSERT INTO {TableName} ({fields.ToString().Substring(2)}) VALUES ({values.ToString().Substring(2)})");
            return this;
        }
        public ICRUD Select(int primaryKey)
        {
            List<object> result = ORMDB.Query($"SELECT * FROM {TableName} WHERE {GetPrimaryKey().Key} = {primaryKey}");
            MyORM lookingFor = result.Find(i => (i as MyORM).ID == primaryKey) as MyORM;

            var keys = this[TableName];
            foreach (var kvp in keys)
                this[TableName][kvp.Key].SetValue(this, this[TableName][kvp.Key].GetSQLValue(lookingFor));
            return this;
        }
        public ICRUD Update()
        {
            Field primaryKey = primaryKeys[TableName];
            string pkName = string.Empty;
            string pkValue = primaryKey.GetSQLValue(this);

            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this[TableName])
                if (kvp.Value.Equals(primaryKey)) pkName = kvp.Key;
                else sb.Append($", {kvp.Key} = {kvp.Value.GetSQLValue(this)}");

            ORMDB.Execute($"UPDATE {TableName} SET {sb.ToString().Substring(2)} WHERE {pkName} = {pkValue}");
            return this;
        }
        public ICRUD Delete()
        {
            var kvp = GetPrimaryKey();
            ORMDB.Execute($"DELETE FROM {TableName} WHERE {kvp.Key} = {kvp.Value.GetSQLValue(this)}");
            return this;
        }

        private KeyValuePair<string, Field> GetPrimaryKey()
        {
            Field primaryKey = primaryKeys[TableName];

            foreach (var kvp in this[TableName])
                if (kvp.Value.Equals(primaryKey))
                    return kvp;
            return new KeyValuePair<string, Field>();
        }
    }
}