USE [master]
GO
/****** Object:  Database [QuanLyBanSachbyMinh]    Script Date: 5/17/2020 10:38:14 PM ******/
CREATE DATABASE [QuanLyBanSachbyMinh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyBanSachbyMinh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\QuanLyBanSachbyMinh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyBanSachbyMinh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\QuanLyBanSachbyMinh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyBanSachbyMinh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET QUERY_STORE = OFF
GO
USE [QuanLyBanSachbyMinh]
GO
/****** Object:  Table [dbo].[Chinhanh]    Script Date: 5/17/2020 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chinhanh](
	[Macn] [int] IDENTITY(1,1) NOT NULL,
	[Tencn] [nvarchar](100) NULL,
	[Diachi] [nvarchar](100) NULL,
	[Sdt] [varchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Hinh] [nvarchar](200) NULL,
 CONSTRAINT [PK_Chinhanh] PRIMARY KEY CLUSTERED 
(
	[Macn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietGioHang]    Script Date: 5/17/2020 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietGioHang](
	[ChitietgiohangID] [int] IDENTITY(1,1) NOT NULL,
	[GiohangkhID] [int] NULL,
	[Masach] [int] NULL,
	[Soluong] [int] NULL,
	[Thanhtien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietGioHang] PRIMARY KEY CLUSTERED 
(
	[ChitietgiohangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chude]    Script Date: 5/17/2020 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chude](
	[Macd] [int] IDENTITY(1,1) NOT NULL,
	[Tenchude] [nvarchar](100) NULL,
	[Key] [varchar](30) NULL,
 CONSTRAINT [PK_Chude] PRIMARY KEY CLUSTERED 
(
	[Macd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Giohangkh]    Script Date: 5/17/2020 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giohangkh](
	[GiohangkhID] [int] IDENTITY(1,1) NOT NULL,
	[Makh] [int] NULL,
	[Ngaymua] [smalldatetime] NULL,
	[Tongtien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Giohangkh] PRIMARY KEY CLUSTERED 
(
	[GiohangkhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khachhang]    Script Date: 5/17/2020 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khachhang](
	[Makh] [int] IDENTITY(1,1) NOT NULL,
	[Hotenkh] [nvarchar](100) NULL,
	[Diachikh] [nvarchar](100) NULL,
	[Dienthoaikh] [varchar](20) NULL,
	[Tendn] [nvarchar](50) NULL,
	[Matkhau] [nvarchar](100) NULL,
	[Ngaysinh] [smalldatetime] NULL,
	[Gioitinh] [bit] NULL,
	[Email] [nvarchar](100) NULL,
	[Quyen] [int] NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY CLUSTERED 
(
	[Makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhaxuatban]    Script Date: 5/17/2020 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhaxuatban](
	[Manxb] [int] IDENTITY(1,1) NOT NULL,
	[Tennxb] [nvarchar](100) NULL,
 CONSTRAINT [PK_Nhaxuatban] PRIMARY KEY CLUSTERED 
(
	[Manxb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 5/17/2020 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[Masach] [int] IDENTITY(1,1) NOT NULL,
	[Tensach] [nvarchar](200) NULL,
	[Dongia] [decimal](18, 0) NULL,
	[Donvitinh] [nvarchar](10) NULL,
	[Mota] [ntext] NULL,
	[Hinhminhhoa] [nvarchar](200) NULL,
	[Macd] [int] NULL,
	[Manxb] [int] NULL,
	[Ngaycapnhat] [smalldatetime] NULL,
	[Matacgia] [int] NULL,
	[Soluong] [int] NULL,
	[Giakm] [decimal](18, 0) NULL,
	[Motangangon] [ntext] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tacgia]    Script Date: 5/17/2020 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tacgia](
	[Matacgia] [int] IDENTITY(1,1) NOT NULL,
	[Tentacgia] [nvarchar](100) NULL,
 CONSTRAINT [PK_Tacgia] PRIMARY KEY CLUSTERED 
(
	[Matacgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietGioHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGioHang_Giohangkh] FOREIGN KEY([GiohangkhID])
REFERENCES [dbo].[Giohangkh] ([GiohangkhID])
GO
ALTER TABLE [dbo].[ChiTietGioHang] CHECK CONSTRAINT [FK_ChiTietGioHang_Giohangkh]
GO
ALTER TABLE [dbo].[ChiTietGioHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGioHang_Sach] FOREIGN KEY([Masach])
REFERENCES [dbo].[Sach] ([Masach])
GO
ALTER TABLE [dbo].[ChiTietGioHang] CHECK CONSTRAINT [FK_ChiTietGioHang_Sach]
GO
ALTER TABLE [dbo].[Giohangkh]  WITH CHECK ADD  CONSTRAINT [FK_Giohangkh_Khachhang] FOREIGN KEY([Makh])
REFERENCES [dbo].[Khachhang] ([Makh])
GO
ALTER TABLE [dbo].[Giohangkh] CHECK CONSTRAINT [FK_Giohangkh_Khachhang]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_Chude] FOREIGN KEY([Macd])
REFERENCES [dbo].[Chude] ([Macd])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_Chude]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_Nhaxuatban] FOREIGN KEY([Manxb])
REFERENCES [dbo].[Nhaxuatban] ([Manxb])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_Nhaxuatban]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_Tacgia] FOREIGN KEY([Matacgia])
REFERENCES [dbo].[Tacgia] ([Matacgia])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_Tacgia]
GO
USE [master]
GO
ALTER DATABASE [QuanLyBanSachbyMinh] SET  READ_WRITE 
GO
