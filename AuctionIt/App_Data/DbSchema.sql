/****** Object:  StoredProcedure [dbo].[VerifyToken]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[VerifyToken]
GO
/****** Object:  StoredProcedure [dbo].[VerifyAd]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[VerifyAd]
GO
/****** Object:  StoredProcedure [dbo].[UserTokenToAuction]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[UserTokenToAuction]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserName]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[UpdateUserName]
GO
/****** Object:  StoredProcedure [dbo].[UpdateAdWinner]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[UpdateAdWinner]
GO
/****** Object:  StoredProcedure [dbo].[PayForAuction]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[PayForAuction]
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetUserByUserName]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetUserByUserName]
GO
/****** Object:  StoredProcedure [dbo].[GetToken]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetToken]
GO
/****** Object:  StoredProcedure [dbo].[GetPrimaryUsers]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetPrimaryUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetPrimaryUser]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetPrimaryUser]
GO
/****** Object:  StoredProcedure [dbo].[GetOnlinePaymentLog]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetOnlinePaymentLog]
GO
/****** Object:  StoredProcedure [dbo].[GetInterestedAdvertisements]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetInterestedAdvertisements]
GO
/****** Object:  StoredProcedure [dbo].[GetFranchiseManagers]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetFranchiseManagers]
GO
/****** Object:  StoredProcedure [dbo].[GetFranchiseManager]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetFranchiseManager]
GO
/****** Object:  StoredProcedure [dbo].[GetDetailedLog]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetDetailedLog]
GO
/****** Object:  StoredProcedure [dbo].[GetCategory]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetCategory]
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetCategories]
GO
/****** Object:  StoredProcedure [dbo].[GetAuctions]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAuctions]
GO
/****** Object:  StoredProcedure [dbo].[GetAuctionBids]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAuctionBids]
GO
/****** Object:  StoredProcedure [dbo].[GetAuction]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAuction]
GO
/****** Object:  StoredProcedure [dbo].[GetAttributesValuesForAdvertisement]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAttributesValuesForAdvertisement]
GO
/****** Object:  StoredProcedure [dbo].[GetAdvertisements]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAdvertisements]
GO
/****** Object:  StoredProcedure [dbo].[GetAdvertisement]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAdvertisement]
GO
/****** Object:  StoredProcedure [dbo].[GetAdditionalAttributes]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAdditionalAttributes]
GO
/****** Object:  StoredProcedure [dbo].[GetAdditionalAttribute]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAdditionalAttribute]
GO
/****** Object:  StoredProcedure [dbo].[GetAccountingLog]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAccountingLog]
GO
/****** Object:  StoredProcedure [dbo].[CreateToken]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[CreateToken]
GO
/****** Object:  StoredProcedure [dbo].[BidToAuction]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[BidToAuction]
GO
/****** Object:  StoredProcedure [dbo].[AddValueForAdditionalAttribute]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddValueForAdditionalAttribute]
GO
/****** Object:  StoredProcedure [dbo].[AddUserImage]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddUserImage]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddUser]
GO
/****** Object:  StoredProcedure [dbo].[AddToInterest]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddToInterest]
GO
/****** Object:  StoredProcedure [dbo].[AddPrimaryUser]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddPrimaryUser]
GO
/****** Object:  StoredProcedure [dbo].[AddOnlinePayment]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddOnlinePayment]
GO
/****** Object:  StoredProcedure [dbo].[AddIdentity]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddIdentity]
GO
/****** Object:  StoredProcedure [dbo].[AddFranchiseManager]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddFranchiseManager]
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddCategory]
GO
/****** Object:  StoredProcedure [dbo].[AddAuction]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddAuction]
GO
/****** Object:  StoredProcedure [dbo].[AddAdvertisementTag]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddAdvertisementTag]
GO
/****** Object:  StoredProcedure [dbo].[AddAdvertisementImage]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddAdvertisementImage]
GO
/****** Object:  StoredProcedure [dbo].[AddAdvertisement]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddAdvertisement]
GO
/****** Object:  StoredProcedure [dbo].[AddAdditionalAttribute]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddAdditionalAttribute]
GO
/****** Object:  StoredProcedure [dbo].[AddAccountRecord]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[AddAccountRecord]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USER_HAS_IDENTITY]') AND type in (N'U'))
ALTER TABLE [dbo].[USER_HAS_IDENTITY] DROP CONSTRAINT IF EXISTS [FK_USER_HAS_IDENTITY_USERS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USER_HAS_IDENTITY]') AND type in (N'U'))
ALTER TABLE [dbo].[USER_HAS_IDENTITY] DROP CONSTRAINT IF EXISTS [FK_USER_HAS_IDENTITY_AspNetUsers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIMARY_USERS]') AND type in (N'U'))
ALTER TABLE [dbo].[PRIMARY_USERS] DROP CONSTRAINT IF EXISTS [FK_PRIMARY_USERS_USERS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]') AND type in (N'U'))
ALTER TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION] DROP CONSTRAINT IF EXISTS [FK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION_TOKENS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]') AND type in (N'U'))
ALTER TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION] DROP CONSTRAINT IF EXISTS [FK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION_PRIMARY_USERS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]') AND type in (N'U'))
ALTER TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION] DROP CONSTRAINT IF EXISTS [FK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION_AUCTIONS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIMARY_USER_BIDS_ON_AUCTION]') AND type in (N'U'))
ALTER TABLE [dbo].[PRIMARY_USER_BIDS_ON_AUCTION] DROP CONSTRAINT IF EXISTS [FK_PRIMARY_USER_BIDS_ON_AUCTION_PRIMARY_USERS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIMARY_USER_BIDS_ON_AUCTION]') AND type in (N'U'))
ALTER TABLE [dbo].[PRIMARY_USER_BIDS_ON_AUCTION] DROP CONSTRAINT IF EXISTS [FK_PRIMARY_USER_BIDS_ON_AUCTION_AUCTIONS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST]') AND type in (N'U'))
ALTER TABLE [dbo].[PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST] DROP CONSTRAINT IF EXISTS [FK_PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST_PRIMARY_USERS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ONLINE_PAYMENT_LOG]') AND type in (N'U'))
ALTER TABLE [dbo].[ONLINE_PAYMENT_LOG] DROP CONSTRAINT IF EXISTS [FK_ONLINE_PAYMENT_LOG_PRIMARY_USERS1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FRANCHISE_MANAGERS]') AND type in (N'U'))
ALTER TABLE [dbo].[FRANCHISE_MANAGERS] DROP CONSTRAINT IF EXISTS [FK_FRANCHISE_MANAGERS_USERS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUCTIONS]') AND type in (N'U'))
ALTER TABLE [dbo].[AUCTIONS] DROP CONSTRAINT IF EXISTS [FK_AUCTIONS_ADVERTISEMENTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES]') AND type in (N'U'))
ALTER TABLE [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES] DROP CONSTRAINT IF EXISTS [FK_ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES_ADVERTISEMENTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES]') AND type in (N'U'))
ALTER TABLE [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES] DROP CONSTRAINT IF EXISTS [FK_ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES_ADDITIONAL_ATTRIBUTES]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADVERTISEMENTS]') AND type in (N'U'))
ALTER TABLE [dbo].[ADVERTISEMENTS] DROP CONSTRAINT IF EXISTS [FK_ADVERTISEMENTS_PRIMARY_USERS1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADVERTISEMENTS]') AND type in (N'U'))
ALTER TABLE [dbo].[ADVERTISEMENTS] DROP CONSTRAINT IF EXISTS [FK_ADVERTISEMENTS_PRIMARY_USERS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADVERTISEMENTS]') AND type in (N'U'))
ALTER TABLE [dbo].[ADVERTISEMENTS] DROP CONSTRAINT IF EXISTS [FK_ADVERTISEMENTS_CATEGORIES]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADVERTISEMENT_HAS_TAGS]') AND type in (N'U'))
ALTER TABLE [dbo].[ADVERTISEMENT_HAS_TAGS] DROP CONSTRAINT IF EXISTS [FK_ADVERTISEMENT_HAS_TAGS_ADVERTISEMENTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADVERTISEMENT_HAS_IMAGE]') AND type in (N'U'))
ALTER TABLE [dbo].[ADVERTISEMENT_HAS_IMAGE] DROP CONSTRAINT IF EXISTS [FK_ADVERTISEMENT_HAS_IMAGE_ADVERTISEMENTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADDITIONAL_ATTRIBUTES]') AND type in (N'U'))
ALTER TABLE [dbo].[ADDITIONAL_ATTRIBUTES] DROP CONSTRAINT IF EXISTS [FK_ADDITIONAL_ATTRIBUTES_CATEGORIES]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACCOUNTING_LOG]') AND type in (N'U'))
ALTER TABLE [dbo].[ACCOUNTING_LOG] DROP CONSTRAINT IF EXISTS [FK_ACCOUNTING_LOG_USERS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USERS]') AND type in (N'U'))
ALTER TABLE [dbo].[USERS] DROP CONSTRAINT IF EXISTS [DF_USERS_ProfilePic]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADVERTISEMENTS]') AND type in (N'U'))
ALTER TABLE [dbo].[ADVERTISEMENTS] DROP CONSTRAINT IF EXISTS [DF_ADVERTISEMENTS_SoldPrice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADVERTISEMENTS]') AND type in (N'U'))
ALTER TABLE [dbo].[ADVERTISEMENTS] DROP CONSTRAINT IF EXISTS [DF_ADVERTISEMENTS_IsVerified]
GO
/****** Object:  Index [UNIQUE_CNIC]    Script Date: 1/25/2020 7:00:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIMARY_USERS]') AND type in (N'U'))
ALTER TABLE [dbo].[PRIMARY_USERS] DROP CONSTRAINT IF EXISTS [UNIQUE_CNIC]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[USERS]
GO
/****** Object:  Table [dbo].[USER_HAS_IDENTITY]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[USER_HAS_IDENTITY]
GO
/****** Object:  Table [dbo].[TOKENS]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[TOKENS]
GO
/****** Object:  Table [dbo].[PRIMARY_USERS]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[PRIMARY_USERS]
GO
/****** Object:  Table [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]
GO
/****** Object:  Table [dbo].[PRIMARY_USER_BIDS_ON_AUCTION]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[PRIMARY_USER_BIDS_ON_AUCTION]
GO
/****** Object:  Table [dbo].[PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST]
GO
/****** Object:  Table [dbo].[ONLINE_PAYMENT_LOG]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[ONLINE_PAYMENT_LOG]
GO
/****** Object:  Table [dbo].[FRANCHISE_MANAGERS]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[FRANCHISE_MANAGERS]
GO
/****** Object:  Table [dbo].[CATEGORIES]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[CATEGORIES]
GO
/****** Object:  Table [dbo].[AUCTIONS]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[AUCTIONS]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES]
GO
/****** Object:  Table [dbo].[ADVERTISEMENTS]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[ADVERTISEMENTS]
GO
/****** Object:  Table [dbo].[ADVERTISEMENT_HAS_TAGS]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[ADVERTISEMENT_HAS_TAGS]
GO
/****** Object:  Table [dbo].[ADVERTISEMENT_HAS_IMAGE]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[ADVERTISEMENT_HAS_IMAGE]
GO
/****** Object:  Table [dbo].[ADDITIONAL_ATTRIBUTES]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[ADDITIONAL_ATTRIBUTES]
GO
/****** Object:  Table [dbo].[ACCOUNTING_LOG]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP TABLE IF EXISTS [dbo].[ACCOUNTING_LOG]
GO
/****** Object:  Database [AuctionItDb]    Script Date: 1/25/2020 7:00:05 AM ******/
DROP DATABASE [AuctionItDb]
GO
/****** Object:  Database [AuctionItDb]    Script Date: 1/25/2020 7:00:05 AM ******/
CREATE DATABASE [AuctionItDb]  ;
GO
ALTER DATABASE [AuctionItDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AuctionItDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AuctionItDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AuctionItDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AuctionItDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [AuctionItDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AuctionItDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AuctionItDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AuctionItDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AuctionItDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AuctionItDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AuctionItDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AuctionItDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AuctionItDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AuctionItDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AuctionItDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AuctionItDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AuctionItDb] SET  MULTI_USER 
GO
ALTER DATABASE [AuctionItDb] SET QUERY_STORE = OFF
GO
/****** Object:  Table [dbo].[ACCOUNTING_LOG]    Script Date: 1/25/2020 7:00:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNTING_LOG](
	[ALogId] [bigint] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_ACCOUNTING_LOG] PRIMARY KEY CLUSTERED 
(
	[ALogId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADDITIONAL_ATTRIBUTES]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADDITIONAL_ATTRIBUTES](
	[AttibuteId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ADDITIONAL_ATTRIBUTES] PRIMARY KEY CLUSTERED 
(
	[AttibuteId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADVERTISEMENT_HAS_IMAGE]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADVERTISEMENT_HAS_IMAGE](
	[AdId] [bigint] NOT NULL,
	[ImageId] [bigint] IDENTITY(1,1) NOT NULL,
	[ImageName] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ADVERTISEMENT_HAS_IMAGE] PRIMARY KEY CLUSTERED 
(
	[AdId] ASC,
	[ImageId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADVERTISEMENT_HAS_TAGS]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADVERTISEMENT_HAS_TAGS](
	[AdId] [bigint] NOT NULL,
	[TagId] [bigint] IDENTITY(1,1) NOT NULL,
	[Tag] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ADVERTISEMENT_HAS_TAGS] PRIMARY KEY CLUSTERED 
(
	[AdId] ASC,
	[TagId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADVERTISEMENTS]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADVERTISEMENTS](
	[AdId] [bigint] IDENTITY(1,1) NOT NULL,
	[Price] [money] NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[PostedDateTime] [datetime] NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[Description] [text] NOT NULL,
	[PosterId] [bigint] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[WinnerId] [bigint] NULL,
	[Rating] [smallint] NULL,
	[Comment] [text] NULL,
	[SoldPrice] [money] NOT NULL,
 CONSTRAINT [PK_ADVERTISEMENTS] PRIMARY KEY CLUSTERED 
(
	[AdId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES](
	[AdId] [bigint] NOT NULL,
	[AttributeId] [int] NOT NULL,
	[Value] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES] PRIMARY KEY CLUSTERED 
(
	[AdId] ASC,
	[AttributeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/25/2020 7:00:06 AM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/25/2020 7:00:06 AM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/25/2020 7:00:06 AM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/25/2020 7:00:06 AM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/25/2020 7:00:06 AM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AUCTIONS]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUCTIONS](
	[AuctionId] [bigint] IDENTITY(1,1) NOT NULL,
	[StartingBidPrice] [money] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[SecurityFee] [money] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[AdId] [bigint] NOT NULL,
 CONSTRAINT [PK_AUCTIONS] PRIMARY KEY CLUSTERED 
(
	[AuctionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIES]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIES](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](max) NOT NULL,
 CONSTRAINT [PK_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FRANCHISE_MANAGERS]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FRANCHISE_MANAGERS](
	[UserId] [bigint] NOT NULL,
	[FranchiseNumber] [varchar](max) NOT NULL,
	[FranchiseLocation] [varchar](max) NOT NULL,
 CONSTRAINT [PK_FRANCHISE_MANAGER] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ONLINE_PAYMENT_LOG]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ONLINE_PAYMENT_LOG](
	[OPaymentId] [bigint] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Amount] [money] NOT NULL,
	[RefNumber] [varchar](max) NOT NULL,
	[ChannelName] [varchar](50) NOT NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_ONLINE_PAYMENT_LOG] PRIMARY KEY CLUSTERED 
(
	[OPaymentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST](
	[UserId] [bigint] NOT NULL,
	[AdId] [bigint] NOT NULL,
 CONSTRAINT [PK_PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AdId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRIMARY_USER_BIDS_ON_AUCTION]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRIMARY_USER_BIDS_ON_AUCTION](
	[UserId] [bigint] NOT NULL,
	[AuctionId] [bigint] NOT NULL,
	[Bid] [money] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_PRIMARY_USER_BIDS_ON_AUCTION] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AuctionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION](
	[UserId] [bigint] NOT NULL,
	[TokenId] [bigint] NOT NULL,
	[AuctionId] [bigint] NOT NULL,
 CONSTRAINT [PK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[TokenId] ASC,
	[AuctionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRIMARY_USERS]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRIMARY_USERS](
	[UserId] [bigint] NOT NULL,
	[CNIC] [nchar](15) NOT NULL,
 CONSTRAINT [PK_PRIMARY_USERS] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TOKENS]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOKENS](
	[TokenId] [bigint] IDENTITY(1,1) NOT NULL,
	[HashKey] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TOKENS] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_HAS_IDENTITY]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_HAS_IDENTITY](
	[UserId] [bigint] NOT NULL,
	[IdentityId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_USER_HAS_IDENTITY] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[IdentityId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 1/25/2020 7:00:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](max) NOT NULL,
	[LastName] [varchar](max) NOT NULL,
	[PCountryCode] [nchar](3) NOT NULL,
	[PCompanyCode] [nchar](3) NOT NULL,
	[PNumber] [nchar](7) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[ProfilePic] [varchar](max) NOT NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Franchise Manager')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Primary User')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNIQUE_CNIC]    Script Date: 1/25/2020 7:00:07 AM ******/
ALTER TABLE [dbo].[PRIMARY_USERS] ADD  CONSTRAINT [UNIQUE_CNIC] UNIQUE NONCLUSTERED 
(
	[CNIC] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ADVERTISEMENTS] ADD  CONSTRAINT [DF_ADVERTISEMENTS_IsVerified]  DEFAULT ((0)) FOR [IsVerified]
GO
ALTER TABLE [dbo].[ADVERTISEMENTS] ADD  CONSTRAINT [DF_ADVERTISEMENTS_SoldPrice]  DEFAULT ((0)) FOR [SoldPrice]
GO
ALTER TABLE [dbo].[USERS] ADD  CONSTRAINT [DF_USERS_ProfilePic]  DEFAULT ('default.jpg') FOR [ProfilePic]
GO
ALTER TABLE [dbo].[ACCOUNTING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_ACCOUNTING_LOG_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[USERS] ([UserId])
GO
ALTER TABLE [dbo].[ACCOUNTING_LOG] CHECK CONSTRAINT [FK_ACCOUNTING_LOG_USERS]
GO
ALTER TABLE [dbo].[ADDITIONAL_ATTRIBUTES]  WITH CHECK ADD  CONSTRAINT [FK_ADDITIONAL_ATTRIBUTES_CATEGORIES] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CATEGORIES] ([CategoryId])
GO
ALTER TABLE [dbo].[ADDITIONAL_ATTRIBUTES] CHECK CONSTRAINT [FK_ADDITIONAL_ATTRIBUTES_CATEGORIES]
GO
ALTER TABLE [dbo].[ADVERTISEMENT_HAS_IMAGE]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMENT_HAS_IMAGE_ADVERTISEMENTS] FOREIGN KEY([AdId])
REFERENCES [dbo].[ADVERTISEMENTS] ([AdId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ADVERTISEMENT_HAS_IMAGE] CHECK CONSTRAINT [FK_ADVERTISEMENT_HAS_IMAGE_ADVERTISEMENTS]
GO
ALTER TABLE [dbo].[ADVERTISEMENT_HAS_TAGS]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMENT_HAS_TAGS_ADVERTISEMENTS] FOREIGN KEY([AdId])
REFERENCES [dbo].[ADVERTISEMENTS] ([AdId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ADVERTISEMENT_HAS_TAGS] CHECK CONSTRAINT [FK_ADVERTISEMENT_HAS_TAGS_ADVERTISEMENTS]
GO
ALTER TABLE [dbo].[ADVERTISEMENTS]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMENTS_CATEGORIES] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CATEGORIES] ([CategoryId])
GO
ALTER TABLE [dbo].[ADVERTISEMENTS] CHECK CONSTRAINT [FK_ADVERTISEMENTS_CATEGORIES]
GO
ALTER TABLE [dbo].[ADVERTISEMENTS]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMENTS_PRIMARY_USERS] FOREIGN KEY([PosterId])
REFERENCES [dbo].[PRIMARY_USERS] ([UserId])
GO
ALTER TABLE [dbo].[ADVERTISEMENTS] CHECK CONSTRAINT [FK_ADVERTISEMENTS_PRIMARY_USERS]
GO
ALTER TABLE [dbo].[ADVERTISEMENTS]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMENTS_PRIMARY_USERS1] FOREIGN KEY([WinnerId])
REFERENCES [dbo].[PRIMARY_USERS] ([UserId])
GO
ALTER TABLE [dbo].[ADVERTISEMENTS] CHECK CONSTRAINT [FK_ADVERTISEMENTS_PRIMARY_USERS1]
GO
ALTER TABLE [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES_ADDITIONAL_ATTRIBUTES] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[ADDITIONAL_ATTRIBUTES] ([AttibuteId])
GO
ALTER TABLE [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES] CHECK CONSTRAINT [FK_ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES_ADDITIONAL_ATTRIBUTES]
GO
ALTER TABLE [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES_ADVERTISEMENTS] FOREIGN KEY([AdId])
REFERENCES [dbo].[ADVERTISEMENTS] ([AdId])
GO
ALTER TABLE [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES] CHECK CONSTRAINT [FK_ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES_ADVERTISEMENTS]
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
ALTER TABLE [dbo].[AUCTIONS]  WITH CHECK ADD  CONSTRAINT [FK_AUCTIONS_ADVERTISEMENTS] FOREIGN KEY([AdId])
REFERENCES [dbo].[ADVERTISEMENTS] ([AdId])
GO
ALTER TABLE [dbo].[AUCTIONS] CHECK CONSTRAINT [FK_AUCTIONS_ADVERTISEMENTS]
GO
ALTER TABLE [dbo].[FRANCHISE_MANAGERS]  WITH CHECK ADD  CONSTRAINT [FK_FRANCHISE_MANAGERS_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[USERS] ([UserId])
GO
ALTER TABLE [dbo].[FRANCHISE_MANAGERS] CHECK CONSTRAINT [FK_FRANCHISE_MANAGERS_USERS]
GO
ALTER TABLE [dbo].[ONLINE_PAYMENT_LOG]  WITH CHECK ADD  CONSTRAINT [FK_ONLINE_PAYMENT_LOG_PRIMARY_USERS1] FOREIGN KEY([UserId])
REFERENCES [dbo].[PRIMARY_USERS] ([UserId])
GO
ALTER TABLE [dbo].[ONLINE_PAYMENT_LOG] CHECK CONSTRAINT [FK_ONLINE_PAYMENT_LOG_PRIMARY_USERS1]
GO
ALTER TABLE [dbo].[PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST]  WITH CHECK ADD  CONSTRAINT [FK_PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST_PRIMARY_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[PRIMARY_USERS] ([UserId])
GO
ALTER TABLE [dbo].[PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST] CHECK CONSTRAINT [FK_PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST_PRIMARY_USERS]
GO
ALTER TABLE [dbo].[PRIMARY_USER_BIDS_ON_AUCTION]  WITH CHECK ADD  CONSTRAINT [FK_PRIMARY_USER_BIDS_ON_AUCTION_AUCTIONS] FOREIGN KEY([AuctionId])
REFERENCES [dbo].[AUCTIONS] ([AuctionId])
GO
ALTER TABLE [dbo].[PRIMARY_USER_BIDS_ON_AUCTION] CHECK CONSTRAINT [FK_PRIMARY_USER_BIDS_ON_AUCTION_AUCTIONS]
GO
ALTER TABLE [dbo].[PRIMARY_USER_BIDS_ON_AUCTION]  WITH CHECK ADD  CONSTRAINT [FK_PRIMARY_USER_BIDS_ON_AUCTION_PRIMARY_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[PRIMARY_USERS] ([UserId])
GO
ALTER TABLE [dbo].[PRIMARY_USER_BIDS_ON_AUCTION] CHECK CONSTRAINT [FK_PRIMARY_USER_BIDS_ON_AUCTION_PRIMARY_USERS]
GO
ALTER TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]  WITH CHECK ADD  CONSTRAINT [FK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION_AUCTIONS] FOREIGN KEY([AuctionId])
REFERENCES [dbo].[AUCTIONS] ([AuctionId])
GO
ALTER TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION] CHECK CONSTRAINT [FK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION_AUCTIONS]
GO
ALTER TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]  WITH CHECK ADD  CONSTRAINT [FK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION_PRIMARY_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[PRIMARY_USERS] ([UserId])
GO
ALTER TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION] CHECK CONSTRAINT [FK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION_PRIMARY_USERS]
GO
ALTER TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]  WITH CHECK ADD  CONSTRAINT [FK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION_TOKENS] FOREIGN KEY([TokenId])
REFERENCES [dbo].[TOKENS] ([TokenId])
GO
ALTER TABLE [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION] CHECK CONSTRAINT [FK_PRIMARY_USER_GETS_TOKEN_ON_AUCTION_TOKENS]
GO
ALTER TABLE [dbo].[PRIMARY_USERS]  WITH CHECK ADD  CONSTRAINT [FK_PRIMARY_USERS_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[USERS] ([UserId])
GO
ALTER TABLE [dbo].[PRIMARY_USERS] CHECK CONSTRAINT [FK_PRIMARY_USERS_USERS]
GO
ALTER TABLE [dbo].[USER_HAS_IDENTITY]  WITH CHECK ADD  CONSTRAINT [FK_USER_HAS_IDENTITY_AspNetUsers] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[USER_HAS_IDENTITY] CHECK CONSTRAINT [FK_USER_HAS_IDENTITY_AspNetUsers]
GO
ALTER TABLE [dbo].[USER_HAS_IDENTITY]  WITH CHECK ADD  CONSTRAINT [FK_USER_HAS_IDENTITY_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[USERS] ([UserId])
GO
ALTER TABLE [dbo].[USER_HAS_IDENTITY] CHECK CONSTRAINT [FK_USER_HAS_IDENTITY_USERS]
GO
/****** Object:  StoredProcedure [dbo].[AddAccountRecord]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAccountRecord]
	@userId bigint,
	@debit money,
	@credit money,
	@dateTime datetime
AS
BEGIN
	INSERT INTO [dbo].[ACCOUNTING_LOG]
           ([DateTime]
           ,[Debit]
           ,[Credit]
           ,[UserId])
     VALUES
           (@dateTime
           ,@debit
           ,@credit
           ,@userId);
		SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddAdditionalAttribute]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAdditionalAttribute]
	@catId int,
	@name varchar(max)
AS
BEGIN
	INSERT INTO [dbo].[ADDITIONAL_ATTRIBUTES]
           ([Name]
           ,[CategoryId])
     VALUES
           (@name
           ,@catId);

	SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddAdvertisement]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAdvertisement]
	@posterId bigint,
	@title varchar(max),
	@postedDateTime datetime,
	@description text,
	@categoryId int,
	@price money
AS
BEGIN
	INSERT INTO [dbo].[ADVERTISEMENTS]
           ([Price]
           ,[Title]
           ,[PostedDateTime]
           ,[Description]
           ,[PosterId]
           ,[CategoryId])
     VALUES
           (@price
           ,@title
           ,@postedDateTime
           ,@description
           ,@posterId
           ,@categoryId);

	SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddAdvertisementImage]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAdvertisementImage]
	@image varchar(max),
	@adId bigint
AS
BEGIN
	INSERT INTO [dbo].[ADVERTISEMENT_HAS_IMAGE]
           ([AdId]
           ,[ImageName])
     VALUES
           (@adId
           ,@image);
END
GO
/****** Object:  StoredProcedure [dbo].[AddAdvertisementTag]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAdvertisementTag]
	@tag varchar(max),
	@adId bigint
AS
BEGIN
	INSERT INTO [dbo].[ADVERTISEMENT_HAS_TAGS]
           ([AdId]
           ,[Tag])
     VALUES
           (@adId
           ,@tag);
END
GO
/****** Object:  StoredProcedure [dbo].[AddAuction]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAuction]
	@adId bigint,
	@startingPrice money,
	@securityFee money,
	@startTime datetime,
	@endTime datetime
AS
BEGIN
	INSERT INTO [dbo].[AUCTIONS]
           ([StartingBidPrice]
           ,[StartTime]
           ,[SecurityFee]
           ,[EndDateTime]
           ,[AdId])
     VALUES
           (@startingPrice
           ,@startTime
           ,@securityFee
           ,@endTime
           ,@adId);

	SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategory]
	@name varchar(max)
AS
BEGIN
	INSERT INTO [dbo].[CATEGORIES]
           ([CategoryName])
     VALUES
           (@name);

	SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddFranchiseManager]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddFranchiseManager]
	@userId bigint,
	@fNumber varchar(max),
	@fLocation varchar(max)
AS
BEGIN
	INSERT INTO [dbo].[FRANCHISE_MANAGERS]
           ([UserId]
           ,[FranchiseNumber]
           ,[FranchiseLocation])
     VALUES
           (@userId
           ,@fNumber
           ,@fLocation);

	--SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddIdentity]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddIdentity]
	@userId bigint,
	@identityId nvarchar(128)
AS
BEGIN
	INSERT INTO [dbo].[USER_HAS_IDENTITY]
           ([UserId]
           ,[IdentityId])
     VALUES
           (@userId
           ,@identityId);

	--SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddOnlinePayment]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddOnlinePayment]
	@userId bigint,
	@amount money,
	@refNumber varchar(max),
	@channelName varchar(50),
	@dateTime datetime
AS
BEGIN
	INSERT INTO [dbo].[ONLINE_PAYMENT_LOG]
           ([DateTime]
           ,[Amount]
           ,[RefNumber]
           ,[ChannelName]
           ,[UserId])
     VALUES
           (@dateTime
           ,@amount
           ,@refNumber
           ,@channelName
           ,@userId);

	SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddPrimaryUser]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPrimaryUser]
	@userId bigint,
	@cnic nchar(15)
AS
BEGIN
	INSERT INTO [dbo].[PRIMARY_USERS]
           ([UserId]
           ,[CNIC])
     VALUES
           (@userId
           ,@cnic);

	--SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddToInterest]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddToInterest]
	@userId bigint,
	@adId bigint
AS
BEGIN
	INSERT INTO [dbo].[PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST]
           ([UserId]
           ,[AdId])
     VALUES
           (@userId
           ,@adId);
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@firstName varchar(max),
	@lastName varchar(max),
	@pcountryCode nchar(3),
	@pCompanyCode nchar(3),
	@pNumber nchar(7),
	@city varchar(max)
AS
BEGIN
	INSERT INTO [dbo].[USERS]
           ([FirstName]
           ,[LastName]
           ,[PCountryCode]
           ,[PCompanyCode]
           ,[PNumber]
           ,[City])
     VALUES
           (@firstName
           ,@lastName
           ,@pcountryCode
           ,@pCompanyCode
           ,@pNumber
           ,@city);

	SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[AddUserImage]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserImage]
	@image varchar(max),
	@userId bigint
AS
BEGIN
	UPDATE USERS
	SET ProfilePic=@image
	WHERE UserId=@userId;
END
GO
/****** Object:  StoredProcedure [dbo].[AddValueForAdditionalAttribute]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddValueForAdditionalAttribute]
	@adId bigint,
	@attId int,
	@value varchar(max)
AS
BEGIN
	INSERT INTO [dbo].[ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES]
           ([AdId]
           ,[AttributeId]
           ,[Value])
     VALUES
           (@adId
           ,@attId
           ,@value);
END
GO
/****** Object:  StoredProcedure [dbo].[BidToAuction]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BidToAuction]
	@userId bigint,
	@aId bigint,
	@bid money,
	@dateTime datetime
AS
BEGIN
	INSERT INTO [dbo].[PRIMARY_USER_BIDS_ON_AUCTION]
           ([UserId]
           ,[AuctionId]
           ,[Bid]
		   ,[DateTime])
     VALUES
           (@userId
           ,@aId
           ,@bid
		   ,@dateTime);
END
GO
/****** Object:  StoredProcedure [dbo].[CreateToken]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateToken]
	@hash varchar(max),
	@userId bigint,
	@auctionId bigint
AS
BEGIN
	INSERT INTO [dbo].[TOKENS]
           ([HashKey])
     VALUES
           (@hash);
	DECLARE @id bigint;
	SELECT @id = SCOPE_IDENTITY();
	INSERT INTO [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]
           ([UserId]
           ,[TokenId]
           ,[AuctionId])
     VALUES
           (@userId
           ,@id
           ,@auctionId);
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountingLog]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccountingLog] 
	@userId bigint
AS
BEGIN
	SELECT [ALogId]
      ,[DateTime]
      ,[Debit]
      ,[Credit]
      ,[UserId]
  FROM [dbo].[ACCOUNTING_LOG]
  WHERE UserId=@userId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAdditionalAttribute]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAdditionalAttribute]
	@id int
AS
BEGIN
	SELECT *
	FROM ADDITIONAL_ATTRIBUTES
	WHERE AttibuteId=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAdditionalAttributes]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAdditionalAttributes]
	@catId int
AS
BEGIN
	SELECT AttibuteId
  FROM ADDITIONAL_ATTRIBUTES
  WHERE CategoryId=@catId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAdvertisement]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAdvertisement]
	@id bigint
AS
BEGIN
	SELECT *
	FROM ADVERTISEMENTS
	WHERE AdId=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAdvertisements]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAdvertisements]
AS
BEGIN
	SELECT *
	FROM ADVERTISEMENTS;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAttributesValuesForAdvertisement]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAttributesValuesForAdvertisement]
		@id bigint
AS
BEGIN
	SELECT a.[Name] as [Name], ad.[Value] as [Value]
	FROM ADVERTISEMETS_HAS_ADDITIONAL_ATTIBUTES ad, ADDITIONAL_ATTRIBUTES a
	WHERE AD.AttributeId=A.AttibuteId AND ad.AdId=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuction]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuction]
		@id bigint
AS
BEGIN
	SELECT *
	FROM AUCTIONS
	WHERE AuctionId=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuctionBids]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuctionBids]
		@auctionId bigint
AS
BEGIN
	SELECT *
	FROM PRIMARY_USER_BIDS_ON_AUCTION
	WHERE AuctionId=@auctionId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuctions]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAuctions]
AS
BEGIN
	SELECT *
	FROM AUCTIONS;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategories]
AS
BEGIN
	SELECT *
	FROM CATEGORIES;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategory]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategory]
		@id int
AS
BEGIN
	SELECT *
	FROM CATEGORIES
	WHERE CategoryId=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetDetailedLog]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDetailedLog]
	@userId bigint,
	@startDate datetime,
	@endDate datetime
AS
BEGIN
	SELECT *
	FROM ACCOUNTING_LOG
	WHERE UserId=@userId AND (DateTime BETWEEN @startDate AND @endDate);
END
GO
/****** Object:  StoredProcedure [dbo].[GetFranchiseManager]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFranchiseManager]
		@id bigint
AS
BEGIN
	SELECT u.*, f.FranchiseLocation, f.FranchiseNumber
	FROM FRANCHISE_MANAGERS f, USERS u
	WHERE f.UserId=@id and u.UserId=f.UserId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetFranchiseManagers]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFranchiseManagers]
AS
BEGIN
	SELECT [UserId]
	FROM FRANCHISE_MANAGERS;
END
GO
/****** Object:  StoredProcedure [dbo].[GetInterestedAdvertisements]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInterestedAdvertisements]
		@userId bigint
AS
BEGIN
	SELECT AdId
	FROM PRIMARY_USER_ADDS_ADVERTISEMET_INTO_INTEREST
	WHERE UserId=@userId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetOnlinePaymentLog]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOnlinePaymentLog]
		@userId bigint
AS
BEGIN
	SELECT *
	FROM ONLINE_PAYMENT_LOG
	WHERE UserId=@userId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPrimaryUser]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPrimaryUser]
		@id bigint
AS
BEGIN
	SELECT U.*, CNIC
	FROM PRIMARY_USERS P, USERS U
	WHERE U.UserId=P.UserId AND P.UserId=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPrimaryUsers]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPrimaryUsers]
AS
BEGIN
	SELECT UserId
	FROM PRIMARY_USERS P;
END
GO
/****** Object:  StoredProcedure [dbo].[GetToken]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetToken]
		@id bigint
AS
BEGIN
	SELECT *
	FROM TOKENS
	WHERE TokenId=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByUserName]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByUserName]
		@username nvarchar(256)
AS
BEGIN
	SELECT ui.UserId
	FROM USER_HAS_IDENTITY ui, dbo.AspNetUsers i
	WHERE i.UserName=@username AND ui.IdentityId=i.Id; 
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsers]
AS
BEGIN
	SELECT *
	FROM [USERS];
END
GO
/****** Object:  StoredProcedure [dbo].[PayForAuction]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PayForAuction] 
	@userId bigint,
	@aId bigint,
	@price money
AS
BEGIN
	UPDATE ADVERTISEMENTS
	SET [WinnerId]=@userId, [Price]=@price
	WHERE AdId=@aId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAdWinner]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAdWinner]
	@adId bigint,
	@userId bigint,
	@soldPrice money
AS
BEGIN
	UPDATE ADVERTISEMENTS
	SET WinnerId=@userId, SoldPrice=@soldPrice
	WHERE AdId=@adId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserName]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUserName]
	@firstName varchar(max),
	@lastName varchar(max),
	@userId bigint
AS
BEGIN
	UPDATE USERS
	SET FirstName=@firstName, LastName=@lastName
	WHERE UserId=@userId;
END
GO
/****** Object:  StoredProcedure [dbo].[UserTokenToAuction]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserTokenToAuction]
	@userId bigint,
	@aId bigint,
	@tokenId bigint
AS
BEGIN
	INSERT INTO [dbo].[PRIMARY_USER_GETS_TOKEN_ON_AUCTION]
           ([UserId]
           ,[TokenId]
           ,[AuctionId])
     VALUES
           (@userId
           ,@aId
           ,@tokenId);

	--SELECT SCOPE_IDENTITY() AS PK;
END
GO
/****** Object:  StoredProcedure [dbo].[VerifyAd]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerifyAd]
	@adId bigint
AS
BEGIN
	UPDATE ADVERTISEMENTS
	SET IsVerified=1
	WHERE AdId=@adId;
END
GO
/****** Object:  StoredProcedure [dbo].[VerifyToken]    Script Date: 1/25/2020 7:00:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerifyToken]
		@token varchar(max),
		@userId bigint,
		@auctionId bigint
AS
BEGIN
	IF EXISTS(SELECT * FROM PRIMARY_USER_GETS_TOKEN_ON_AUCTION UT, TOKENS T WHERE T.HashKey=@token AND UT.TokenId=T.TokenId AND UT.AuctionId=@auctionId)
	BEGIN
		SELECT 1;
	END
	ELSE
	BEGIN
		SELECT 2;
	END
END
GO
ALTER DATABASE [AuctionItDb] SET  READ_WRITE 
GO
