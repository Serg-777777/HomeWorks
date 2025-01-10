
using System.Collections;

namespace myNpgTestNamespace
{
    //обязательные поля
    interface IFieldsTable
    {
		int id_inx_items { get; } // не создаётся автоматов в базе
		string fld_Id { get; } 
		string fld_RegistrationDate { get; } // заполняется раз при инициализации
        string SQLAdditionalСonditions { get; } //для SQL при создании таблицы
	}

    //базовая реализация таблицы и её полей
    abstract class ATablesBase<X, Y> where X : class where Y : class, IEnumerable
    {
		virtual protected Dictionary<X, Y>? _fieldsForSql { set; get; }
		public bool TableIsCreated { set; get; }
        public readonly string TableName = null!;

		public ATablesBase(string tableName)
        {
            _fieldsForSql = new();
			TableName = tableName;
            TableIsCreated = false;
		}
		public virtual Dictionary<X, Y> FieldsRepository => _fieldsForSql!; //для конконации в SQL при создании таблицы
		public abstract string SQLAdditionalСonditions {get; } //для SQL при создании таблицы
		abstract public void FieldsInitialize(); //для конконации в SQL при создании таблицы

		public virtual string GetFildsInStringForSQL()
        {
            string str = "";

            foreach(var v in _fieldsForSql!)
            {
                str = string.Concat(str, v.Key,", ");
            }
            
            return str.Substring(0, str.Length - 2); ;

        }

		public IEnumerator GetEnumerator()
		{
			return _fieldsForSql?.GetEnumerator()!;
		}

	}
}
