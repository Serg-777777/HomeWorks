using System.Configuration;

namespace myNpgTestNamespace
{
	//формирование текстовых комманд SQL 
	using writeLOG = Console;
	static class SQLString
	{
		const string base_cloude_name = "base_neon";
		//строка подключения
		public static string SQLConnectString(enumTypeString typeString)
		{
			string str = null!;
			switch (typeString)
			{
				case enumTypeString.cloud:
					{
						str = ConfigurationManager.ConnectionStrings[base_cloude_name].ConnectionString;
						break;
					}

				case enumTypeString.local:
					{
						throw new Exception("in process!");
						//break;
					}
			}
			return str;

		}
		public static string SqlGetVersion() => "SELECT version()";
		public static string SqlGetTablesCount() => "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE table_schema = 'testDB';";

		//таблицы
		public static string SqlCreateTableString(ATablesBase<string, string> table)
		{
			string sql = "";
			string condit = table.SQLAdditionalСonditions;

			foreach (var v in table.FieldsRepository)
			{
				sql = $"{sql} {v.Key} {v.Value},\n ";

			}
			if (sql.Length > 3)
			{
				sql = sql.Substring(0, sql.Length - 3);
				condit = condit != "" ? ($",\n  {condit}") : "";
				sql = $"CREATE TABLE {table.TableName} ({sql}{condit});";
			}
			writeLOG.WriteLine($"\n-{sql}\n- wait excute...\n");

			return sql;
		}
		public static string SqlDeleteTableString(string tableName)
		{
			string sql = $"DROP TABLE {tableName};";
			writeLOG.WriteLine($"\n- \n{sql}\n- wait excute...\n");
			return sql;
		}

		//строки
		public static string SqlRowsDelete(ATablesBase<string, string> table, string sqlFieldsValuesOnly)
		{
			string sql = $"DELETE FROM {table.TableName} WHERE {sqlFieldsValuesOnly};";
			writeLOG.WriteLine($"\n- \n{sql}\n- wait excute...\n");
			return sql;
		}
		public static string SqlRowInsert(ATablesBase<string, string> table, string namesFieldsSq, string values)
		{
			string sql = $"INSERT INTO {table.TableName} ({namesFieldsSq}) VALUES ({values});";
			writeLOG.WriteLine($"\n- \n{sql}\n- wait excute...\n");
			return sql;
		}
		public static string SqlRowSelect(ATablesBase<string, string> table, string sqlFields, string whereString = "", string orderString = "")
		{
			string sql = "";
			if (whereString != "") whereString = $"\nWHERE {whereString}";
			if (orderString != "") orderString = $"\nORDER BY {orderString}";

			sql = $"SELECT {sqlFields} FROM {table.TableName} {whereString} {orderString};";
			writeLOG.WriteLine($"\n- \n{sql}\n- wait excute...\n");
			writeLOG.WriteLine(sqlFields.Replace(", ", " | ") + " | ");
			//writeLOG.WriteLine("......................");
			return sql;
		}
		public static string SqlRowSelectJoin(ATablesBase<string, string> tableLeft, ATablesBase<string, string> tableRight, string strFieldsOnly, string strOnOnly, string strWhereOnly="", string orderString="")
		{
			string sql = "";
			strWhereOnly = strWhereOnly != "" ? $"\nWHERE {strWhereOnly}" : "";
			orderString = orderString != "" ? $"\nORDER BY {orderString}":"";

			sql = $"SELECT {strFieldsOnly} FROM {tableLeft.TableName} \nLEFT JOIN {tableRight.TableName} ON {strOnOnly} {strWhereOnly} {orderString};";
			writeLOG.WriteLine($"\n- \n{sql}\n- wait excute...\n");
			writeLOG.WriteLine(strFieldsOnly.Replace(", ", " | ") + " | ");
			//writeLOG.WriteLine("......................");
			return sql;
		}
		public static string SqlRowUpdate(ATablesBase<string, string> table, string sqlFieldsValuesOnly, string whereString)
		{
			string sql = "";
			sql = $"UPDATE {table.TableName} SET {sqlFieldsValuesOnly} WHERE {whereString};";
			writeLOG.WriteLine($"\n- \n{sql}\n- wait excute...\n");
			return sql;
		}
	}
}
