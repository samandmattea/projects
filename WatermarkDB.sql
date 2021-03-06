USE [master]
GO
/****** Object:  Database [Watermark]    Script Date: 9/7/2016 5:00:52 PM ******/
CREATE DATABASE [Watermark]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Watermark', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\Watermark.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Watermark_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\Watermark_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Watermark] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Watermark].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Watermark] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Watermark] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Watermark] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Watermark] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Watermark] SET ARITHABORT OFF 
GO
ALTER DATABASE [Watermark] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Watermark] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Watermark] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Watermark] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Watermark] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Watermark] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Watermark] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Watermark] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Watermark] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Watermark] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Watermark] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Watermark] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Watermark] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Watermark] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Watermark] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Watermark] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Watermark] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Watermark] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Watermark] SET  MULTI_USER 
GO
ALTER DATABASE [Watermark] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Watermark] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Watermark] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Watermark] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Watermark] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Watermark] SET QUERY_STORE = OFF
GO
USE [Watermark]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Watermark]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Beers]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beers](
	[BeerId] [int] IDENTITY(1,1) NOT NULL,
	[BeerName] [varchar](50) NOT NULL,
	[ABV] [decimal](3, 1) NOT NULL,
	[IBU] [int] NULL,
	[ReleaseDate] [date] NULL,
	[BeerDescription] [text] NULL,
	[Season] [varchar](50) NULL,
	[IsAvailable] [bit] NOT NULL,
	[IsFlagship] [bit] NOT NULL,
	[UntappdRating] [decimal](3, 2) NULL,
	[ImgPath] [text] NULL,
	[SeriesId] [int] NULL,
	[StyleId] [int] NOT NULL,
	[CollaboratorId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogEntries]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogEntries](
	[EntryId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[BlogTitle] [text] NOT NULL,
	[BlogBody] [text] NOT NULL,
	[EventId] [int] NULL,
	[BeerId] [int] NULL,
	[BlogPostDate] [date] NOT NULL,
	[BlogExpireDate] [date] NULL,
	[IsApproved] [bit] NOT NULL,
 CONSTRAINT [PK_BlogEntries] PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Collaborators]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collaborators](
	[CollaboratorId] [int] IDENTITY(1,1) NOT NULL,
	[CollaboratorName] [varchar](50) NULL,
	[ContactId] [int] NULL,
	[CollaboratorDescription] [text] NULL,
	[CollaboratorImgPath] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactForms]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactForms](
	[ContactFormId] [int] IDENTITY(1,1) NOT NULL,
	[ContactFormName] [varchar](40) NOT NULL,
	[ContactFormEmail] [varchar](30) NOT NULL,
	[ContactFormMessage] [text] NOT NULL,
	[DateSent] [datetime] NOT NULL,
	[IsAnswered] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[StreetAddress] [varchar](100) NULL,
	[City] [varchar](30) NULL,
	[State] [varchar](15) NULL,
	[ZipCode] [varchar](10) NULL,
	[Phone] [varchar](15) NULL,
	[Email] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [varchar](50) NOT NULL,
	[EventDescription] [text] NOT NULL,
	[EventStartDate] [datetime] NOT NULL,
	[EventEndDate] [datetime] NOT NULL,
	[VenueId] [int] NULL,
	[EventImgPath] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [text] NOT NULL,
	[ImageCaption] [text] NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Series]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Series](
	[SeriesId] [int] IDENTITY(1,1) NOT NULL,
	[SeriesName] [varchar](50) NOT NULL,
	[SeriesDescription] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StaticPages]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaticPages](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Body] [text] NOT NULL,
	[DateCreated] [date] NOT NULL,
	[DateUpdated] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Styles]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Styles](
	[StyleId] [int] IDENTITY(1,1) NOT NULL,
	[StyleName] [varchar](50) NOT NULL,
	[StyleDescription] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags_Blogs]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags_Blogs](
	[BridgeId] [int] IDENTITY(1,1) NOT NULL,
	[TagId] [int] NOT NULL,
	[EntryId] [int] NOT NULL,
 CONSTRAINT [PK_Tags_Blogs] PRIMARY KEY CLUSTERED 
(
	[BridgeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags_Images]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags_Images](
	[BridgeId] [int] IDENTITY(1,1) NOT NULL,
	[TagId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
 CONSTRAINT [PK_Tags_Images] PRIMARY KEY CLUSTERED 
(
	[BridgeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[AspUserId] [nvarchar](128) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[JobTitle] [varchar](50) NULL,
	[AccessLevel] [int] NOT NULL,
	[ContactId] [int] NOT NULL,
	[UserImgPath] [text] NULL,
	[Bio] [text] NULL,
	[IsEmployee] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Venues]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venues](
	[VenueId] [int] IDENTITY(1,1) NOT NULL,
	[VenueName] [varchar](50) NOT NULL,
	[ContactId] [int] NOT NULL,
	[VenueImgPath] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Contributor')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Writer')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2c605728-2405-432b-8cf1-f65468b13467', N'0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3ed3eb36-e23e-4588-b541-a9ab5fd6cd31', N'0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'89afff35-e3b2-4016-aef5-e417f9b2e806', N'0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8a11fb13-b2f7-43ff-89ba-e49e1258d4eb', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a0fdcaad-2d24-4402-a2e5-acb1c05bed21', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'be7444e6-db40-4f46-9ca0-3bed4d1bc7e3', N'0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd4db7a00-027e-402a-a089-f7303e741f35', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'db23f1ca-0b6a-42f6-85ed-7faf1395169d', N'0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dd7a4693-0249-4428-a000-89877bf7680c', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fa9411e5-01e0-4ded-82e3-281fc11eab5f', N'1')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'15aa3fd4-754d-4116-959d-4a368cf47bfa', N'delbrocco.sam@gmail.com', 0, N'AFNGFQ6ETqEA3YbnRV9mHAWUENQTtknwUBXiRxf9ztmbqn7VogOK5/S8w7s/d1dUpA==', N'ae7e0b69-4365-41ef-8ab2-4e14fd0cebcd', NULL, 0, 0, NULL, 1, 0, N'Sdelbrocco')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2c605728-2405-432b-8cf1-f65468b13467', N'clapper.randy@gmail.com', 0, N'APnNapFt5+Ro2s+Wcd1Rt0uw+Q6PVxJ/L/hCndlbcXgjYsp2q2T9Ql5Ctx1jZVUCEg==', N'990b7107-cb05-475c-b5b5-768a325c0eb1', NULL, 0, 0, NULL, 1, 0, N'clapper.randall')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3ed3eb36-e23e-4588-b541-a9ab5fd6cd31', N'sammatteajohn@gmail.com', 0, N'AAffHbO8Oey8+z5jvHUJYU40mz9ppmgs1bgAtLFOiDQRubB/GMiA+9NF5N3aAphYLA==', N'db0eeeb9-c3ea-4d78-81a4-b0713f15f555', NULL, 0, 0, NULL, 1, 0, N'SamMatteaJohn')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'89afff35-e3b2-4016-aef5-e417f9b2e806', N'samboobear@sammie.com', 0, N'ABR/J1YDNPJwFW/8LVg0GOnaYuYR9Dn4iFtZSI35KgOwkpSbcjZHCQAkSaVudwDX6w==', N'ce9d7e25-94c0-4bd6-a4b4-e790856a9aa8', NULL, 0, 0, NULL, 1, 0, N'SBBear')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8a11fb13-b2f7-43ff-89ba-e49e1258d4eb', N'mattea@watermarkcoding.com', 0, N'AG3Kc/OBrYJGD+RKgyzrmgS6mpeONuMIRPurFmj74yYGgKS6LOZ9DMGa1rxFobtN7g==', N'2c7fbbc8-7afb-47f9-82bd-ca304f4cff7b', NULL, 0, 0, NULL, 1, 0, N'Mattea')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a0fdcaad-2d24-4402-a2e5-acb1c05bed21', N'victor@watermarkcoding.com', 0, N'AAR5pz6ie1l/TrLL5u0ZMavoFIDNjJw+QdD41ubG5lvhNH/WfaoAdOwgxjO5VxM4fw==', N'47c4c686-d069-42a3-8c7a-1a3e8da23ce3', NULL, 0, 0, NULL, 1, 0, N'Victor')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'be7444e6-db40-4f46-9ca0-3bed4d1bc7e3', N'sam@watermarkcoding.com', 0, N'ADgY/afeSAA0fAkh1XeApp0dT/hhFJamdIRzKAyRlmpcqdoK1Pj/sHWgM7HfLfC3Hg==', N'1fe84ddc-20d9-45f5-89fd-3848ac79e845', NULL, 0, 0, NULL, 1, 0, N'Sam')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd4db7a00-027e-402a-a089-f7303e741f35', N'john@watermarkcoding.com', 0, N'AIdei8RsB1RDbsUKZmq5p6hmHaK2cZb/dghYcYpkCDxW2TcHyGvfcLQYwlAOIZVSYQ==', N'39fc9550-e7ca-4532-bf26-2f8110813e1b', NULL, 0, 0, NULL, 1, 0, N'John')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'db23f1ca-0b6a-42f6-85ed-7faf1395169d', N'sboobear@sammie.com', 0, N'ALGLjQyspQHwQulT0xqcMOfKMxHrnfvNS+913TtcsuwGGdkD72u0ZpX7rjJzH60o3g==', N'01f6a543-0b6c-4c58-b456-c06282fcb173', NULL, 0, 0, NULL, 1, 0, N'SBB')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dd7a4693-0249-4428-a000-89877bf7680c', N'delbroc.sam@gmail.com', 0, N'ALnhXAp3m6skA/xpbqHu2SKYr4GsaNflitseqk/yiTctQRcFRrXw/88Dv6N4Rh1b8g==', N'caee6edb-e744-414c-9629-64aea1d13b3c', NULL, 0, 0, NULL, 1, 0, N'delbroc')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fa9411e5-01e0-4ded-82e3-281fc11eab5f', N'putelsky.V@gmail.com', 0, N'AFbxtYE87tMF3Lyji2ymH8GDBAkxbRAqUZ2UIBXZP+OlDT5Oj4c2OzOS2G8zfzgRgw==', N'f9b739a1-eb66-4e04-880c-25323e1ed973', NULL, 0, 0, NULL, 1, 0, N'VictorP')
