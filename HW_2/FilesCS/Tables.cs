using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myNpgTestNamespace
{
	class Products : IFieldsTable
	{
		/*
		* Таблица "Products" (Продукты):
		ProductID (Основной ключ)
		ProductName (Название продукта)
		Description (Описание)
		Price (Цена)
		QuantityInStock (Количество на складе)
		*/

		//определение полей и типов для sql
		static int inx = 0;
		public int id_inx_items => inx++;

		public static string ProductID = "INT NOT NULL PRIMARY KEY"; // Message: 42601: syntax error at or near "AUTO_INCREMENT"
		public static string ProductName = "VARCHAR(50) NOT NULL";
		public static string Description = "VARCHAR(100) NULL";
		public static string Price = "FLOAT NULL";
		public static string QuantityInStock = "INT NULL";
		public static string RegistrationDate = "VARCHAR(50) NOT NULL";
		public string SQLAdditionalСonditions => "UNIQUE(ProductID)";

		//константы полей в коде
		public string fld_Id => "ProductID";
		public string fld_RegistrationDate => "RegistrationDate";
		public string fld_ProductName => "ProductName";
		public string fld_Description => "Description";
		public string fld_Price => "Price";
		public string fld_QuantityInStock => "QuantityInStock";
		
	}
	class Users : IFieldsTable
	{
		/*
		Таблица "Users" (Пользователи):
		UserID (Основной ключ)
		UserName (Имя пользователя)
		Email (Электронная почта)
		RegistrationDate (Дата регистрации)
		 */

		//определение полей и типов для sql
		static int inx = 0;
		public int id_inx_items => inx++;

		public static string UserID = "INT NOT NULL PRIMARY KEY"; // Message: 42601: syntax error at or near "AUTO_INCREMENT"
		public static string UserName = "VARCHAR(50) NOT NULL";
		public static string Email = "VARCHAR(150) NULL";
		public static string RegistrationDate = "VARCHAR(50) NOT NULL"; //  Message: 42704: type "datetime" does not exist
		public string SQLAdditionalСonditions => "UNIQUE(UserID)";

		//константы полей в коде
		public string fld_Id => "UserID";
		public string fld_RegistrationDate => "RegistrationDate";
		public string fld_UserName => "UserName";
		public string fld_Email => "Email";
	}
	class Orders : IFieldsTable
	{
		/*
		Таблица "Orders" (Заказы):
		OrderID (Основной ключ)
		UserID (Внешний ключ)
		OrderDate (Дата заказа)
		Status (Статус) 
		 */

		static int inx = 0;
		public int id_inx_items => inx++;

		//определение полей и типов для sql
		public static string OrderID = "INT PRIMARY KEY"; // Message: 42601: syntax error at or near "AUTO_INCREMENT"
		public static string UserID = "INT  NOT NULL";
		public static string OrderDate = "VARCHAR(50) NOT NULL"; // Message: 42704: type "datetime" does not exist
		public static string Status = "VARCHAR(50)";
		public string SQLAdditionalСonditions => "UNIQUE(OrderID), FOREIGN KEY (UserID) REFERENCES Users (UserID) ON DELETE CASCADE";

		//константы полей в коде
		public string fld_Id => "OrderID";
		public string fld_RegistrationDate => "OrderDate";
		public string fld_UserID => "UserID";
		public string fld_Status => "Status";
		
	}
	class OrderDetails : IFieldsTable
	{

		/*
		Таблица "OrderDetails" (Детали заказа):
		OrderDetailID (Основной ключ)
		OrderID (Внешний ключ)
		ProductID (Внешний ключ)
		Quantity (Количество)
		TotalCost (Общая стоимость)
		 */

		static int inx = 0;
		public int id_inx_items => inx++;

		//определение полей и типов для sql
		public static string OrderDetailID = "INT PRIMARY KEY"; // Message: 42601: syntax error at or near "AUTO_INCREMENT"
		public static string OrderID = "INT NOT NULL";
		public static string ProductID = "INT  NOT NULL";
		public static string Quantity = "INT";
		public static string PriceOrder = "FLOAT NULL";
		public static string TotalCost = "VARCHAR(10)";
		public static string RegistrationDate = "VARCHAR(50) NOT NULL";
		public string SQLAdditionalСonditions => "UNIQUE(OrderDetailID),\n  FOREIGN KEY (OrderID) REFERENCES Orders (OrderID) ON DELETE CASCADE,\n" +
			"  FOREIGN KEY (ProductID) REFERENCES Products (ProductID) ON DELETE CASCADE";

		//определение констант полей в коде
		public string fld_Id => "OrderDetailID";
		public string fld_RegistrationDate => "RegistrationDate";
		public string fld_OrderID => "OrderID";
		public string fld_ProductID => "ProductID";
		public string fld_Quantity => "Quantity";
		public string fld_PriceOrder => "PriceOrder";
		public string fld_TotalCost => "TotalCost";
		

	}

	
	/*
Критерии оценки:
Создание таблиц "Products" и "Users": 2 балла
Создание таблиц "Orders" и "OrderDetails": 2 балла
Установление связей между таблицами: 1 балл
Добавление нового продукта и обновление цены продукта: 1 балл
Выбор всех заказов определенного пользователя и расчет общей стоимости заказа: 1 балл
Подсчет товаров на складе и получение 5 самых дорогих товаров: 2 балла
Список товаров с низким запасом: 1 балл
Минимальное количество баллов для выполнения задания: 6 баллов.

	*/
}
