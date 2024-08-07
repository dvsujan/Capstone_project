USE [CofeeFirst]
GO
SET IDENTITY_INSERT [dbo].[ProductOptions] ON 

INSERT [dbo].[ProductOptions] ([OptionId], [Name], [UnitOfMeasure], [AdditionalCost]) VALUES (1, N'Milk', N'Ml', CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductOptions] ([OptionId], [Name], [UnitOfMeasure], [AdditionalCost]) VALUES (2, N'Flavours', N'Pump', CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductOptions] ([OptionId], [Name], [UnitOfMeasure], [AdditionalCost]) VALUES (3, N'Toppings', N'g', CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductOptions] ([OptionId], [Name], [UnitOfMeasure], [AdditionalCost]) VALUES (4, N'Sweetener Packet', N'Pack', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductOptions] ([OptionId], [Name], [UnitOfMeasure], [AdditionalCost]) VALUES (5, N'Espesso', N'Shot', CAST(10.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ProductOptions] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductOptionValues] ON 

INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (2, 1, N'2% Milk', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (3, 1, N'Oat Milk', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (4, 1, N'Soy Milk', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (5, 1, N'Almond Milk', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (6, 2, N'Brown Sugar Syrup', CAST(5.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (7, 2, N'Caramel Syrup', CAST(5.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (8, 2, N'HazelNut Syrup', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (9, 2, N'Mocha Sauce', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (10, 2, N'Dark Caramel Sauce', CAST(20.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (11, 2, N'chocolate malt powerder', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (13, 3, N'Caramel CrunchTopping', CAST(20.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (15, 3, N'Cinamem Crumble Topping', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (16, 3, N'Caramel Drizzle', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (17, 4, N'Stevia', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (18, 4, N'Honey Blend', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (19, 4, N'Classic Syrup', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (20, 5, N'2', CAST(10.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionValues] ([OptionValueId], [OptionId], [Value], [AdditionalCost], [CreatedAt], [UpdatedAt]) VALUES (22, 5, N'4', CAST(20.00 AS Decimal(18, 2)), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductOptionValues] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (2, N'Caffè Americano', N'americano noice', 15, 425, N'https://globalassets.starbucks.com/digitalassets/products/bev/SBX20190617_CaffeAmericano.jpg?impolicy=1by1_wide_topcrop_630', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (4, N'Featured Blonde Roast', N'Featured Blonde Roast', 5, 625, N'https://globalassets.starbucks.com/digitalassets/products/bev/Veranda_Blend_Hot.jpg', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (5, N'Cappuccino', N'Cappuccino', 140, 525, N'https://globalassets.starbucks.com/digitalassets/products/bev/SBX20190617_Cappuccino.jpg?impolicy=1by1_wide_topcrop_630', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (6, N'Honey Almondmilk Flat White', N'Honey Almondmilk Flat White', 120, 525, N'https://globalassets.starbucks.com/digitalassets/products/bev/SBX20230406_HoneyAlmondmilkFlatWhite.jpg?impolicy=1by1_wide_topcrop_630', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (8, N'Caffè Latte', N'Caffè Latte', 190, 525, N'https://globalassets.starbucks.com/digitalassets/products/bev/SBX20190617_CaffeLatte.jpg?impolicy=1by1_wide_topcrop_630', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (9, N'Egg, Pesto & Mozzarella Sandwich', N'Egg, Pesto & Mozzarella Sandwich', 390, 480, N'https://globalassets.starbucks.com/digitalassets/products/food/EggPestoMozzarellaSandwich.jpg?impolicy=1by1_medium_630', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (13, N'Caffè Misto', N'Caffè Misto', 110, 520, N'https://globalassets.starbucks.com/digitalassets/products/bev/SBX20190617_CaffeMisto.jpg?impolicy=1by1_wide_topcrop_630', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[SuperCategories] ON 

INSERT [dbo].[SuperCategories] ([SuperCategoryId], [Name], [CreatedAt], [UpdatedAt]) VALUES (1, N'Beverages', CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[SuperCategories] ([SuperCategoryId], [Name], [CreatedAt], [UpdatedAt]) VALUES (3, N'Food', CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[SuperCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (1, 1, N'Americanos', N'No milk', CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (3, 1, N'Brewed Coffees', N'Espesso', CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (5, 1, N'Cappuccinos', N'cappucino', CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (6, 1, N'Espresso Shots
', N'Espresso Shots
', CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (10, 1, N'Flat Whites', N'Flat Whites', CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (12, 1, N'Lattes', N'Lattes', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (13, 1, N'Macchiatos', N'Macchiatos', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (19, 3, N'Break Fast Sandwitches', N'Break Fast Sandwitches', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (20, 3, N'Bakes & Egg Bites', N'Bakes & Egg Bites', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (21, 3, N'Bagels', N'Bagles', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [SuperCategoryId], [Name], [Description], [CreatedAt], [UpdatedAt]) VALUES (22, 3, N'Cookies, Brownies & Bars', N'Cookies, Brownies & Bars', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategories] ON 

INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (2, 2, 1, CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (3, 4, 3, CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (4, 5, 5, CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (5, 6, 10, CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (6, 8, 12, CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (8, 9, 20, CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (9, 13, 3, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [HashKey], [CreatedAt]) VALUES (1, N'sujan', N'dvsujan@gmail.com', 0x08CCDA34B8AB0552B611FEF5E3E5E2931BEFFBC4844C04C96DA5EAAFBDD3DCEC428696B6293BDE25B755434C942E606BD58B8CF5DFA10A3710D8F949189580CC, 0xDF0C49D94E28F6800CC5F3ECEEF466775F0A891FF16BDDBDA04D835314202C16432053FD1F5DB89D0E2C6C124B8D18088CF5D51D52925F93083951DEBE80FB6725F4FC069F123B38B503B081675B1234A523F67E5789C1A8293D3E2EF83425F68725DB65027237091D63B515AA202655E7D99D0D2F920814943A4E77B09A1EE3, CAST(N'2024-07-24T14:27:31.0796453' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductOptionCategories] ON 

INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (2, 2, 1, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (9, 4, 1, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (15, 3, 1, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (17, 5, 1, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (22, 2, 3, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (23, 4, 3, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (26, 3, 3, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (27, 5, 3, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (28, 1, 5, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (29, 2, 5, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (30, 4, 5, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (31, 3, 5, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (32, 5, 5, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (33, 1, 6, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (34, 2, 6, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (35, 4, 6, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (36, 3, 6, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (37, 5, 6, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (38, 1, 10, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (39, 2, 10, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (40, 4, 10, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (41, 3, 10, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (42, 5, 10, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (43, 1, 12, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (44, 2, 12, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (45, 4, 12, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (46, 3, 12, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (47, 5, 12, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (48, 1, 13, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (49, 2, 13, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (50, 4, 13, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (51, 3, 13, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductOptionCategories] ([OptionCategoryId], [OptionId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (52, 5, 13, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductOptionCategories] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240723100337_init', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240723162439_two', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240724053121_three', N'8.0.7')
GO
