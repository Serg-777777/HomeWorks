using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Configuration;
using System.Text;
using System.Dynamic;

//управление подключением к БД
namespace myNpgTestNamespace
{
	using writeLOG = Console;
	[Flags]
    public enum enumTypeString { cloud, local }
    internal class ConnectNpgAdapter
    {
        public enum enumCommandType { NonQuery, Scalar, Reader }
        ATablesBase<string, string> _tableCurrent = null!;
        string _connectString = null!;

        public ConnectNpgAdapter(enumTypeString baseeLocation)
        {
            _connectString = SQLString.SQLConnectString(baseeLocation);
        }

		public bool _excuteConnect(string stringSQL, enumCommandType commandType) //подключение и выполнение комманд 
		{
			using NpgsqlConnection connection = new NpgsqlConnection(_connectString);
			using NpgsqlCommand command = new NpgsqlCommand(stringSQL, connection);
			try
			{
				connection.Open();
				switch (commandType)
				{
					case enumCommandType.NonQuery:
						{
							command.ExecuteNonQuery(); 
							break;
						}
					case enumCommandType.Scalar:
						{
							var val = command.ExecuteScalar();
							writeLOG.WriteLine($"{val?.ToString()}");
							break;
						}
					case enumCommandType.Reader:
						{
							var read = command.ExecuteReader();
							while (read.Read())
							{
								for (int i = 0; i < read.FieldCount; i++)
									writeLOG.Write((!String.IsNullOrEmpty(read[i].ToString()) ? read[i]: "-") + " | ");
								writeLOG.WriteLine("\t");
							}
							break;
						}
				}
				return true;
			}
			catch (Exception exc)
			{
				writeLOG.WriteLine($"\n\n::MY ERROR CATCH::\n Source: {exc.Source} \n Message: {exc.Message}");
				return false;
			}
			finally
			{
				connection.Close();
				connection.Dispose();
				command.Dispose();
			}
		}
		public ATablesBase<string, string> TableChangeCurrent(ATablesBase<string, string> table)
		{
			_tableCurrent = table;
			return _tableCurrent;

		}

		//строки
		public void RowsUpdate(ATablesBase<string, string> table, string sqlFieldsValuesOnly, string whereString)
        {
            _tableCurrent = table;
            if (_tableCurrent.TableIsCreated)
            {
                _excuteConnect(SQLString.SqlRowUpdate(_tableCurrent, sqlFieldsValuesOnly, whereString), enumCommandType.NonQuery);
            }

			//writeLOG.WriteLine($"========:: update in {_tableCurrent.TableName} ::=======");
		}
        public void RowsDelete(ATablesBase<string, string> table, string whereString)
        {
            _tableCurrent = table;
            if (_tableCurrent.TableIsCreated)
            {
                _excuteConnect(SQLString.SqlRowsDelete(_tableCurrent, whereString), enumCommandType.NonQuery);
            }

			//writeLOG.WriteLine($"========:: delete from {_tableCurrent.TableName} ::=======");
		}
        public void RowsSelect(ATablesBase<string, string> table, string sqlFields, string whereString = "", string orderString = "")
        {
            _tableCurrent = table;
            if (_tableCurrent.TableIsCreated)
            {
                _excuteConnect(SQLString.SqlRowSelect(_tableCurrent, sqlFields, whereString, orderString), enumCommandType.Reader);
            }
		}
		public void RowsSelectJoin(ATablesBase<string, string> tableInner, ATablesBase<string, string> tableOuter, string strFieldsOnly, string strOnOnly, string strWhereOnly="")
		{
			_tableCurrent = tableInner;
			if (_tableCurrent.TableIsCreated)
			{
				_excuteConnect(SQLString.SqlRowSelectJoin(tableInner, tableOuter, strFieldsOnly, strOnOnly, strWhereOnly), enumCommandType.Reader);
			}
		}
		public void RowInsert(ATablesBase<string, string> table, string fieldsNames, string values)
        {
            _tableCurrent = table;
            if (_tableCurrent.TableIsCreated)
            {
                _excuteConnect(SQLString.SqlRowInsert(_tableCurrent, fieldsNames, values), enumCommandType.NonQuery);
                _tableCurrent.TableIsCreated = true;
                return;

            }
		//	writeLOG.WriteLine($"========:: insert in {_tableCurrent.TableName} ::=======");
		}
      
        //таблицы
        public void TableCtreate(ATablesBase<string, string> table)
        {
            _tableCurrent = table;
            if (!_tableCurrent.TableIsCreated)
            {
                _excuteConnect(SQLString.SqlCreateTableString(_tableCurrent), enumCommandType.NonQuery);
                _tableCurrent.TableIsCreated = true; ;
                writeLOG.WriteLine($":: Created {_tableCurrent.TableName}  ::");
                return;

            }
       //     writeLOG.WriteLine($"NOT:: created {_tableCurrent.TableName} is exist ::\n");
        }
        public void TableDelete(ATablesBase<string, string> table)
        {
            _tableCurrent = table;
            if (_tableCurrent.TableIsCreated)
            {
                _excuteConnect(SQLString.SqlDeleteTableString(_tableCurrent.TableName), enumCommandType.NonQuery);
                _tableCurrent.TableIsCreated = false;
				writeLOG.WriteLine($":: Deleted {_tableCurrent.TableName}  ::");
				return;
            }
		//	writeLOG.WriteLine($"NOT:: deleted {_tableCurrent.TableName} is not exist ::\n");
		}

		public bool WriteVersion()
		{
			writeLOG.Write("Version: ");
			return _excuteConnect(SQLString.SqlGetVersion(), enumCommandType.Scalar);
		}
	}

    

}