SET IDENTITY_INSERT [dbo].[Beers] ON 

INSERT [dbo].[Beers] ([BeerId], [BeerName], [ABV], [IBU], [ReleaseDate], [BeerDescription], [Season], [IsAvailable], [IsFlagship], [UntappdRating], [ImgPath], [SeriesId], [StyleId], [CollaboratorId]) VALUES (1, N'Leisure Ale', CAST(4.7 AS Decimal(3, 1)), NULL, CAST(N'2016-08-17' AS Date), N'Nothin'' snooty. Just Beer', NULL, 1, 1, NULL, N'https://untappd.akamaized.net/site/beer_logos/beer-1648527_d1ee3_sm.jpeg', 1, 1, NULL)
INSERT [dbo].[Beers] ([BeerId], [BeerName], [ABV], [IBU], [ReleaseDate], [BeerDescription], [Season], [IsAvailable], [IsFlagship], [UntappdRating], [ImgPath], [SeriesId], [StyleId], [CollaboratorId]) VALUES (3, N'Lemon Zesty Time', CAST(5.9 AS Decimal(3, 1)), 26, CAST(N'2016-02-12' AS Date), N'Zesty Beer', N'Summer', 1, 0, NULL, N'https://untappd.akamaized.net/site/beer_logos/beer-1648561_f6032_sm.jpeg', 1, 1, NULL)
INSERT [dbo].[Beers] ([BeerId], [BeerName], [ABV], [IBU], [ReleaseDate], [BeerDescription], [Season], [IsAvailable], [IsFlagship], [UntappdRating], [ImgPath], [SeriesId], [StyleId], [CollaboratorId]) VALUES (4, N'Homage', CAST(5.2 AS Decimal(3, 1)), 12, CAST(N'2016-07-30' AS Date), N'Classic  German Beer', NULL, 0, 0, NULL, N'https://untappd.akamaized.net/site/beer_logos/beer-1647159_ae13e_sm.jpeg', 1, 1, NULL)
INSERT [dbo].[Beers] ([BeerId], [BeerName], [ABV], [IBU], [ReleaseDate], [BeerDescription], [Season], [IsAvailable], [IsFlagship], [UntappdRating], [ImgPath], [SeriesId], [StyleId], [CollaboratorId]) VALUES (5, N'Emerald Swallowtail', CAST(5.0 AS Decimal(3, 1)), 47, CAST(N'2016-08-20' AS Date), N'Coming Soon - American IPA', NULL, 0, 0, NULL, N'https://untappd.akamaized.net/site/beer_logos/beer-1664579_d9808_sm.jpeg', 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Beers] OFF
SET IDENTITY_INSERT [dbo].[BlogEntries] ON 

