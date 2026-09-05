USE [ECommerceDB];

CREATE USER [Ecommerce_DB] FOR LOGIN [Ecommerce_DB];

ALTER ROLE [db_datareader] ADD MEMBER [Ecommerce_DB];
ALTER ROLE [db_datawriter] ADD MEMBER [Ecommerce_DB];