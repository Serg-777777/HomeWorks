
using System.Reflection;

namespace myNpgTestNamespace
{
    //реализация таблицы
    internal sealed class TableBase : ATablesBase<string, string>
    {

       public IFieldsTable _fields{ get; }

		public TableBase(string tableName, IFieldsTable fields) : base(tableName)
        {
            _fields = fields;
			FieldsInitialize();
        }

        //Инициализацие полей класса таблицы
        public sealed override void FieldsInitialize() //конконация в SQL при создании таблицы
		{
			base._fieldsForSql?.Clear();
            Type type = _fields.GetType();
            var fs = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
			//Console.WriteLine($"---------{TableName} Fields---------");
            foreach (var f in fs)
            {
				base._fieldsForSql?.Add(f.Name, (string)f?.GetValue(_fields)!);
              //  Console.WriteLine(f?.Name + " " + f?.GetValue(_fields));
            }
            //Console.WriteLine($"---------------------------------\n");
        }
        public override string SQLAdditionalСonditions => _fields?.SQLAdditionalСonditions!;
	}

}
