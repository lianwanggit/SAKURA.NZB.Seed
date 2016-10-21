DELETE FROM [NZB-Seed].[dbo].Orders
DELETE FROM [NZB-Seed].[dbo].OrderProduct
DELETE FROM [NZB-Seed].[dbo].ProductQuote
DELETE FROM [NZB-Seed].[dbo].Products
DELETE FROM [NZB-Seed].[dbo].ShipmentEntry
DELETE FROM [NZB-Seed].[dbo].Shipments
DELETE FROM [NZB-Seed].[dbo].Brands
DELETE FROM [NZB-Seed].[dbo].Categories
DELETE FROM [NZB-Seed].[dbo].Configs
DELETE FROM [NZB-Seed].[dbo].Customers
DELETE FROM [NZB-Seed].[dbo].Suppliers
DELETE FROM [NZB-Seed].[dbo].ExchangeRates
DELETE FROM [NZB-Seed].[dbo].ExchangeRecords

DBCC CHECKIDENT ('[NZB-Seed].[dbo].[Orders]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[OrderProduct]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[ProductQuote]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[Products]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[ShipmentEntry]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[Shipments]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[Brands]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[Categories]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[Customers]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[Suppliers]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[ExchangeRates]', RESEED, 0)
DBCC CHECKIDENT ('[NZB-Seed].[dbo].[ExchangeRecords]', RESEED, 0)