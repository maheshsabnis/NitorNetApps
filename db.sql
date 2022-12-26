USE [master]
GO

/****** Object:  Database [Company]    Script Date: 12/26/2022 11:23:58 AM ******/
CREATE DATABASE [Company]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Company', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Company.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Company_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Company_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Company].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Company] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Company] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Company] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Company] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Company] SET ARITHABORT OFF 
GO

ALTER DATABASE [Company] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Company] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Company] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Company] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Company] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Company] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Company] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Company] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Company] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Company] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Company] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Company] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Company] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Company] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Company] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Company] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Company] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Company] SET RECOVERY FULL 
GO

ALTER DATABASE [Company] SET  MULTI_USER 
GO

ALTER DATABASE [Company] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Company] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Company] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Company] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Company] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Company] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Company] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Company] SET  READ_WRITE 
GO

