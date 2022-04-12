CREATE DATABASE [ITD_QL_NGAYPHEP_NV]
GO
USE [ITD_QL_NGAYPHEP_NV]
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 12/04/22 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [nvarchar](max) NULL,
	[PASSWORK] [nvarchar](max) NULL,
	[ID_QUYEN] [int] NULL,
	[ID_NHANVIEN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUC_VU]    Script Date: 12/04/22 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUC_VU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MACV] [nvarchar](max) NULL,
	[TENCV] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUCVU_NHANVIEN]    Script Date: 12/04/22 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU_NHANVIEN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_CHUCVU] [int] NULL,
	[ID_NHANVIEN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DON_XIN_NGHI_PHEP]    Script Date: 12/04/22 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DON_XIN_NGHI_PHEP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAPHEP] [nvarchar](max) NULL,
	[NGAYBATDAUNGHI] [datetime] NULL,
	[NGAYDILAMLAI] [datetime] NULL,
	[TRANGTHAI] [nvarchar](max) NULL,
	[ID_NHANVIEN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LEVEL_USER]    Script Date: 12/04/22 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LEVEL_USER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QUYEN] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGHI_PHEP]    Script Date: 12/04/22 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGHI_PHEP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PHEP] [int] NULL,
	[NAM] [int] NULL,
	[ID_NHANVIEN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHAN_VIEN]    Script Date: 12/04/22 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAN_VIEN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MANV] [nvarchar](max) NULL,
	[HOTEN] [nvarchar](max) NULL,
	[GIOITINH] [nvarchar](max) NULL,
	[NGAYSINH] [datetime] NULL,
	[SODIENTHOAI] [nvarchar](max) NULL,
	[EMAIL] [nvarchar](max) NULL,
	[DIACHI] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG_BAN]    Script Date: 12/04/22 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG_BAN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAPB] [nvarchar](max) NULL,
	[TENPB] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONGBAN_NHANVIEN]    Script Date: 12/04/22 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONGBAN_NHANVIEN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_PHONGBAN] [int] NULL,
	[ID_NHANVIEN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ACCOUNT] ON 

INSERT [dbo].[ACCOUNT] ([ID], [USERNAME], [PASSWORK], [ID_QUYEN], [ID_NHANVIEN]) VALUES (1, N'admin', N'5FabWiVn4dg=', 1, NULL)
SET IDENTITY_INSERT [dbo].[ACCOUNT] OFF
GO
SET IDENTITY_INSERT [dbo].[LEVEL_USER] ON 

INSERT [dbo].[LEVEL_USER] ([ID], [QUYEN]) VALUES (1, N'ADMIN')
INSERT [dbo].[LEVEL_USER] ([ID], [QUYEN]) VALUES (2, N'QUẢN LÝ')
INSERT [dbo].[LEVEL_USER] ([ID], [QUYEN]) VALUES (3, N'TRƯỞNG PHÒNG')
INSERT [dbo].[LEVEL_USER] ([ID], [QUYEN]) VALUES (4, N'NHÂN VIÊN')
SET IDENTITY_INSERT [dbo].[LEVEL_USER] OFF
GO
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD FOREIGN KEY([ID_NHANVIEN])
REFERENCES [dbo].[NHAN_VIEN] ([ID])
GO
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD FOREIGN KEY([ID_QUYEN])
REFERENCES [dbo].[LEVEL_USER] ([ID])
GO
ALTER TABLE [dbo].[CHUCVU_NHANVIEN]  WITH CHECK ADD FOREIGN KEY([ID_CHUCVU])
REFERENCES [dbo].[CHUC_VU] ([ID])
GO
ALTER TABLE [dbo].[CHUCVU_NHANVIEN]  WITH CHECK ADD FOREIGN KEY([ID_NHANVIEN])
REFERENCES [dbo].[NHAN_VIEN] ([ID])
GO
ALTER TABLE [dbo].[DON_XIN_NGHI_PHEP]  WITH CHECK ADD FOREIGN KEY([ID_NHANVIEN])
REFERENCES [dbo].[NHAN_VIEN] ([ID])
GO
ALTER TABLE [dbo].[NGHI_PHEP]  WITH CHECK ADD FOREIGN KEY([ID_NHANVIEN])
REFERENCES [dbo].[NHAN_VIEN] ([ID])
GO
ALTER TABLE [dbo].[PHONGBAN_NHANVIEN]  WITH CHECK ADD FOREIGN KEY([ID_NHANVIEN])
REFERENCES [dbo].[NHAN_VIEN] ([ID])
GO
ALTER TABLE [dbo].[PHONGBAN_NHANVIEN]  WITH CHECK ADD FOREIGN KEY([ID_PHONGBAN])
REFERENCES [dbo].[PHONG_BAN] ([ID])
GO
