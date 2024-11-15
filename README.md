# KumysWarehouse
CREATE DATABASE KumysWarehouse;

USE KumysWarehouse;

CREATE TABLE RawMaterials (
    RawMaterialID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50),
    Quantity DECIMAL(10, 2),
    Unit NVARCHAR(10),
    LastUpdated DATETIME DEFAULT GETDATE()
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50),
    Quantity DECIMAL(10, 2),
    Unit NVARCHAR(10),
    ExpiryDate DATETIME,
    LastUpdated DATETIME DEFAULT GETDATE()
);
 вот это код для sql сдеалешь копировать вставить потом короче сделаешь в эти таблицы вставить вот это:
 Таблица RawMaterials (Сырье)
RawMaterialID	Name	Quantity	Unit	LastUpdated
1	Кобылье молоко	100.00	литры	2024-11-15 10:00:00
2	Сахар	25.00	кг	2024-11-15 11:00:00
3	Закваска	5.00	литры	2024-11-14 14:00:00
4	Вода	200.00	литры	2024-11-13 09:00:00
Таблица Products (Продукция)
ProductID	Name	Quantity	Unit	ExpiryDate	LastUpdated
1	Кумыс классический	50.00	литры	2024-12-01 00:00:00	2024-11-15 12:00:00
2	Кумыс сладкий	30.00	литры	2024-11-30 00:00:00	2024-11-14 15:00:00
3	Кумыс диетический	20.00	литры	2024-12-05 00:00:00	2024-11-15 09:00:00
Таблица Transactions (Операции)
TransactionID	TransactionDate	Type	ItemID	Quantity	Unit	Notes
1	2024-11-15 10:30:00	Поступление	1	50.00	литры	Поставка кобыльего молока
2	2024-11-14 15:00:00	Списание	2	5.00	кг	Использовано для закваски
3	2024-11-13 10:00:00	Поступление	3	2.00	литры	Поставка закваски
4	2024-11-15 12:00:00	Поступление	2	10.00	кг	Поставка сахара
5	2024-11-15 14:00:00	Реализация	1	10.00	литры	Отправка продукции клиенту 
