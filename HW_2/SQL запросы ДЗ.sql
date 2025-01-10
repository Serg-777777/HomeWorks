
  -- 1. Создание таблиц и связей:
  CREATE TABLE users ( 
  UserID INT NOT NULL PRIMARY KEY AUTO INCREMENT,
  UserName VARCHAR(50) NOT NULL,
  Email VARCHAR(150) NULL,
  RegistrationDate VARCHAR(50) NOT NULL,
  UNIQUE(UserID));

  CREATE TABLE orders ( 
  OrderID INT PRIMARY KEY AUTO INCROMENT,
  UserID INT  NOT NULL,
  OrderDate VARCHAR(50) NOT NULL,
  Status VARCHAR(50),
  UNIQUE(OrderID), FOREIGN KEY (UserID) REFERENCES Users (UserID) ON DELETE CASCADE);

  CREATE TABLE products ( 
  ProductID INT NOT NULL PRIMARY KEY AUTO INCREMENT,
  ProductName VARCHAR(50) NOT NULL,
  Description VARCHAR(100) NULL,
  Price FLOAT NULL,
  QuantityInStock INT NULL,
  RegistrationDate VARCHAR(50) NOT NULL,
  UNIQUE(ProductID));

  CREATE TABLE orderDetails ( 
  OrderDetailID INT PRIMARY KEY AUTO INCREMENT,
  OrderID INT NOT NULL,
  ProductID INT  NOT NULL,
  Quantity INT,
  PriceOrder FLOAT NULL,
  TotalCost VARCHAR(10),
  RegistrationDate VARCHAR(50) NOT NULL,
  UNIQUE(OrderDetailID),
  FOREIGN KEY (OrderID) REFERENCES Orders (OrderID) ON DELETE CASCADE,
  FOREIGN KEY (ProductID) REFERENCES Products (ProductID) ON DELETE CASCADE);

-- Создание пользователя
INSERT INTO users (UserID, UserName, Email, RegistrationDate) VALUES (0, 'user1', 'mail@mail.com', '29.08.2024 18:48:07');

-- Добавление нового продукта
INSERT INTO products (ProductID, ProductName, Description, Price, QuantityInStock, RegistrationDate) VALUES (0, 'item1', 'desc', '100.5', 3, '29.08.2024 18:48:29');

-- Создание заказа
INSERT INTO orders (OrderID, UserID, OrderDate, Status) VALUES (0, 0, '29.08.2024 18:48:32', 'sent');

-- Добавление деталей заказа
INSERT INTO orderDetails (OrderDetailID, OrderID, ProductID, Quantity, PriceOrder, TotalCost, RegistrationDate) VALUES (0, 0, 0, 1, '100.5', 0, '29.08.2024 18:49:06');

-- Получение 5 самых дорогих товаров.
SELECT TOP (5) ProductID, ProductName, QuantityInStock, Price FROM products ORDER BY Price DESC;

-- Список товаров с низким запасом (менее 5 штук)
SELECT ProductID, ProductName, QuantityInStock, Price FROM products
WHERE QuantityInStock < 5
ORDER BY QuantityInStock;

-- Расчет общей стоимости заказа
SELECT orders.OrderID, OrderDate, Status, Quantity, PriceOrder, Quantity * PriceOrder AS TotalAmount FROM orders
LEFT JOIN orderDetails ON orderDetails.OrderID = orders.OrderID
WHERE orders.OrderID = 0 ;

-- Сумма заказа
SELECT Sum(PriceOrder * Quantity) as TotalAmount
FROM orderDetails
WHERE OrderID = 0
GROUP BY OrderID;

-- 8. Подсчет количества товаров на складе.
SELECT Sum(QuantityInStock) as Total
FROM products
GROUP BY ProductID;

-- Обновить поля продукта
UPDATE products SET Price = 90, Description = 'desc', ProductName = 'new name' WHERE ProductID = 0;

-- Выбор всех продуктов
SELECT ProductID, ProductName, Description, QuantityInStock, Price FROM products;

-- Удалить таблицы
DROP TABLE orderDetails;
DROP TABLE orders;
DROP TABLE users;
DROP TABLE products;