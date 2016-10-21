/****** Brands ******/
INSERT INTO [NZB-Seed].[dbo].[Brands]
SELECT Name
FROM [NZB].[dbo].[Brand]
GO

/****** Categories ******/
INSERT INTO [NZB-Seed].[dbo].[Categories]
SELECT Name
FROM [NZB].[dbo].[Category]
GO

/****** Configs ******/
INSERT INTO [NZB-Seed].[dbo].[Configs]
SELECT [Key],[Value]
FROM [NZB].[dbo].[AppConfig]
GO

/****** Customers ******/
INSERT INTO [NZB-Seed].[dbo].[Customers]
SELECT [Address],Address1,[Description], Email, FullName, 0, [Level], NamePinYin, Phone1, Phone2 
FROM [NZB].[dbo].[Customer]
GO

/****** ExchangeRates ******/
INSERT INTO [NZB-Seed].[dbo].[ExchangeRates]
SELECT ModifiedTime, NZDCNY, [Source], USDCNY, USDNZD  
FROM [NZB].[dbo].[ExchangeRate]
GO

/****** ExchangeRecords ******/
INSERT INTO [NZB-Seed].[dbo].[ExchangeRecords]
SELECT Agent, Cny, CreatedTime, Nzd, Rate, ReceiverCharge, SponsorCharge 
FROM [NZB].[dbo].[ExchangeHistory]
GO

/****** Products ******/
INSERT INTO [NZB-Seed].[dbo].[Products]
SELECT [NZB-Seed].[dbo].Brands.Id,[NZB-Seed].[dbo].[Categories].Id,[Desc],[NZB].[dbo].[Product].Name,Price
FROM [NZB].[dbo].[Product]
INNER JOIN [NZB].[dbo].Brand ON [NZB].[dbo].[Product].BrandId = [NZB].[dbo].Brand.Id
INNER JOIN [NZB].[dbo].[Category] ON [NZB].[dbo].[Product].CategoryId = [NZB].[dbo].[Category].Id
INNER JOIN [NZB-Seed].[dbo].Brands ON [NZB].[dbo].Brand.Name = [NZB-Seed].[dbo].Brands.Name
INNER JOIN [NZB-Seed].[dbo].[Categories] ON [NZB].[dbo].[Category].Name = [NZB-Seed].[dbo].[Categories].Name
GO

/****** Suppliers ******/
INSERT INTO [NZB-Seed].[dbo].[Suppliers]
SELECT [Address], Name, Phone
FROM [NZB].[dbo].[Supplier]
GO

/****** ProductQuote ******/
INSERT INTO [NZB-Seed].[dbo].ProductQuote
SELECT ProductQuote_CTE.Price, Product_CTE.ProductId, Supplier_CTE.SupplierId
FROM 
(
	SELECT [NZB].[dbo].ProductQuote.Price, [NZB].[dbo].Supplier.Name AS SupplierName, [NZB].[dbo].Product.Name AS ProductName, [NZB].[dbo].Brand.Name AS BrandName
	FROM [NZB].[dbo].ProductQuote
	INNER JOIN [NZB].[dbo].Product ON [NZB].[dbo].[Product].Id = [NZB].[dbo].ProductQuote.ProductId
	INNER JOIN [NZB].[dbo].Supplier ON [NZB].[dbo].Supplier.Id = [NZB].[dbo].ProductQuote.SupplierId
	INNER JOIN [NZB].[dbo].Brand ON [NZB].[dbo].[Product].BrandId = [NZB].[dbo].Brand.Id
) AS ProductQuote_CTE
INNER JOIN 
(
	SELECT [NZB-Seed].[dbo].Products.Id AS ProductId, [NZB-Seed].[dbo].Products.Name AS ProductsName, [NZB-Seed].[dbo].Brands.Name AS BrandName
	FROM [NZB-Seed].[dbo].Products
	INNER JOIN [NZB-Seed].[dbo].Brands ON [NZB-Seed].[dbo].Products.BrandId = [NZB-Seed].[dbo].Brands.Id
) AS Product_CTE ON ProductQuote_CTE.ProductName = Product_CTE.ProductsName AND ProductQuote_CTE.BrandName = Product_CTE.BrandName
INNER JOIN
(
	SELECT [NZB-Seed].[dbo].Suppliers.Id AS SupplierId, [NZB-Seed].[dbo].Suppliers.Name AS SupplierName
	FROM [NZB-Seed].[dbo].Suppliers
) AS Supplier_CTE ON ProductQuote_CTE.SupplierName = Supplier_CTE.SupplierName
GO

