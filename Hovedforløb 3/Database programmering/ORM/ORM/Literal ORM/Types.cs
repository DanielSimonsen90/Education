using System;

namespace ORM.Literal_ORM
{
    public class Types
    {
        public abstract class Field
        {
            protected Func<MyORM, string> Getter { get; set; }

            public Field(Func<MyORM, string> getter) => Getter = getter;

            public abstract string GetSQLValue(MyORM orm); 
        }

        public class Number : Field
        {
            private static Func<MyORM, string> Convert(Func<MyORM, float> getter) => orm => getter(orm).ToString();
            public Number(Func<MyORM, float> getter) : base(Convert(getter)) { }
            public override string GetSQLValue(MyORM orm) => Getter(orm);
        }
        public class Text : Field
        {
            public Text(Func<MyORM, string> getter) : base(getter) { }
            public override string GetSQLValue(MyORM orm) => $"'{Getter(orm)}'";
        }
        public class Date : Field
        {
            public Date(Func<MyORM, string> getter) : base(getter) { }
            public override string GetSQLValue(MyORM orm) => /*Getter(orm);*/ throw new NotImplementedException();
        }
    }
}
