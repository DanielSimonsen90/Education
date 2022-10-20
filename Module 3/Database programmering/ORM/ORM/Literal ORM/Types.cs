using System;

namespace ORM.Literal_ORM
{
    public class Types
    {
        public abstract class Field
        {
            public Field(Func<MyORM, string> getSQL) => GetSQL = getSQL;

            protected Func<MyORM, string> GetSQL { get; }
            public abstract string GetSQLValue(MyORM orm);
            public abstract void SetValue(MyORM orm, string value);
            public abstract string SQLType { get; }
        }

        public class Float : Field
        {
            public Float(Func<MyORM, float> getter, Action<MyORM, float> setter) : base(Convert(getter)) => Setter = setter;

            public override string GetSQLValue(MyORM orm) => GetSQL(orm);
            protected Action<MyORM, float> Setter { get; }
            public override void SetValue(MyORM orm, string value) => _SetValue(orm, float.Parse(value));

            private static Func<MyORM, string> Convert(Func<MyORM, float> getter) => orm => getter(orm).ToString();
            private void _SetValue(MyORM orm, float value) => Setter(orm, value);

            public override string SQLType => "FLOAT";
        }
        public class Int : Field
        {
            public Int(Func<MyORM, int> getter, Action<MyORM, int> setter) : base(Convert(getter)) => Setter = setter;

            public override string GetSQLValue(MyORM orm) => GetSQL(orm);
            protected Action<MyORM, int> Setter { get; }
            public override void SetValue(MyORM orm, string value) => _SetValue(orm, int.Parse(value));

            private static Func<MyORM, string> Convert(Func<MyORM, int> getter) => orm => getter(orm).ToString();
            private void _SetValue(MyORM orm, int value) => Setter(orm, value);

            public override string SQLType => "INT";
        }

        public class Text : Field
        {
            public Text(Func<MyORM, string> getter, Action<MyORM, string> setter) : base(getter) => Setter = setter;

            public override string GetSQLValue(MyORM orm) => $"'{GetSQL(orm)}'";
            public override void SetValue(MyORM orm, string value) => Setter(orm, value);
            protected Action<MyORM, string> Setter { get; }
            public override string SQLType => "TEXT";
        }
    }
}
