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
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (14, N'Cinnamon Dolce Latte', N'Cinnamon Dolce Latte', 340, 580, N'https://globalassets.starbucks.com/digitalassets/products/bev/SBX20190617_CinnamonDolceLatte.jpg?impolicy=1by1_wide_topcrop_630', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (15, N'Double Chocolate Brownie', N'Double Chocolate Brownie', 480, 340, N'https://globalassets.starbucks.com/digitalassets/products/food/SBX20190715_DoubleChocolateChunkBrownie.jpg?impolicy=1by1_medium_630', CAST(N'2024-07-31T12:25:15.7085342' AS DateTime2), CAST(N'2024-07-31T12:25:15.7090205' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (16, N'Chocolate Chip Cookie', N'Chocolate Chip Cookie', 370, 180, N'https://planetbucksblob.blob.core.windows.net/productimages/9e224839-c3ee-4d73-9a21-03e67950d939.jpg', CAST(N'2024-07-31T16:34:40.6874037' AS DateTime2), CAST(N'2024-07-31T16:34:40.6875564' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (17, N'Caramel Macchiato', N'Caramel Macchiato', 250, 450, N'https://planetbucksblob.blob.core.windows.net/productimages/03c1775c-0eaf-44ba-af28-a69fd04536e9.jpg', CAST(N'2024-07-31T16:45:42.7689865' AS DateTime2), CAST(N'2024-07-31T16:45:42.7689881' AS DateTime2))
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Calories], [StarCost], [ImageUri], [CreatedAt], [UpdatedAt]) VALUES (1016, N'Espresso Con Panna', N'Espresso Con Panna', 35, 250, N'https://planetbucksblob.blob.core.windows.net/productimages/817476dd-c1d8-4f51-9d81-9c056a742272.jpg', CAST(N'2024-08-01T14:40:59.2184209' AS DateTime2), CAST(N'2024-08-01T14:40:59.2186256' AS DateTime2))
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
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (10, 14, 12, CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (11, 15, 22, CAST(N'2024-07-31T12:25:16.2582954' AS DateTime2), CAST(N'2024-07-31T12:25:16.2583933' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (12, 16, 22, CAST(N'2024-07-31T16:34:42.3751079' AS DateTime2), CAST(N'2024-07-31T16:34:42.3752959' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (13, 17, 13, CAST(N'2024-07-31T16:45:42.7935824' AS DateTime2), CAST(N'2024-07-31T16:45:42.7935825' AS DateTime2))
INSERT [dbo].[ProductCategories] ([ProductCategoryId], [ProductId], [CategoryId], [CreatedAt], [UpdatedAt]) VALUES (1012, 1016, 6, CAST(N'2024-08-01T14:40:59.2849480' AS DateTime2), CAST(N'2024-08-01T14:40:59.2853997' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [HashKey], [CreatedAt]) VALUES (2, N'sujan', N'dvsujan@gmail.com', 0x8B7E4D4CA6DF677EB325FC2FD10F1E40DFCD1B0123BE248FAC10F37D7C6ED0F48E6AC8B4402C2AE5333D88DFF74029F6C2E5643B2D8D1325651666AABCE43067, 0xFC00AB94BCAEEF13AD2793B2A1D989D72FB40A92DFD121177A30E6F1A228D181F33911839870EC32EF52008A342E2112EA0EB19606ED75EE041906E966545BDB53FD6C9D912A8B4809CDED069FE8475BC318DAABA6FF6329F5B4DC57970F2E68FA633421DAC2BD5A5C54CD5EAD7BA6E62B6884749605EFF147CEE442E2D09465, CAST(N'2024-07-25T14:18:00.0002921' AS DateTime2))
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [HashKey], [CreatedAt]) VALUES (3, N'python', N'pythonmail73@gmail.com', 0x37B1C738AE71DB443E627B4B003120635E018EFE023C43DCE08E5ECC6A11F549631AD1659BACB76285AE7A8276EECCE9E36C087A6ED55F9841AF0D7B9396BC7E, 0x233126A4D1BF25BDFA9FE04714D0F0241A689F754DB4777934DD946233B0B2594768B4BCC3AB07E666EC5DC365EC023CA0D276D068D9CA8D5D3397534BF8878D0BE732DE04079ADF9E38AB96C769EE198D2652FA23EF858C45A408F803B473886495D0AC4F74A500D6907593897598CA84A07856AC36FB6F15CF807699FA8804, CAST(N'2024-07-26T14:18:38.4239838' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([CartId], [UserId], [CreatedAt], [UpdatedAt]) VALUES (1, 2, CAST(N'2024-07-25T14:18:01.6802161' AS DateTime2), CAST(N'2024-07-25T14:18:01.6802267' AS DateTime2))
INSERT [dbo].[Carts] ([CartId], [UserId], [CreatedAt], [UpdatedAt]) VALUES (2, 3, CAST(N'2024-07-26T14:18:38.4960559' AS DateTime2), CAST(N'2024-07-26T14:18:38.4960595' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[Stores] ON 

INSERT [dbo].[Stores] ([StoreId], [City], [Address], [PhoneNumber], [Email], [CreatedAt], [UpdatedAt]) VALUES (2, N'Hyderabad', N'Ground Floor, Road No. 92, Near Apollo hospital, Jubilee Hills', N'1234567891', N'store1.planetbucks.com', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Stores] ([StoreId], [City], [Address], [PhoneNumber], [Email], [CreatedAt], [UpdatedAt]) VALUES (3, N'Hyderabad', N'Lower Ground Floor, Inorbit Mall, Madhapur', N'1234567891', N'store2.planetbucks.com', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Stores] ([StoreId], [City], [Address], [PhoneNumber], [Email], [CreatedAt], [UpdatedAt]) VALUES (8, N'Hyderabad', N'Lower Ground Floor, GVK One, Road Number 1, Banjara Hills', N'1234567891', N'store3.planetbucks.com', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Stores] ([StoreId], [City], [Address], [PhoneNumber], [Email], [CreatedAt], [UpdatedAt]) VALUES (9, N'Hyderabad', N'Upper Ground Floor, Forum Sujana Mall, Kukatpally', N'1234567891', N'store4.planetbucks.com', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Stores] ([StoreId], [City], [Address], [PhoneNumber], [Email], [CreatedAt], [UpdatedAt]) VALUES (11, N'Chennai', N'Guindy, Chennai', N'1234567891', N'store5.planetbucks.com', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Stores] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (6, 2, 2, CAST(1492.50 AS Decimal(18, 2)), N'Ready', CAST(N'2024-07-26T06:14:21.5259257' AS DateTime2), CAST(N'2024-07-26T06:14:21.5259263' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (8, 2, 2, CAST(525.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-07-26T08:45:31.2660516' AS DateTime2), CAST(N'2024-07-26T08:45:31.2660518' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (9, 3, 2, CAST(640.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-07-26T08:56:28.8626900' AS DateTime2), CAST(N'2024-07-26T08:56:28.8626903' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (10, 2, 2, CAST(825.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-07-30T06:11:19.0330717' AS DateTime2), CAST(N'2024-07-30T06:11:19.0331683' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (11, 2, 2, CAST(1620.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-07-30T06:58:35.8697796' AS DateTime2), CAST(N'2024-07-30T06:58:35.8704156' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (12, 2, 2, CAST(985.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-07-30T17:14:59.3922711' AS DateTime2), CAST(N'2024-07-30T17:14:59.3922712' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (13, 2, 2, CAST(1065.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-07-31T04:03:53.7568350' AS DateTime2), CAST(N'2024-07-31T04:03:53.7568351' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (14, 2, 2, CAST(920.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-07-31T16:35:28.1575254' AS DateTime2), CAST(N'2024-07-31T16:35:28.1578361' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (1014, 2, 2, CAST(425.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-08-01T04:37:16.4330796' AS DateTime2), CAST(N'2024-08-01T04:37:16.4331691' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (1015, 2, 2, CAST(870.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-08-01T08:53:03.3406118' AS DateTime2), CAST(N'2024-08-01T08:53:03.3414426' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [StoreId], [TotalAmount], [Status], [CreatedAt], [UpdatedAt]) VALUES (1016, 2, 2, CAST(435.00 AS Decimal(18, 2)), N'Ready', CAST(N'2024-08-01T09:22:29.3876278' AS DateTime2), CAST(N'2024-08-01T09:22:29.3876280' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (1, 6, 5, 3, N'[7,10]', CAST(N'2024-07-26T06:14:21.6062696' AS DateTime2), CAST(N'2024-07-26T06:14:21.6062698' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (2, 8, 5, 1, N'[]', CAST(N'2024-07-26T08:45:31.3114229' AS DateTime2), CAST(N'2024-07-26T08:45:31.3114870' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (3, 9, 4, 1, N'[7,9]', CAST(N'2024-07-26T08:56:28.9703733' AS DateTime2), CAST(N'2024-07-26T08:56:28.9703735' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (4, 10, 2, 2, N'[17,22]', CAST(N'2024-07-30T06:11:19.1442001' AS DateTime2), CAST(N'2024-07-30T06:11:19.1443143' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (5, 11, 6, 2, N'[3,8,17,13,22]', CAST(N'2024-07-30T06:58:39.0191292' AS DateTime2), CAST(N'2024-07-30T06:58:39.0192395' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (6, 11, 5, 1, N'[5]', CAST(N'2024-07-30T06:58:40.3002794' AS DateTime2), CAST(N'2024-07-30T06:58:40.3002795' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (7, 12, 5, 2, N'[5,17]', CAST(N'2024-07-30T17:14:59.4706514' AS DateTime2), CAST(N'2024-07-30T17:14:59.4706516' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (8, 13, 6, 1, N'[3,8,18,15,22]', CAST(N'2024-07-31T04:03:53.9149595' AS DateTime2), CAST(N'2024-07-31T04:03:53.9149604' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (9, 13, 9, 1, N'[]', CAST(N'2024-07-31T04:03:53.9393189' AS DateTime2), CAST(N'2024-07-31T04:03:53.9393195' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (10, 14, 17, 2, N'[5,6,18,15,22]', CAST(N'2024-07-31T16:35:28.2263281' AS DateTime2), CAST(N'2024-07-31T16:35:28.2264009' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (1010, 1014, 2, 1, N'[]', CAST(N'2024-08-01T04:37:16.4730469' AS DateTime2), CAST(N'2024-08-01T04:37:16.4731555' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (1011, 1015, 2, 1, N'[8]', CAST(N'2024-08-01T08:53:03.5429629' AS DateTime2), CAST(N'2024-08-01T08:53:03.5434004' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (1012, 1015, 2, 1, N'[17]', CAST(N'2024-08-01T08:53:03.6012077' AS DateTime2), CAST(N'2024-08-01T08:53:03.6012082' AS DateTime2))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [SelectedOptions], [CreatedAt], [UpdatedAt]) VALUES (1013, 1016, 2, 1, N'[15]', CAST(N'2024-08-01T09:22:29.4115155' AS DateTime2), CAST(N'2024-08-01T09:22:29.4115158' AS DateTime2))
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [Name], [Email], [Password], [HashKey], [StoreId], [CreatedAt], [UpdatedAt]) VALUES (1, N'Sujan', N'dvsujan@gmail.com', 0x9D110C241E9555266F217A2151BF097D7CFE7CEE19833A7760EC8177E75654167BF838FBCEB2D4D26AD78322AE5ED7D3386BA5D3139AEAFCD1A5A1D3D39EBCD8, 0x85AB5EB97BF4B23B9E785FAB73C0EC2294DDF95BBA06FB7B7EE36E9D63043C38CCD6E231A5806B266307DAB6A9E67BCD173E7148B80E36217502CAEFBDB2C10008E85EBBED2B7AA1121697C9EFF354A0D37E96DA4C9891C1D72CBC5C5AE6B6F874E21B476500373D88A4EA9DC2B8F891BF5BE5ECBF4C3540181324877DAB8AC0, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([EmployeeId], [Name], [Email], [Password], [HashKey], [StoreId], [CreatedAt], [UpdatedAt]) VALUES (2, N'python', N'pythonmail73@gmail.com', 0x4566B17DD44AE4F2ED35DA4E0EFBDEE733477741B5CAA703BF066CF5DA7B9C05F6345BEA599C12C46BE7AB2FF7CF8674CF1B9A17DD71C335C11A261AD18B533A, 0x22505C3E78D4EA8CCB6CAE6F32AD1A6E2CA111DC525BF1D1EE07D32A9948D6A67F24E2606429D57218EE46B78DD614B4CBFF5D11E1E15C95783BAF33542B9B4EABF41E7D5648D20B03A6BBD940FCDADB8E756BC96A12E753D8406FABA42223C64217ABFF55C1D255A67BCE57758133A902F28B342074C738FACC0314169288FB, 11, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Employees] OFF
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240725164911_four', N'8.0.7')
GO
