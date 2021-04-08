using System;
using System.Collections.Generic;
using System.Text;
using static ORM.Literal_ORM.Types;

namespace ORM.Literal_ORM
{
    public abstract partial class MyORM
    {
        private static readonly Dictionary<string, Dictionary<string, Field>> tables = new Dictionary<string, Dictionary<string, Field>>();
        private static Dictionary<string, Field> TableCheck(string tableName)
        {
            if (!tables.ContainsKey(tableName))
                tables[tableName] = new Dictionary<string, Field>();
            return tables[tableName];
        }

        private static readonly Dictionary<string, Field> primaryKeys = new Dictionary<string, Field>();

        protected static void Float(string tableName, string propertyName, Func<MyORM, float> getter, Action<MyORM, float> setter) => TableCheck(tableName)[propertyName] = new Float(getter, setter);
        protected static void Int(string tableName, string propertyName, Func<MyORM, int> getter, Action<MyORM, int> setter) => TableCheck(tableName)[propertyName] = new Int(getter, setter);
        protected static void Text(string tableName, string propertyName, Func<MyORM, string> getter, Action<MyORM, string> setter) => TableCheck(tableName)[propertyName] = new Text(getter, setter);

        protected static void PrimaryKey(string tableName, string propertyName) => primaryKeys[tableName] = TableCheck(tableName)[propertyName];
    }
}