/****** Orders ******/
INSERT INTO [NZB-Seed].[dbo].[Orders]
SELECT [Address], CompleteTime, DeliveryTime, [Description], Freight, OrderState, OrderTime, PayTime, PaymentState, Phone, ReceiveTime, Recipient, WaybillNumber, [Weight]
FROM [NZB].[dbo].[Order]
GO

/****** OrderProduct ******/
INSERT INTO [NZB-Seed].[dbo].[OrderProduct]
SELECT OrderProduct_CTE.Cost,[NZB-Seed].[dbo].Customers.Id, Orders_CTE.Id, OrderProduct_CTE.Purchased, OrderProduct_CTE.Price, Product_CTE.ProductId, 
	OrderProduct_CTE.OrderProductName, OrderProduct_CTE.Qty
FROM 
(
	SELECT [NZB].[dbo].[OrderProduct].Cost,[NZB].[dbo].[OrderProduct].Purchased, [NZB].[dbo].[OrderProduct].Price, [NZB].[dbo].[OrderProduct].ProductName AS OrderProductName, 
			[NZB].[dbo].[OrderProduct].Qty,[NZB].[dbo].[Customer].FullName AS CustomerName, CHECKSUM([NZB].[dbo].[Order].DeliveryTime, [NZB].[dbo].[Order].[Address]) AS OrderChecksum,
			[NZB].[dbo].Product.Name AS ProductName, [NZB].[dbo].Brand.Name AS BrandName
	FROM [NZB].[dbo].[OrderProduct]
	INNER JOIN [NZB].[dbo].[Customer] ON [NZB].[dbo].[OrderProduct].CustomerId = [NZB].[dbo].[Customer].Id
	INNER JOIN [NZB].[dbo].[Order] ON [NZB].[dbo].[OrderProduct].OrderId = [NZB].[dbo].[Order].Id
	INNER JOIN [NZB].[dbo].Product ON [NZB].[dbo].[Product].Id = [NZB].[dbo].[OrderProduct].ProductId
	INNER JOIN [NZB].[dbo].Brand ON [NZB].[dbo].[Product].BrandId = [NZB].[dbo].Brand.Id
) AS OrderProduct_CTE
INNER JOIN [NZB-Seed].[dbo].Customers ON [NZB-Seed].[dbo].Customers.FullName = OrderProduct_CTE.CustomerName
INNER JOIN 
(
	SELECT Id, CHECKSUM([NZB-Seed].[dbo].[Orders].DeliveryTime, [NZB-Seed].[dbo].[Orders].[Address]) AS OrderChecksum
	FROM [NZB-Seed].[dbo].[Orders]

) AS Orders_CTE ON OrderProduct_CTE.OrderChecksum = Orders_CTE.OrderChecksum
INNER JOIN 
(
	SELECT [NZB-Seed].[dbo].Products.Id AS ProductId, [NZB-Seed].[dbo].Products.Name AS ProductsName, [NZB-Seed].[dbo].Brands.Name AS BrandName
	FROM [NZB-Seed].[dbo].Products
	INNER JOIN [NZB-Seed].[dbo].Brands ON [NZB-Seed].[dbo].Products.BrandId = [NZB-Seed].[dbo].Brands.Id
) AS Product_CTE ON Product_CTE.ProductsName = OrderProduct_CTE.ProductName AND Product_CTE.BrandName = OrderProduct_CTE.BrandName
GO

/****** Shipments ******/
INSERT INTO [NZB-Seed].[dbo].[Shipments]
SELECT ArrivedTime, Destination, [From], ItemCount, ModifiedTime, Recipient, [Status], WaybillNumber
FROM [NZB].[dbo].[ExpressTrack]
GO

/****** ShipmentEntry ******/
INSERT INTO [NZB-Seed].[dbo].[ShipmentEntry]
SELECT Content, Shipments_CTE.Id, [When], [Where]
FROM [NZB].[dbo].[ExpressTrackRecord]
INNER JOIN
(
	SELECT Id, CHECKSUM(WaybillNumber, ModifiedTime) AS ETChecksum
	FROM [NZB].[dbo].[ExpressTrack]
) AS ExpressTrack_CTE  ON [NZB].[dbo].[ExpressTrackRecord].ExpressTrackId = ExpressTrack_CTE.Id
INNER JOIN
(
	SELECT Id, CHECKSUM(TrackingNumber, ModifiedTime) AS SChecksum
	FROM [NZB-Seed].[dbo].[Shipments]
) AS Shipments_CTE  ON Shipments_CTE.SChecksum = ExpressTrack_CTE.ETChecksum
GO