INSERT [dbo].[BlogEntries] ([EntryId], [UserId], [BlogTitle], [BlogBody], [EventId], [BeerId], [BlogPostDate], [BlogExpireDate], [IsApproved]) VALUES (9, 5, N'Capstone', N'<p>This is so much fun</p>', NULL, NULL, CAST(N'2016-08-18' AS Date), CAST(N'2016-08-31' AS Date), 1)
INSERT [dbo].[BlogEntries] ([EntryId], [UserId], [BlogTitle], [BlogBody], [EventId], [BeerId], [BlogPostDate], [BlogExpireDate], [IsApproved]) VALUES (10, 6, N'Mastery', N'<p>This was so much fun</p>', NULL, NULL, CAST(N'2016-08-18' AS Date), CAST(N'2016-08-27' AS Date), 1)
INSERT [dbo].[BlogEntries] ([EntryId], [UserId], [BlogTitle], [BlogBody], [EventId], [BeerId], [BlogPostDate], [BlogExpireDate], [IsApproved]) VALUES (11, 6, N'TEST QUEUE', N'<p>TESTING</p>', NULL, NULL, CAST(N'2016-08-18' AS Date), CAST(N'2016-08-27' AS Date), 0)
INSERT [dbo].[BlogEntries] ([EntryId], [UserId], [BlogTitle], [BlogBody], [EventId], [BeerId], [BlogPostDate], [BlogExpireDate], [IsApproved]) VALUES (12, 5, N'test not queue', N'<p>not queue</p>', NULL, NULL, CAST(N'2016-08-18' AS Date), CAST(N'2016-08-25' AS Date), 1)
INSERT [dbo].[BlogEntries] ([EntryId], [UserId], [BlogTitle], [BlogBody], [EventId], [BeerId], [BlogPostDate], [BlogExpireDate], [IsApproved]) VALUES (13, 6, N'Blog post', N'<p>dsgahilgoh</p>', NULL, NULL, CAST(N'2016-08-18' AS Date), CAST(N'2016-08-26' AS Date), 0)
SET IDENTITY_INSERT [dbo].[BlogEntries] OFF
SET IDENTITY_INSERT [dbo].[Collaborators] ON 

INSERT [dbo].[Collaborators] ([CollaboratorId], [CollaboratorName], [ContactId], [CollaboratorDescription], [CollaboratorImgPath]) VALUES (4, N'Starbucks', 13, N'sam worked here', NULL)
SET IDENTITY_INSERT [dbo].[Collaborators] OFF
SET IDENTITY_INSERT [dbo].[ContactForms] ON 

