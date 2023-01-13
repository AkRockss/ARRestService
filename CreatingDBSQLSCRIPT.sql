SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[productId] [int] NOT NULL,
	[productBrand] [nvarchar](50) NULL,
	[productName] [nvarchar](50) NULL,
	[productDescription] [nvarchar](MAX) NULL,
	[organic] [bit] NULL,
	[noeglemaerket] [bit] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[recipePictures]    Script Date: 29/11/2022 12.03.04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[recipePictures](
	[recipePicturesId] [int] NOT NULL,
	[URL] [nvarchar](MAX) NULL,
	[recipiesId] [nvarchar](50) NULL,
 CONSTRAINT [PK_recipePicture] PRIMARY KEY CLUSTERED 
(
	[recipePicturesId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[Recipies]    Script Date: 29/11/2022 12.03.39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Recipies](
	[RecipeId] [int] NOT NULL,
	[RecipeTitle] [nvarchar](50) NULL,
	[RecipeDescription] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_Recipies] PRIMARY KEY CLUSTERED 
(
	[RecipeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[RecipiesProducts]    Script Date: 29/11/2022 12.04.17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RecipiesProducts](
	[recipiesProductsId] [int] NOT NULL,
	[recipeId]  [int]  NULL,
	[productId] [int]  NULL,
 CONSTRAINT [PK_Recipies_Products] PRIMARY KEY CLUSTERED 
(
	[recipiesProductsId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Users]    Script Date: 29/11/2022 12.04.40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[userId] [int] NOT NULL,
	[firstName] [nvarchar](50) NULL,
[lastName] [nvarchar](50) NULL,
[country] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[UsersRecipies]    Script Date: 29/11/2022 12.05.22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsersRecipies](
	[usersRecipiesId] [int] NOT NULL,
	[userId] [nvarchar](50) NULL,
	[recipieId] [nvarchar](50) NULL,
 CONSTRAINT [PK_UsersRecipies] PRIMARY KEY CLUSTERED 
(
	[usersRecipiesId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


