using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;
using System.Configuration;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using System.Transactions;

namespace myNpgTestNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int i = 1000;
            ДЗ дз = new ДЗ();
			Console.WriteLine($"Для корректной работы запросов следует заполнять для 'Id' значение 0 где это необходимо.\n" +
				$"БД на neon.tech, cоединение было настроено, строка подключения в конфигураторе.");
			Console.WriteLine($"..................................\n");

			if (!дз.ПроверкаСоединения())
				Console.WriteLine("Отсутствует соединение с БД...");
				Thread.Sleep(i);
				дз.СоздатьТаблицы();
				Thread.Sleep(i);
				дз.ДобавитьПользователя();
				Thread.Sleep(i);
				дз.ДобавитьПродукт();
				Thread.Sleep(i);
				дз.ДобавитьЗаказ();
				Thread.Sleep(i);
				дз.ВыборДорогихТоваров();
				Thread.Sleep(i);
				дз.ВыборОстаткаТоваров();
				Thread.Sleep(i);
				дз.СуммаЗаказа();
				Thread.Sleep(i);
				дз.СуммаОстатка();
				Thread.Sleep(i);
				дз.ОбновитьПродукт();
				Thread.Sleep(i);
				дз.УдалитьТаблицы();
			
		}

        //выполнение ДЗ сценариев
        class ДЗ 
        {
			#region //vars
			ConnectNpgAdapter adapter = null!;
            Products products_fields = null!;
            TableBase products_table= null!;
			Users users_fields = null!;
			TableBase users_table = null!;
			Orders orders_fields = null!;
			TableBase orders_table = null!;
			OrderDetails orderDetails_fields = null!;
			TableBase orderDetails_table = null!;

			string users_table_name = "users";
			string orders_table_name = "orders";
			string products_table_name = "products";
			string orderDetails_table_name = "orderDetails";

			int _user_id_current = default;
			#endregion

			public ДЗ()
            {
                adapter = new(enumTypeString.cloud);
				users_fields = new Users();
				users_table = new TableBase(users_table_name, users_fields);
				orders_fields = new Orders();
				orders_table = new TableBase(orders_table_name, orders_fields);
				products_fields = new Products();
				products_table = new TableBase(products_table_name, products_fields);
				orderDetails_fields = new OrderDetails();
				orderDetails_table = new TableBase(orderDetails_table_name, orderDetails_fields);
			}

			public void УдалитьТаблицы()
			{
				Console.WriteLine($"\t11. Удалить таблицы");
				adapter.TableDelete(orderDetails_table);
				adapter.TableDelete(orders_table);
				adapter.TableDelete(users_table);
				adapter.TableDelete(products_table);
				Console.WriteLine("..................................");
			}
			public void ВыборТовара()
			{
				Console.WriteLine($"\t10. Проверка товара по Id");
				int i = _readLineId("Выбор Id:");
				adapter.RowsSelect(products_table, $"{products_fields.fld_Id}, {products_fields.fld_ProductName},  {products_fields.fld_Description}, {products_fields.fld_QuantityInStock}, {products_fields.fld_Price}",
					$"{products_fields.fld_Id} = {i}");
				Console.WriteLine("..................................");
			}
			public void ОбновитьПродукт()
			{
				Console.WriteLine("\n\t9. Обновить поля продукта\n");
				_updateValuesConsole(products_table);
				ВыборТовара();
				Console.WriteLine("..................................");
			}
			public bool ПроверкаСоединения()
			{
				return adapter.WriteVersion();
				Console.WriteLine("..................................");
			}

			public void ДобавитьЗаказ()
			{
				Console.WriteLine($"\n\t4. Создать заказ\n");
				adapter.RowInsert(orders_table, orders_table.GetFildsInStringForSQL(),_sqlValuesConsole(orders_table));
				Console.WriteLine($"+Детали заказа");
				adapter.RowInsert(orderDetails_table, orderDetails_table.GetFildsInStringForSQL(), _sqlValuesConsole(orderDetails_table));
				Console.WriteLine("..................................");
			}
			public void ВыборОстаткаТоваров()
			{
				Console.WriteLine($"\n\t6. Список товаров с низким запасом (менее 5 штук)");
				adapter.RowsSelect(products_table, $"{products_fields.fld_Id}, {products_fields.fld_ProductName}, {products_fields.fld_QuantityInStock}, {products_fields.fld_Price}",
					$"{products_fields.fld_QuantityInStock} < 5",
					$"{products_fields.fld_QuantityInStock} DESC");
				Console.WriteLine("..................................");
			}
			public void ВыборДорогихТоваров()
			{
				Console.WriteLine($"\n\t5. Получение 5 самых дорогих товаров.");
				adapter.RowsSelect(products_table, $"{products_fields.fld_Id}, {products_fields.fld_ProductName}, {products_fields.fld_QuantityInStock}, {products_fields.fld_Price}",
					"",
					$"{products_fields.fld_Price} DESC \nLIMIT 5");
				Console.WriteLine("..................................");
			}

			public void СуммаОстатка()
			{
				Console.WriteLine("\n\t8. Подсчет количества товаров на складе.\n");
				string sql = $"SELECT Sum({products_fields.fld_QuantityInStock}) AS ВсегоШт FROM {products_table.TableName};";
				Console.Write("Всего на складе шт.: ");
				adapter._excuteConnect(sql, ConnectNpgAdapter.enumCommandType.Scalar);
				Console.WriteLine($"\n..................................");
			}
			public void СуммаЗаказа()
			{
				Console.WriteLine("\n\t7. Расчет общей стоимости заказа.\n");
				int id_order = _readLineId("Id заказа:");
				string flds = $"{orders_table.TableName}.{orders_fields.fld_Id}, {orders_fields.fld_RegistrationDate}, {orders_fields.fld_Status}, " +
					$"{orderDetails_fields.fld_Quantity}, {orderDetails_fields.fld_PriceOrder}, " +
					$"{orderDetails_fields.fld_Quantity} * {orderDetails_fields.fld_PriceOrder} AS TotalAmount";
				adapter.RowsSelectJoin(orders_table,orderDetails_table, flds,
					$"{ orderDetails_table.TableName}.{ orderDetails_fields.fld_OrderID} = {orders_table.TableName}.{orders_fields.fld_Id}",
					$"{orders_table.TableName}.{orders_fields.fld_Id} = {id_order}");
				
				string sql = $"SELECT Sum({orderDetails_fields.fld_PriceOrder} * {orderDetails_fields.fld_Quantity}) as TotalAmount " +
					$"\nFROM {orderDetails_table_name} " +
					$"\nWHERE {orderDetails_fields.fld_OrderID} = {id_order} " +
					$"\nGROUP BY {orderDetails_fields.fld_OrderID};";



					Console.WriteLine($"\n-\n{sql}\n-");

					Console.Write($"\nСумма заказа: ");
					adapter._excuteConnect(sql, ConnectNpgAdapter.enumCommandType.Reader);
					Console.WriteLine("..................................");
			}
			public void ВыборПродуктовПользователя()
			{
				Console.WriteLine($"\t5. Выбор всех заказов определенного пользователя.");
				int i = _readLineId("Id пользователя:");
					adapter.RowsSelectJoin(users_table, orders_table,
						$"{users_table.TableName}.{users_fields.fld_Id}, {users_table.TableName}.{users_fields.fld_UserName}, " +
						$"{users_table.TableName}.{users_fields.fld_RegistrationDate}, {orders_table.TableName}.{orders_fields.fld_Status} ",
						$"{orders_table.TableName}.{orders_fields.fld_UserID} = {users_table.TableName}.{users_fields.fld_Id} ",
						$"{users_table.TableName}.{users_fields.fld_Id} = {i}");
				Console.WriteLine("..................................");
			}
			public void ДобавитьПродукт()
			{
				Console.WriteLine("\n\t3. Добавление нового продукта\n");
				string str = _sqlValuesConsole(products_table);
				adapter.RowInsert(products_table, products_table.GetFildsInStringForSQL(),str);
				Console.WriteLine("..................................");
			}
			public void ДобавитьПользователя()
			{
				Console.WriteLine("\n\t2. Создание пользователя\n");
				string str = _sqlValuesConsole(users_table,true);
				adapter.RowInsert(users_table, users_table.GetFildsInStringForSQL(), str);
				Console.WriteLine("..................................");
			}

			//Табоицы
			public void СоздатьТаблицы()
			{
				Console.WriteLine("\n\t1. Создание таблиц и связей:");
				_СоздатьТаблицуПользователи();
				_СоздатьТаблицуЗаказы();
				_СоздатьТаблицуПродукты();
				_СоздатьТаблицуДеталиЗаказа();
				Console.WriteLine("..................................");
				//adapter.WriteTablesCount();
			}
			private void _СоздатьТаблицуДеталиЗаказа()
			{
				adapter.TableCtreate(orderDetails_table);
			}
			private void _СоздатьТаблицуЗаказы()
			{
				adapter.TableCtreate(orders_table);
			}
			private void _СоздатьТаблицуПользователи()
			{
				adapter.TableCtreate(users_table);
			}
			private void _СоздатьТаблицуПродукты()
			{
				adapter.TableCtreate(products_table);

			}

			//реализации
			private int _readLineId(string msg)
			{

				string reply = "";
				int _id;
				repeat:
				Console.WriteLine($"{msg}");
				reply = Console.ReadLine()!;

				if(!int.TryParse(reply, out _id))
				{
					Console.WriteLine($"Не число!\n");
					goto repeat;
				}
				return _id;

			}
			private void _updateValuesConsole(TableBase table)
			{
				int i, _id;
				string? reply;
				string strFldValues = "";
				TableBase aTable = table;
				_id = _readLineId("Выбор Id:");
					foreach (var v in aTable.FieldsRepository)
					{
						if (v.Key != aTable._fields.fld_Id && v.Key != aTable._fields.fld_RegistrationDate)
						{
							Console.WriteLine($"{v.Key}:");
							reply = Console.ReadLine();
							if (reply?.Length > 1)
							{
							if (!int.TryParse(reply, out i))
								reply = $"'{reply}'";
							strFldValues  = $"{v.Key} = {reply}, {strFldValues}";
							}
						}
					}
					strFldValues = strFldValues.Substring(0, strFldValues.Length - 2);
					adapter.RowsUpdate(aTable, strFldValues, $"{aTable._fields.fld_Id} = {_id}");
			}
			string _sqlValuesConsole(TableBase aTables, bool usersTable = false)
			{
				string str_values = "";
				foreach (var val in aTables.FieldsRepository)
				{
					if (val.Key == aTables._fields.fld_Id)
					{
						if (usersTable)
						{
							_user_id_current = aTables._fields.id_inx_items;
							str_values = $"{_user_id_current}";
							Console.WriteLine($"{val.Key}: {_user_id_current}");
						}
						else
						{
							var i = aTables._fields.id_inx_items;
							str_values = $"{i}";
							Console.WriteLine($"{val.Key}: {i}");
						}

					}
					else if (val.Key == aTables._fields.fld_RegistrationDate)
					{
						str_values = $"{str_values}, '{DateTime.Now.ToString()}'";
						Console.WriteLine($"{val.Key}: {DateTime.Now.ToString()}");
					}
					else
					{
						int res = default!;

						Console.WriteLine($"{val.Key}:");
						var s = Console.ReadLine();

						if (int.TryParse(s, out res))
							str_values = $"{str_values}, {s}";
						else
							str_values = $"{str_values}, '{s}'";
					}
				}
				return str_values;
				
			}
		}

			

			

	}

	

    
}