INSERT [dbo].[ContactForms] ([ContactFormId], [ContactFormName], [ContactFormEmail], [ContactFormMessage], [DateSent], [IsAnswered]) VALUES (1, N'test', N'test@test.com', N'shtehaegfgerrg', CAST(N'2016-08-18T09:17:51.113' AS DateTime), 1)
INSERT [dbo].[ContactForms] ([ContactFormId], [ContactFormName], [ContactFormEmail], [ContactFormMessage], [DateSent], [IsAnswered]) VALUES (2, N'Randall Clapper', N'theclap@randall.com', N'Your beer sucks!!! I want a refund!!!', CAST(N'2016-08-18T09:37:14.287' AS DateTime), 1)
INSERT [dbo].[ContactForms] ([ContactFormId], [ContactFormName], [ContactFormEmail], [ContactFormMessage], [DateSent], [IsAnswered]) VALUES (3, N'John', N'john@watermarkcoding.com', N'are you open?', CAST(N'2016-08-18T11:51:26.020' AS DateTime), 0)
INSERT [dbo].[ContactForms] ([ContactFormId], [ContactFormName], [ContactFormEmail], [ContactFormMessage], [DateSent], [IsAnswered]) VALUES (1001, N'Alex', N'alex@email.com', N'Puppies want attention', CAST(N'2016-09-01T17:24:23.567' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[ContactForms] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (4, N'Coyote Ugl', N'Stevensville', N'Michigan', N'45678', N'2694201234', N'samboobear@sammie.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (27, N'6383  Stil', N'Oxford', N'OH', N'45056', N'5134614273', N'mattea@watermarkcoding.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (28, N'2121 S Cle', N'St Joseph', N'MI', N'49085', N'2694201234', N'john@watermarkcoding.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (6, N'12 Waterma', N'Stevensville', N'Michigan', N'45678', N'2694201234', N'starbucks@starbucks.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (7, N'12 Waterma', N'Stevensville', N'Michigan', N'45678', N'2694201234', N'starbucks@starbucks.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (29, N'526 S Main', N'Akron', N'OH', N'44311', N'8555999584', N'victor@watermarkcoding.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (8, N'12 Waterma', N'Stevensville', N'Michigan', N'45678', N'2694201234', N'starbucks@starbucks.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (9, N'12 Waterma', N'Stevensville', N'Michigan', N'45678', N'2694201234', N'starbucks@starbucks.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (10, N'2121 S Cle', N'St Joseph', N'MI', N'49085', N'2699831223', N'starbucks@starbucks.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (14, N'2121 S Cle', N'St Joseph', N'MI', N'49085', N'2699831223', N'starbucks@starbucks.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (12, N'2121 S Cle', N'St Joseph', N'MI', N'49085', N'2699831223', N'starbucks@starbucks.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (13, N'2121 S Cle', N'St Joseph', N'MI', N'49085', N'2699831223', N'starbucks@starbucks.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (16, N'526 S Main', N'Akron', N'OH', N'44311', N'(855) 599-9584', N'coding@thesoftwareguild.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (17, N'526 S Main', N'Akron', N'OH', N'44311', N'(855) 599-9584', N'coding@thesoftwareguild.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (20, N'526 S Main', N'Akron', N'OH', N'44311', N'8555999584', N'coding@thesoftwareguild.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (21, N'526 S Main', N'Akron', N'OH', N'44311', N'8555999584', N'coding@thesoftwareguild.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (26, N'2121 S Cle', N'St Joseph', N'MI', N'49085', N'2699831223', N'sam@watermarkcoding.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (18, N'526 S Main', N'Akron', N'OH', N'44311', N'8555999584', N'coding@thesoftwareguild.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (19, N'526 S Main', N'Akron', N'OH', N'44311', N'8555999584', N'coding@thesoftwareguild.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (22, N'207 S Main', N'Akron', N'OH', N'44308', N'(330) 252-5128', N'lockview@akron.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (23, N'207 S Main', N'Akron', N'OH', N'44308', N'(330) 252-5128', N'lockview@akron.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (24, N'trestg', N'wthwe', N'trhw', N'123435', N'2699831223', N'starbucks@starbucks.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (30, N'445 Howe A', N'Cuyahoga Falls', N'OH', N'44221', N'212-212-1221', N'bestbuy@bestbuy.com')
INSERT [dbo].[Contacts] ([ContactId], [StreetAddress], [City], [State], [ZipCode], [Phone], [Email]) VALUES (31, N'445 Howe A', N'Cuyahoga Falls', N'OH', N'44221', N'212-212-1221', N'bestbuy@bestbuy.com')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [EventName], [EventDescription], [EventStartDate], [EventEndDate], [VenueId], [EventImgPath]) VALUES (1, N'Capstone Presentation', N'Presenting the Watermark Brewery website', CAST(N'2016-08-18T00:00:00.000' AS DateTime), CAST(N'2016-08-18T00:00:00.000' AS DateTime), 3, NULL)
INSERT [dbo].[Events] ([EventId], [EventName], [EventDescription], [EventStartDate], [EventEndDate], [VenueId], [EventImgPath]) VALUES (3, N'Drinking Beer', N'Celebrating Graduation', CAST(N'2016-08-18T00:00:00.000' AS DateTime), CAST(N'2016-08-18T00:00:00.000' AS DateTime), 4, NULL)
INSERT [dbo].[Events] ([EventId], [EventName], [EventDescription], [EventStartDate], [EventEndDate], [VenueId], [EventImgPath]) VALUES (4, N'Going to best buy', N'with chelsea', CAST(N'2016-08-21T00:00:00.000' AS DateTime), CAST(N'2016-08-21T00:00:00.000' AS DateTime), 6, NULL)
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[Series] ON 

INSERT [dbo].[Series] ([SeriesId], [SeriesName], [SeriesDescription]) VALUES (1, N'Watermark', N'Great Beer')
SET IDENTITY_INSERT [dbo].[Series] OFF
SET IDENTITY_INSERT [dbo].[Styles] ON 

INSERT [dbo].[Styles] ([StyleId], [StyleName], [StyleDescription]) VALUES (1, N'Pale Ale', N'Classic Beer')
INSERT [dbo].[Styles] ([StyleId], [StyleName], [StyleDescription]) VALUES (3, N'Imperial Double Triple IPA XXXTreme', N'It will melt your face')
SET IDENTITY_INSERT [dbo].[Styles] OFF
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (1, N'test')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (2, N'tags')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (3, N'tag')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (4, N'tag2')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (5, N'blog')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (6, N'somuchfun')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (7, N'mastery')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (8, N'new')
SET IDENTITY_INSERT [dbo].[Tags] OFF
SET IDENTITY_INSERT [dbo].[Tags_Blogs] ON 

INSERT [dbo].[Tags_Blogs] ([BridgeId], [TagId], [EntryId]) VALUES (11, 8, 9)
SET IDENTITY_INSERT [dbo].[Tags_Blogs] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [AspUserId], [FirstName], [LastName], [JobTitle], [AccessLevel], [ContactId], [UserImgPath], [Bio], [IsEmployee]) VALUES (6, N'8a11fb13-b2f7-43ff-89ba-e49e1258d4eb', N'Mattea', N'Azara', N'Brewer', 2, 27, N'https://hd.unsplash.com/photo-1444068700300-d6ef2904d5e4
', N'gfjsstyj', 1)
INSERT [dbo].[Users] ([UserId], [AspUserId], [FirstName], [LastName], [JobTitle], [AccessLevel], [ContactId], [UserImgPath], [Bio], [IsEmployee]) VALUES (5, N'be7444e6-db40-4f46-9ca0-3bed4d1bc7e3', N'Sam', N'DelBrocco', N'Bartender', 0, 26, N'https://hd.unsplash.com/reserve/sozGYg0tQdSmsUkoPhvt_12.jpg', N'sryjuyk', 1)
INSERT [dbo].[Users] ([UserId], [AspUserId], [FirstName], [LastName], [JobTitle], [AccessLevel], [ContactId], [UserImgPath], [Bio], [IsEmployee]) VALUES (7, N'd4db7a00-027e-402a-a089-f7303e741f35', N'John', N'Kachurek', N'Chief Beer Officer', 1, 28, N'https://hd.unsplash.com/photo-1445283142063-f4802ea5aac3', N'gjhsdtuk', 1)
INSERT [dbo].[Users] ([UserId], [AspUserId], [FirstName], [LastName], [JobTitle], [AccessLevel], [ContactId], [UserImgPath], [Bio], [IsEmployee]) VALUES (8, N'a0fdcaad-2d24-4402-a2e5-acb1c05bed21', N'Victor', N'Pudelski', N'Baseball Watcher', 2, 29, N'https://hd.unsplash.com/photo-1420578509940-73e9f7232eae', N'gsnjtkj', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Venues] ON 

INSERT [dbo].[Venues] ([VenueId], [VenueName], [ContactId], [VenueImgPath]) VALUES (4, N'Lockview', 23, NULL)
INSERT [dbo].[Venues] ([VenueId], [VenueName], [ContactId], [VenueImgPath]) VALUES (3, N'The Software Guild', 21, NULL)
INSERT [dbo].[Venues] ([VenueId], [VenueName], [ContactId], [VenueImgPath]) VALUES (6, N'Best Buy', 31, NULL)
SET IDENTITY_INSERT [dbo].[Venues] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 9/7/2016 5:00:52 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 9/7/2016 5:00:52 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 9/7/2016 5:00:52 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 9/7/2016 5:00:52 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 9/7/2016 5:00:52 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 9/7/2016 5:00:52 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Tags_Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Tags_Blogs_BlogEntries] FOREIGN KEY([EntryId])
REFERENCES [dbo].[BlogEntries] ([EntryId])
GO
ALTER TABLE [dbo].[Tags_Blogs] CHECK CONSTRAINT [FK_Tags_Blogs_BlogEntries]
GO
ALTER TABLE [dbo].[Tags_Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Tags_Blogs_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[Tags_Blogs] CHECK CONSTRAINT [FK_Tags_Blogs_Tags]
GO
ALTER TABLE [dbo].[Tags_Images]  WITH CHECK ADD  CONSTRAINT [FK_Tags_Images_Images] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([ImageId])
GO
ALTER TABLE [dbo].[Tags_Images] CHECK CONSTRAINT [FK_Tags_Images_Images]
GO
ALTER TABLE [dbo].[Tags_Images]  WITH CHECK ADD  CONSTRAINT [FK_Tags_Images_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[Tags_Images] CHECK CONSTRAINT [FK_Tags_Images_Tags]
GO
/****** Object:  StoredProcedure [dbo].[AddBlogEntry]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddBlogEntry]
(
	@UserId int,
	@BlogTitle text,
	@BlogBody text,
	@EventId int,
	@BeerId int,
	@BlogPostDate date,
	@BlogExpireDate date,
	@IsApproved bit
)
AS
INSERT INTO BlogEntries (UserId, BlogTitle, BlogBody, EventId, BeerId, BlogPostDate, BlogExpireDate, IsApproved)
VALUES(@UserId, @BlogTitle, @BlogBody, @EventId, @BeerId, @BlogPostDate, @BlogExpireDate, @IsApproved)







GO
/****** Object:  StoredProcedure [dbo].[AddCollaborator]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCollaborator]
(
	@CollaboratorName varchar(50),
	@ContactId int,
	@CollaboratorDescription text,
	@CollaboratorImgPath text
)
AS
INSERT INTO Collaborators(CollaboratorName, ContactId, CollaboratorDescription, CollaboratorImgPath)
VALUES(@CollaboratorName, @ContactId, @CollaboratorDescription, @CollaboratorImgPath)

SELECT TOP(1) *
FROM Collaborators COLL
	LEFT OUTER JOIN Contacts CONT
	ON COLL.ContactId = CONT.ContactId
ORDER BY CollaboratorId DESC







GO
/****** Object:  StoredProcedure [dbo].[AddContact]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddContact]
(
	@StreetAddress varchar(10),
	@City varchar(30),
	@State varchar(15),
	@ZipCode varchar(10),
	@Phone varchar(15),
	@Email varchar(50)
)
AS
INSERT INTO Contacts(StreetAddress, City, [State], ZipCode, Phone, Email)
VALUES(@StreetAddress, @City, @State, @ZipCode, @Phone, @Email)

SELECT TOP(1) * 
FROM Contacts
ORDER BY ContactId DESC






GO
/****** Object:  StoredProcedure [dbo].[AddContactForm]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddContactForm]
	-- Add the parameters for the stored procedure here
	@ContactFormName varchar(40),
	@ContactFormMessage text,
	@ContactFormEmail varchar(30),
	@DateSent datetime,
	@IsAnswered bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO ContactForms(ContactFormName, ContactFormEmail, ContactFormMessage, DateSent, IsAnswered)
	VALUES(@ContactFormName, @ContactFormEmail, @ContactFormMessage, @DateSent, @IsAnswered)
END


GO
/****** Object:  StoredProcedure [dbo].[AddEvent]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEvent]
(
	@EventName varchar(50), 
	@EventDescription text, 
	@EventStartDate datetime, 
	@EventEndDate datetime, 
	@EventImgPath text,
	@VenueId int
)
AS
	INSERT INTO [Events](EventName, EventDescription, EventStartDate, EventEndDate, VenueId, EventImgPath)
	VALUES(@EventName, @EventDescription, @EventStartDate, @EventEndDate, @VenueId, @EventImgPath)



GO
/****** Object:  StoredProcedure [dbo].[AddImage]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddImage]
(
	@ImagePath text,
	@ImageCaption text
)
AS
INSERT INTO Images(ImagePath, ImageCaption)
VALUES(@ImagePath, @ImageCaption)






GO
/****** Object:  StoredProcedure [dbo].[AddNewBeer]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewBeer]
(
	@Name varchar(50),
	@ABV decimal(3,1),
	@IBU int,
	@ReleaseDate date, 
	@Description text,
	@Season varchar(50),
	@IsAvailable bit,
	@IsFlagship bit,
	@UntappdRating decimal(3,2),
	@ImgPath text,
	@SeriesId int,
	@StyleId int,
	@CollaboratorId int
)
AS
	INSERT INTO Beers(BeerName, ABV, IBU, ReleaseDate, BeerDescription, Season, IsAvailable, IsFlagship, UntappdRating,  ImgPath, SeriesId, StyleId, CollaboratorId)
	VALUES (@Name, @ABV, @IBU, @ReleaseDate, @Description, @Season, @IsAvailable, @IsFlagship, @UntappdRating, @ImgPath, @SeriesId, @StyleId, @CollaboratorId)





GO
/****** Object:  StoredProcedure [dbo].[AddSeries]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSeries]
(
	@SeriesName varchar(50),
	@SeriesDescription text
)
AS
	INSERT INTO Series(SeriesName, SeriesDescription)
	VALUES(@SeriesName, @SeriesDescription)

	SELECT TOP(1) *
	FROM Series
	ORDER BY SeriesId DESC







GO
/****** Object:  StoredProcedure [dbo].[AddStaticPage]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStaticPage]
(
	@Title varchar(100),
	@Body text,
	@DateCreated date,
	@DateUpdated date
)
AS 
	INSERT INTO StaticPages (Title, Body, DateCreated, DateUpdated)
	VALUES (@Title, @Body, @DateCreated, @DateUpdated)





GO
/****** Object:  StoredProcedure [dbo].[AddStyle]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStyle]
	(
		@StyleName Varchar(50),
		@StyleDescription text
	)
AS
INSERT INTO Styles(StyleName, StyleDescription)
VALUES (@StyleName, @StyleDescription)

SELECT TOP(1) *
FROM Styles
ORDER BY StyleId DESC







GO
/****** Object:  StoredProcedure [dbo].[AddTag]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddTag]
(
	@TagName varchar(50)
)
AS 
	INSERT INTO Tags(TagName)
	VALUES(@TagName)

	SELECT *
	FROM Tags
	WHERE TagId = Cast(Scope_Identity() as Int)




GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
(
	@AspUserId nvarchar(128),
	@FirstName varchar(25),
	@LastName varchar(25),
	@JobTitle varchar(50),
	@AccessLevel int,
	@ContactId int,
	@UserImgPath text,
	@Bio text,
	@IsEmployee bit
)
AS
	INSERT INTO Users (AspUserId, FirstName, LastName, JobTitle, AccessLevel, ContactId, UserImgPath, Bio, IsEmployee)
	VALUES (@AspUserId, @FirstName, @LastName, @JobTitle, @AccessLevel, @ContactId, @UserImgPath, @Bio, @IsEmployee)





GO
/****** Object:  StoredProcedure [dbo].[AddUserRole]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserRole]
@UserId nvarchar(50),
@RoleId nvarchar(10)
AS
INSERT INTO dbo.AspNetUserRoles
VALUES (@UserId, @RoleId)



GO
/****** Object:  StoredProcedure [dbo].[AddVenue]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddVenue]
(
	@VenueName varchar(50),
	@ContactId int,
	@VenueImgPath text
)
AS
	INSERT INTO Venues (VenueName, ContactId, VenueImgPath)
	VALUES(@VenueName, @ContactId, @VenueImgPath)

	SELECT C.*, V.VenueId, V.VenueImgPath, V.VenueName
	FROM Venues V
		INNER JOIN Contacts C
		ON V.ContactId = C.ContactId
	WHERE VenueId = Cast(Scope_Identity() as Int)






GO
/****** Object:  StoredProcedure [dbo].[DeleteBeer]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBeer]
(
	@BeerId int
) AS

DELETE Beers 
WHERE BeerId = @BeerId








GO
/****** Object:  StoredProcedure [dbo].[DeleteBlogEntry]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBlogEntry]
(
	@EntryId int
)
AS
	DELETE Tags_Blogs
	WHERE EntryId = @EntryId
	
	DELETE BlogEntries
	WHERE EntryId = @EntryId

	








GO
/****** Object:  StoredProcedure [dbo].[DeleteCollaborator]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCollaborator]
(
	@CollaboratorId int
)
AS
Delete Collaborators
	WHERE CollaboratorId = @CollaboratorId







GO
/****** Object:  StoredProcedure [dbo].[DeleteContact]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteContact]
(
	@ContactId int
)
AS
DELETE Contacts
WHERE ContactId = @ContactId






GO
/****** Object:  StoredProcedure [dbo].[DeleteEvent]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEvent]
(
	@EventId int
)
AS
	Delete [Events]
	WHERE EventId = @EventId







GO
/****** Object:  StoredProcedure [dbo].[DeleteImage]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteImage]
(
	@ImageId int
)
AS
DELETE Images
WHERE ImageId = @ImageId






GO
/****** Object:  StoredProcedure [dbo].[DeleteSeries]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSeries]
(
	@SeriesId int
)
AS
	DELETE Series 
	WHERE SeriesId = @SeriesId







GO
/****** Object:  StoredProcedure [dbo].[DeleteStaticPage]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStaticPage]
(
	@id int
)
AS 
	DELETE StaticPages
	WHERE PageId = @id





GO
/****** Object:  StoredProcedure [dbo].[DeleteStyle]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStyle]
(
	@StyleId int
)
AS
DELETE Styles
WHERE StyleId = @StyleId






GO
/****** Object:  StoredProcedure [dbo].[DeleteTag]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTag]
(
	@TagId int
)
AS 
	DELETE Tags
	WHERE TagId = @TagId





GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
(
	@id int
)
AS 
	DELETE AspNetUsers 
	WHERE Id = (SELECT TOP(1) u.AspUserId
				FROM Users U
				WHERE U.UserId = @id)

	DELETE Users
	WHERE UserId = @id





GO
/****** Object:  StoredProcedure [dbo].[DeleteVenue]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteVenue]
(
	@VenueId int
)
AS
	DELETE Venues
	WHERE VenueId = @VenueId







GO
/****** Object:  StoredProcedure [dbo].[EditBeer]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditBeer]
(
	@BeerId int,
	@BeerName varchar(50),
	@ABV decimal(3,1),
	@IBU int,
	@ReleaseDate date,
	@BeerDescription text,
	@Season varchar(50),
	@IsAvailable bit,
	@IsFlagship bit,
	@UntappdRating decimal(3,2),
	@ImgPath text,
	@SeriesId int,
	@StyleId int,
	@CollaboratorId int
)
AS
	UPDATE Beers
		SET BeerName = @BeerName,
			ABV = @ABV,
			IBU = @IBU,
			ReleaseDate = @ReleaseDate,
			BeerDescription = @BeerDescription,
			Season = @Season,
			IsAvailable = @IsAvailable,
			IsFlagship = @IsFlagship,
			UntappdRating = @UntappdRating,
			ImgPath = @ImgPath,
			SeriesId = @SeriesId,
			StyleId = @StyleId,
			CollaboratorId = @CollaboratorId
		WHERE BeerId = @BeerId


GO
/****** Object:  StoredProcedure [dbo].[EditBlogEntry]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditBlogEntry]
(
	@EntryId int,
	@UserId int,
	@BlogTitle text,
	@BlogBody text,
	@EventId int,
	@BeerId int,
	@BlogPostDate date,
	@BlogExpireDate date
)
AS
UPDATE BlogEntries
	SET UserId = @UserId,
		BlogTitle = @BlogTitle,
		BlogBody = @BlogBody,
		EventId = @EventId,
		BeerId = @BeerId,
		BlogPostDate = @BlogPostDate,
		BlogExpireDate = @BlogExpireDate
	WHERE EntryId = @EntryId







GO
/****** Object:  StoredProcedure [dbo].[EditCollaborator]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditCollaborator]
(
	@CollaboratorId int,
	@CollaboratorName varchar(50),
	@ContactId int,
	@CollaboratorDescription text,
	@CollaboratorImgPath text
)
AS
UPDATE Collaborators
	SET CollaboratorName = @CollaboratorName,
		CollaboratorDescription = @CollaboratorDescription,
		ContactId = @ContactId,
		CollaboratorImgPath = @CollaboratorImgPath
	WHERE CollaboratorId = @CollaboratorId







GO
/****** Object:  StoredProcedure [dbo].[EditContact]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditContact]
(
	@ContactId int,
	@StreetAddress varchar(10),
	@City varchar(30),
	@State varchar(15),
	@ZipCode varchar(10),
	@Phone varchar(15),
	@Email varchar(50)
)
AS
UPDATE [Contacts]
	SET StreetAddress = @StreetAddress,
		City = @City,
		[State] = @State,
		ZipCode = @ZipCode,
		Phone = @Phone,
		Email = @Email
	WHERE ContactId = @ContactId






GO
/****** Object:  StoredProcedure [dbo].[EditContactForm]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditContactForm]
	-- Add the parameters for the stored procedure here
	@ContactFormId INT,
	@IsAnswered BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE ContactForms
		SET IsAnswered = @IsAnswered
	WHERE ContactFormId = @ContactFormId
END


GO
/****** Object:  StoredProcedure [dbo].[EditEvent]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditEvent]
(
	@EventId int,
	@EventName varchar(50), 
	@EventDescription text, 
	@EventStartDate datetime, 
	@EventEndDate datetime,
	@EventImgPath text, 
	@VenueId int
)
AS
	UPDATE [Events]
		SET EventName = @EventName,
			EventDescription = @EventDescription,
			EventStartDate = @EventStartDate,
			EventEndDate = @EventEndDate,
			EventImgPath = @EventImgPath,
			VenueId = @VenueId
		WHERE EventId = @EventId







GO
/****** Object:  StoredProcedure [dbo].[EditImage]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditImage]
(
	@ImageId int,
	@ImagePath text,
	@ImageCaption text
)
AS
UPDATE [Images]
	SET ImagePath = @ImagePath,
		ImageCaption = @ImageCaption
	WHERE ImageId = @ImageId






GO
/****** Object:  StoredProcedure [dbo].[EditSeries]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditSeries]
(
	@SeriesId int,
	@SeriesName varchar(50),
	@SeriesDescription text
)
AS
	UPDATE Series 
		SET SeriesName = @SeriesName,
			SeriesDescription = @SeriesDescription
	WHERE SeriesId = @SeriesId







GO
/****** Object:  StoredProcedure [dbo].[EditStaticPage]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditStaticPage]
(
	@id int,
	@Title varchar(100),
	@Body text,
	@DateCreated date,
	@DateUpdated date
)
AS 
	UPDATE StaticPages
		SET Title = @Title, 
			Body = @Body, 
			DateCreated = @DateCreated, 
			DateUpdated = @DateUpdated
	WHERE PageId = @id





GO
/****** Object:  StoredProcedure [dbo].[EditStyle]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditStyle]
(
	@StyleId int,
	@StyleName Varchar(50),
	@StyleDescription text
)
AS
UPDATE [Styles]
	SET StyleName = @StyleName,
		StyleDescription = @StyleDescription
	WHERE StyleId = @StyleId






GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditUser]
(
	@AspUserId nvarchar(128),
	@FirstName varchar(25),
	@LastName varchar(25),
	@JobTitle varchar(50),
	@AccessLevel int,
	@ContactId int,
	@UserImgPath text,
	@Bio text,
	@IsEmployee bit,
	@UserId int
)
AS
	UPDATE Users
		SET  
			FirstName = @FirstName, 
			LastName = @LastName, 
			JobTitle = @JobTitle, 
			AccessLevel = @AccessLevel,
			ContactId = @ContactId, 
			UserImgPath = @UserImgPath, 
			Bio = @Bio, 
			IsEmployee = @IsEmployee
		WHERE UserId = @UserId

		UPDATE AspNetUsers
			SET Email = (SELECT TOP(1) C.Email
							FROM Contacts C
							WHERE C.ContactId = @ContactId)
			WHERE Id = @AspUserId





GO
/****** Object:  StoredProcedure [dbo].[EditVenue]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditVenue]
(
	@VenueId int,
	@VenueName varchar(50),
	@ContactId int,
	@VenueImgPath text
)
AS
	UPDATE Venues
		SET 
			VenueName = @VenueName,
			ContactId = @ContactId,
			VenueImgPath = @VenueImgPath
		WHERE VenueId = @VenueId







GO
/****** Object:  StoredProcedure [dbo].[GetAllBlogs]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllBlogs]
AS
SELECT BL.EntryId, BL.BlogBody, BL.BlogExpireDate, BL.BlogPostDate, BL.BlogTitle, BL.IsApproved,
	U.*, AU.UserName, C.City, C.Email, C.Phone, C.[State], C.StreetAddress, C.ZipCode
FROM BlogEntries BL
	LEFT OUTER JOIN Users U
	ON BL.UserId = U.UserId
	LEFT OUTER JOIN Contacts C
	ON U.ContactId = C.ContactId
	LEFT OUTER JOIN AspNetUsers AU
	ON U.AspUserId = AU.Id







GO
/****** Object:  StoredProcedure [dbo].[GetAllCollaborators]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCollaborators]
AS
SELECT COL.CollaboratorId, COL.CollaboratorName, COL.CollaboratorDescription, COL.CollaboratorImgPath, C.*
FROM Collaborators COL
	LEFT OUTER JOIN Contacts C
	ON COL.ContactId = C.ContactId







GO
/****** Object:  StoredProcedure [dbo].[GetAllContactForms]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllContactForms]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT *
	FROM ContactForms
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployees]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllEmployees]
AS
	SELECT C.*, U.AccessLevel, U.Bio, U.FirstName, U.JobTitle, U.LastName, U.UserId, U.UserImgPath, AU.UserName, u.AspUserId, u.IsEmployee
	FROM Users U
		LEFT OUTER JOIN Contacts C
		ON C.ContactId = U.ContactId
		LEFT OUTER JOIN AspNetUsers AU
		ON U.AspUserId = AU.Id
	WHERE U.IsEmployee = 1




GO
/****** Object:  StoredProcedure [dbo].[GetAllEvents]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllEvents]
AS
	SELECT EV.*, V.VenueImgPath, V.VenueName, C.*
	FROM [Events] EV
		LEFT OUTER JOIN Venues V
		ON EV.VenueId = V.VenueId
		LEFT OUTER JOIN Contacts C
		ON C.ContactId = V.ContactId







GO
/****** Object:  StoredProcedure [dbo].[GetAllSeries]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllSeries]
AS
	SELECT * FROM Series







GO
/****** Object:  StoredProcedure [dbo].[GetAllStaticPages]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStaticPages]
AS
	SELECT * 
	FROM StaticPages





GO
/****** Object:  StoredProcedure [dbo].[GetAllTags]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTags]
AS 
	SELECT *
	FROM Tags





GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
	SELECT C.*, U.AccessLevel, U.Bio, U.FirstName, U.JobTitle, U.LastName, U.UserId, U.UserImgPath, AU.UserName, U.AspUserId, u.IsEmployee
		FROM Users U
			LEFT OUTER JOIN Contacts C
			ON C.ContactId = U.ContactId
			LEFT OUTER JOIN AspNetUsers AU
			ON U.AspUserId = AU.Id





GO
/****** Object:  StoredProcedure [dbo].[GetAllVenues]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllVenues]
AS
	SELECT V.VenueId, V.VenueImgPath, V.VenueName, C.* 
	FROM Venues V
	LEFT OUTER JOIN Contacts C
	ON V.ContactId = C.ContactId







GO
/****** Object:  StoredProcedure [dbo].[GetBlogById]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBlogById]
(
	@BlogId int
) 
AS
SELECT BL.EntryId, BL.BlogBody, BL.BlogExpireDate, BL.BlogPostDate, BL.BlogTitle, BL.IsApproved,
	U.*, AU.UserName, C.City, C.Email, C.Phone, C.[State], C.StreetAddress, C.ZipCode
FROM BlogEntries BL
	LEFT OUTER JOIN Users U
	ON BL.UserId = U.UserId
	LEFT OUTER JOIN Contacts C
	ON U.ContactId = C.ContactId
	LEFT OUTER JOIN AspNetUsers AU
	ON AU.Id = U.AspUserId
WHERE BL.EntryId = @BlogId







GO
/****** Object:  StoredProcedure [dbo].[GetBlogTags]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBlogTags]
(
	@EntryId int
)
AS 
	SELECT T.*
	FROM Tags T
		INNER JOIN Tags_Blogs TB
		ON T.TagId = TB.TagId
	WHERE TB.EntryId = @EntryId





GO
/****** Object:  StoredProcedure [dbo].[GetCollaboratorById]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCollaboratorById]
(
	@CollaboratorId int
)
AS
SELECT COL.CollaboratorId, COL.CollaboratorName, COL.CollaboratorDescription, COL.CollaboratorImgPath, C.*
FROM Collaborators COL
	LEFT OUTER JOIN Contacts C
	ON COL.ContactId = C.ContactId
WHERE COL.CollaboratorId = @CollaboratorId







GO
/****** Object:  StoredProcedure [dbo].[GetContactFormById]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetContactFormById]
	-- Add the parameters for the stored procedure here
	@ContactFormId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM ContactForms
	WHERE ContactFormId = @ContactFormId
END


GO
/****** Object:  StoredProcedure [dbo].[GetEventById]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEventById]
(
	@EventId int
)
AS
	SELECT EV.*, V.VenueImgPath, V.VenueName, C.*
	FROM [Events] EV
		LEFT OUTER JOIN Venues V
		ON EV.VenueId = V.VenueId
		LEFT OUTER JOIN Contacts C
		ON C.ContactId = V.ContactId
	WHERE EV.EventId = @EventId







GO
/****** Object:  StoredProcedure [dbo].[GetImageTags]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetImageTags]
(
	@ImageId int
)
AS 
	SELECT T.*
	FROM Tags T
		INNER JOIN Tags_Images TI
		ON T.TagId = TI.TagId
	WHERE TI.ImageId = @ImageId





GO
/****** Object:  StoredProcedure [dbo].[GetSeriesById]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSeriesById]
(
	@SeriesId int
)
AS
	SELECT * FROM Series S
	WHERE S.SeriesId = @SeriesId







GO
/****** Object:  StoredProcedure [dbo].[GetStaticPageById]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStaticPageById]
(
	@id int
)
AS 
	SELECT * 
	FROM StaticPages
	WHERE PageId = @id





GO
/****** Object:  StoredProcedure [dbo].[GetTagByName]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTagByName]
(
	@TagName varchar(50)
)
AS
	SELECT *
	FROM Tags T
	WHERE T.TagName = @TagName


GO
/****** Object:  StoredProcedure [dbo].[GetUserByAspId]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByAspId]
(
	@AspUserId nvarchar(128)
)
AS
	SELECT C.*, U.AccessLevel, U.Bio, U.FirstName, U.JobTitle, U.LastName, U.UserId, U.UserImgPath, AU.UserName, u.AspUserId, u.IsEmployee
		FROM Users U
			LEFT OUTER JOIN Contacts C
			ON C.ContactId = U.ContactId
			LEFT OUTER JOIN AspNetUsers AU
			ON U.AspUserId = AU.Id
	WHERE U.AspUserId = @AspUserId





GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
(
	@UserId nvarchar(128)
)
AS
	SELECT C.*, U.AccessLevel, U.Bio, U.FirstName, U.JobTitle, U.LastName, U.UserId, U.UserImgPath, AU.UserName, u.AspUserId, u.IsEmployee
		FROM Users U
			LEFT OUTER JOIN Contacts C
			ON C.ContactId = U.ContactId
			LEFT OUTER JOIN AspNetUsers AU
			ON U.AspUserId = AU.Id
	WHERE U.UserId = @UserId





GO
/****** Object:  StoredProcedure [dbo].[GetVenueById]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVenueById]
(
	@VenueId int
)
AS
	SELECT V.VenueId, V.VenueImgPath, V.VenueName, C.* 
	FROM Venues V
		LEFT OUTER JOIN Contacts C
		ON V.ContactId = C.ContactId
	WHERE V.VenueId = @VenueId







GO
/****** Object:  StoredProcedure [dbo].[UpdateBridgeTags]    Script Date: 9/7/2016 5:00:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBridgeTags]
(
	@TagId int,
	@BlogId int
)
AS
	SET @BlogId = (SELECT TOP(1) EntryId FROM BlogEntries ORDER BY EntryId)

	INSERT INTO Tags_Blogs(TagId, EntryId)
	VALUES (@TagId, @BlogId)



GO
USE [master]
GO
ALTER DATABASE [Watermark] SET  READ_WRITE 
GO
