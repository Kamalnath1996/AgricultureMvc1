USE [Agriculture]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/23/2020 20:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[userName] [varchar](100) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[roleId] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [firstName], [lastName], [email], [phone], [userName], [password], [roleId], [createdOn]) VALUES (1, N'Himangini', N'Kar', N'himangini@gmail.com', N'9874563210', N'himangini@gmail.com', N'himangini', 2, CAST(0x0000AB660078B4BD AS DateTime))
INSERT [dbo].[Users] ([Id], [firstName], [lastName], [email], [phone], [userName], [password], [roleId], [createdOn]) VALUES (2, N'Himangini', N'Kar', N'himangini@gmail.com', N'9874563210', N'himangini@gmail.com', N'123456', 2, CAST(0x0000AB6800854E33 AS DateTime))
INSERT [dbo].[Users] ([Id], [firstName], [lastName], [email], [phone], [userName], [password], [roleId], [createdOn]) VALUES (3, N'Himangini', N'Kar', N'himangini@gmail.com', N'9874563210', N'himangini@gmail.com', N'123456', 1, CAST(0x0000AB6800871F8E AS DateTime))
INSERT [dbo].[Users] ([Id], [firstName], [lastName], [email], [phone], [userName], [password], [roleId], [createdOn]) VALUES (4, N'Himangini', N'Kar', N'himangini@gmail.com', N'9874563210', N'himangini@gmail.com', N'123456', 2, CAST(0x0000AB6800875E24 AS DateTime))
INSERT [dbo].[Users] ([Id], [firstName], [lastName], [email], [phone], [userName], [password], [roleId], [createdOn]) VALUES (5, N'subhalXMI', N'JENA', N'jenasubhalaxmi@gmail.com', N'9874563210', N'jenasubhalaxmi@gmail.com', N'SILU12', 2, CAST(0x0000AB6A013E9514 AS DateTime))
INSERT [dbo].[Users] ([Id], [firstName], [lastName], [email], [phone], [userName], [password], [roleId], [createdOn]) VALUES (6, N'SUHALAXMI', N'JENA', N'jenasubhalaxmi@gmail.com', N'9874563210', N'jenasubhalaxmi@gmail.com', N'SILU12', 1, CAST(0x0000AB6A0141BC89 AS DateTime))
INSERT [dbo].[Users] ([Id], [firstName], [lastName], [email], [phone], [userName], [password], [roleId], [createdOn]) VALUES (7, N'SUHALAXMI', N'JENA', N'jenasubhalaxmi1@gmail.com', N'9874563210', N'jenasubhalaxmi1@gmail.com', N'123456', 2, CAST(0x0000AB6A0144028F AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[Products]    Script Date: 02/23/2020 20:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[productName] [varchar](50) NOT NULL,
	[productImage] [varchar](max) NOT NULL,
	[productWeight] [int] NOT NULL,
	[productUnit] [varchar](20) NOT NULL,
	[productQuantity] [int] NOT NULL,
	[productPrice] [decimal](10, 2) NOT NULL,
	[categoryId] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT [dbo].[Products] ([Id], [productName], [productImage], [productWeight], [productUnit], [productQuantity], [productPrice], [categoryId], [createdOn], [modifiedOn]) VALUES (6, N'Aloo', N'http://localhost:57869/Assets1/Images/23022020190633download.jpg', 1, N'KG', 123, CAST(12.00 AS Decimal(10, 2)), 2, CAST(0x0000AB6A013AEDF2 AS DateTime), NULL)
INSERT [dbo].[Products] ([Id], [productName], [productImage], [productWeight], [productUnit], [productQuantity], [productPrice], [categoryId], [createdOn], [modifiedOn]) VALUES (8, N'fruits', N'http://localhost:57869/Assets1/Images/230220201916186.jpg', 1, N'KG', 1, CAST(31.00 AS Decimal(10, 2)), 1, CAST(0x0000AB6A013D9754 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
/****** Object:  Table [dbo].[FarmerAddress]    Script Date: 02/23/2020 20:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FarmerAddress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State] [varchar](60) NOT NULL,
	[City] [varchar](60) NOT NULL,
	[locality] [varchar](60) NOT NULL,
	[FarmerId] [int] NOT NULL,
 CONSTRAINT [PK_FarmerAddress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FarmerAddress] ON
INSERT [dbo].[FarmerAddress] ([Id], [State], [City], [locality], [FarmerId]) VALUES (1, N'2', N'2', N'2', 1)
INSERT [dbo].[FarmerAddress] ([Id], [State], [City], [locality], [FarmerId]) VALUES (2, N'2', N'1', N'1', 2)
INSERT [dbo].[FarmerAddress] ([Id], [State], [City], [locality], [FarmerId]) VALUES (3, N'1', N'1', N'1', 4)
INSERT [dbo].[FarmerAddress] ([Id], [State], [City], [locality], [FarmerId]) VALUES (4, N'ODISHA', N'BHUBANESWAR', N'BBSR', 5)
INSERT [dbo].[FarmerAddress] ([Id], [State], [City], [locality], [FarmerId]) VALUES (5, N'ODISHA', N'BHUBANESWAR', N'BBSR', 7)
SET IDENTITY_INSERT [dbo].[FarmerAddress] OFF
/****** Object:  Table [dbo].[Category]    Script Date: 02/23/2020 20:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[categoryName] [varchar](75) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([Id], [categoryName]) VALUES (1, N'Vegetable')
INSERT [dbo].[Category] ([Id], [categoryName]) VALUES (2, N'Fruits')
INSERT [dbo].[Category] ([Id], [categoryName]) VALUES (3, N'Flower')
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Cart]    Script Date: 02/23/2020 20:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cart] ON
INSERT [dbo].[Cart] ([Id], [productId], [quantity], [userId]) VALUES (3, 1, 1, 0)
INSERT [dbo].[Cart] ([Id], [productId], [quantity], [userId]) VALUES (4, 6, 4, 0)
INSERT [dbo].[Cart] ([Id], [productId], [quantity], [userId]) VALUES (5, 8, 6, 0)
INSERT [dbo].[Cart] ([Id], [productId], [quantity], [userId]) VALUES (6, 6, 1, 5)
INSERT [dbo].[Cart] ([Id], [productId], [quantity], [userId]) VALUES (7, 8, 1, 5)
INSERT [dbo].[Cart] ([Id], [productId], [quantity], [userId]) VALUES (8, 6, 1, 6)
SET IDENTITY_INSERT [dbo].[Cart] OFF
/****** Object:  StoredProcedure [dbo].[Authentication]    Script Date: 02/23/2020 20:55:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Authentication]
(
	@Id int = null,
	@Email varchar(100) = null,
	@FirstName varchar(50) = null,
	@LastName varchar(50) = null,
	@Password varchar(20) = null,
	@type int,
	@roleId int = null,
	@State varchar(60) = null,
	@City varchar(60) = null,
	@Locality varchar(60) = null
)
AS
Begin
	if(@type = 1)
	Begin
		if exists(select Id from Users where userName = @Email and password = @Password and roleId = @roleId)
		begin
			select * from Users where userName = @Email and password = @Password and roleId = @roleId;
		End
		else
		Begin
			select 0 as Id;
		End
	End
	if(@type = 2)
	Begin
	Declare @msg int = 0;
		if not exists(select Id from Users where Id = @Id)
		begin
			insert into Users(firstName, lastName, email, userName, password, roleId) values (@FirstName, @LastName, @Email, @Email, @Password, @roleId);
			if(@roleId = 2)
			Begin
				insert into FarmerAddress(State, City, Locality, FarmerId) values(@State, @City, @Locality, SCOPE_IDENTITY());
			End		
			set @msg = 1;	
		End
		else
		Begin
			update Users set firstName = @FirstName, lastName = @LastName, email = @Email, userName = @Email, password = @Password, roleId = @roleId where Id = @Id;
			if(@roleId = 2)
			Begin
				update FarmerAddress set State = @State, City = @City, Locality = @Locality where FarmerId = @Id;
			End
			set @msg = 1;		
		End
	select @msg as Id;
	End
	if(@type = 3)
	Begin
		select * from Users u left join FarmerAddress on u.Id = FarmerId where u.Id = @Id;
	End
End
GO
/****** Object:  StoredProcedure [dbo].[Add_Remove_Select_Edit_Product]    Script Date: 02/23/2020 20:55:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Add_Remove_Select_Edit_Product]  
(  
 @Id int = null,  
 @productName varchar(50) = null,  
 @productImage varchar(MAX) = null,  
 @productWeight int = null,  
 @productUnit varchar(20) = null,  
 @productQuantity int = null,  
 @productPrice decimal(10,2) = null,  
 @categoryId int = null,  
 @type int  
)  
AS  
Begin  
 if(@type = 1)  
 Begin  
  Declare @msg int = 0;  
  if not exists(select Id from Products where Id = @id)  
  Begin  
   insert into Products(productName, productImage, productWeight, productUnit, productQuantity, productPrice, categoryId) values(@productName, @productImage, @productWeight, @productUnit, @productQuantity, @productPrice, @categoryId);  
   set @msg = 1;   
  End  
  Else  
  Begin  
   update Products set productName = @productName, productImage = @productImage, productWeight = @productWeight, productUnit = @productUnit, productQuantity = @productQuantity, productPrice = @productPrice, categoryId = @categoryId where Id = @Id;  
   set @msg = 1;  
  End  
  select @msg as Id;  
 End  
 if(@type = 2)  
 Begin  
  select p.*, c.categoryName productCategory from Products p inner join Category c on c.Id = p.categoryId ;  
 End  
 if(@type = 3)  
 Begin  
  select * from Products where Id = @Id;  
 End  
 if(@type = 4)  
 Begin  
  select p.*, c.categoryName productCategory from Products p inner join Category c on c.Id = p.categoryId where categoryId = @categoryId;  
 End  
 if(@type = 5)  
 Begin  
  delete from Products where Id = @Id;  
 End  
 if(@type = 6)  
 Begin  
  select * from Category;  
 End  
End
GO
/****** Object:  StoredProcedure [dbo].[Add_Remove_Select_Delete_cart]    Script Date: 02/23/2020 20:55:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Add_Remove_Select_Delete_cart]
(
	@Id int = null,
	@ProductId int = null,
	@userId int = null,
	@type int
)
AS
Begin
	Declare @msg int = 0;
	if(@type = 1)
	Begin
		if not exists(select Id from Cart where ProductId = @ProductId and userId = @userId)
		Begin
			insert into Cart(productId, quantity, userId) values(@ProductId, 1, @userId);
			set @msg = 1;
		End
		Else
		Begin
			update Cart set quantity = quantity+1 where productId = @ProductId and userId = @userId;
			set @msg = 1;
		End
		select @msg;
	End
	if(@type = 2)
	Begin
		if((select quantity from Cart where ProductId = @ProductId and userId = @userId)>1)
		Begin
			update Cart set quantity = quantity-1 where productId = @ProductId and userId = @userId;
			set @msg = 1;	
		End
		Else
		Begin
			delete from Cart where productId = @ProductId and userId = @userId;
			set @msg = 1;
		End
		select @msg as Id;
	End
	if(@type = 3)
	Begin
		select c.Id, p.Id productId, p.productName, p.productPrice, p.productWeight, p.productUnit, p.productimage, c.quantity from Cart c inner join Products p on p.Id = c.ProductId where c.userId = @userId;
	End
	if(@type = 4)
	Begin
		delete from cart where Id = @Id;
		select 1;
	End
	if(@type = 5)
	Begin
		delete from cart where userId = @userId;
		select 1;
	End
End
GO
/****** Object:  Default [DF_Products_createdOn]    Script Date: 02/23/2020 20:55:24 ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_createdOn]  DEFAULT (getdate()) FOR [createdOn]
GO
/****** Object:  Default [DF_Users_phone]    Script Date: 02/23/2020 20:55:24 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_phone]  DEFAULT ((9874563210.)) FOR [phone]
GO
/****** Object:  Default [DF_Users_createdon]    Script Date: 02/23/2020 20:55:24 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_createdon]  DEFAULT (getdate()) FOR [createdOn]
GO
