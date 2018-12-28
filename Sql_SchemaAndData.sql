USE [saglikDB]
GO
/****** Object:  User [admin]    Script Date: 28.12.2018 05:07:26 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[birey]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[birey](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tckimlikno] [bigint] NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[dogumyeri] [nvarchar](25) NULL,
	[dtarihi] [datetime] NULL,
	[cinsiyet] [nvarchar](10) NULL,
	[kangrubu] [nvarchar](10) NULL,
	[medenihal] [nvarchar](10) NULL,
	[anneadi] [nvarchar](50) NULL,
	[babaadi] [nvarchar](50) NULL,
	[evtel] [nvarchar](15) NULL,
	[ceptel] [nvarchar](15) NULL,
	[adres] [nvarchar](200) NULL,
 CONSTRAINT [PK_birey] PRIMARY KEY CLUSTERED 
(
	[tckimlikno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doktor]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doktor](
	[doktorid] [int] IDENTITY(1,1) NOT NULL,
	[tckimlikno] [bigint] NOT NULL,
 CONSTRAINT [PK_doktor] PRIMARY KEY CLUSTERED 
(
	[doktorid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dosya]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dosya](
	[dosyaid] [int] IDENTITY(1,1) NOT NULL,
	[dosyatarihi] [datetime] NULL,
	[hastatckimlikno] [bigint] NOT NULL,
 CONSTRAINT [PK_dosya] PRIMARY KEY CLUSTERED 
(
	[dosyaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hasta]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hasta](
	[tckimlikno] [bigint] NOT NULL,
	[dosyaID] [int] NOT NULL,
	[kurumsicilno] [nvarchar](10) NULL,
	[kurumadi] [nvarchar](50) NULL,
	[yakintel] [nvarchar](11) NULL,
	[yakinkurumsicilno] [nvarchar](10) NULL,
	[yakinkurumadi] [nvarchar](50) NULL,
 CONSTRAINT [PK__hasta__C76A2206C0793F4B] PRIMARY KEY CLUSTERED 
(
	[tckimlikno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[islem]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[islem](
	[islemid] [int] IDENTITY(1,1) NOT NULL,
	[islemadi] [nvarchar](50) NOT NULL,
	[birimfiyat] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_islem] PRIMARY KEY CLUSTERED 
(
	[islemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[islemler]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[islemler](
	[sevktarihi] [datetime] NOT NULL,
	[islemid] [int] NOT NULL,
	[personelid] [int] NOT NULL,
	[miktar] [int] NULL,
 CONSTRAINT [PK_yapilanislemler] PRIMARY KEY CLUSTERED 
(
	[sevktarihi] ASC,
	[islemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanicilar]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanicilar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tckimlikno] [bigint] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[sifre] [nvarchar](50) NOT NULL,
	[yetki] [nvarchar](20) NOT NULL,
	[unvan] [nvarchar](30) NULL,
	[isebaslama] [datetime] NULL,
	[maas] [nvarchar](10) NULL,
 CONSTRAINT [PK_kullanicilar] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[odeme]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[odeme](
	[odemeid] [int] IDENTITY(1,1) NOT NULL,
	[yontemadi] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_odeme] PRIMARY KEY CLUSTERED 
(
	[odemeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personel]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personel](
	[personelid] [int] IDENTITY(1,1) NOT NULL,
	[tckimlikno] [bigint] NOT NULL,
 CONSTRAINT [PK_personel] PRIMARY KEY CLUSTERED 
(
	[personelid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[poliklinik]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[poliklinik](
	[poliklinikadi] [nvarchar](100) NOT NULL,
	[durum] [nvarchar](5) NULL,
	[aciklama] [nvarchar](255) NULL,
	[bolumid] [int] NOT NULL,
 CONSTRAINT [PK__poliklin__C77F0B27A064CC67] PRIMARY KEY CLUSTERED 
(
	[poliklinikadi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[poliklinik_isim]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[poliklinik_isim](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isim] [nvarchar](120) NULL,
 CONSTRAINT [PK_poliklinik_isim] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sevk]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sevk](
	[sevktarihi] [datetime] NOT NULL,
	[dosyaid] [int] NOT NULL,
	[sevkedendoktorid] [int] NOT NULL,
	[poliklinik] [nvarchar](100) NOT NULL,
	[sira] [nvarchar](5) NULL,
	[saat] [nvarchar](10) NULL,
	[taburcuid] [int] NOT NULL,
 CONSTRAINT [PK_sevk_1] PRIMARY KEY CLUSTERED 
(
	[sevktarihi] ASC,
	[dosyaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taburcu]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taburcu](
	[taburcuid] [int] IDENTITY(1,1) NOT NULL,
	[cikisSaati] [datetime] NULL,
	[odemeid] [int] NULL,
	[taburcuoldumu] [bit] NOT NULL,
	[toplamtutar] [nchar](20) NULL,
 CONSTRAINT [PK_taburcu] PRIMARY KEY CLUSTERED 
(
	[taburcuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[birey] ON 
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (6, 21354564564, N'kamuran', N'öncü', N'adana', CAST(N'2018-12-28T00:27:02.980' AS DateTime), N'0', N'A Rh+', N'0', N'aysel', N'ümit', N'', N'5348645635', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (12, 21383126876, N'Bilal', N'Sancak', N'', CAST(N'2018-12-28T01:07:05.043' AS DateTime), N'0', N'', N'-1', N'', N'', N'', N'5416486564', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (24, 23123211231, N'sfsde', N'sefsefse', N'', CAST(N'2018-12-28T04:28:26.913' AS DateTime), N'1', N'', N'-1', N'', N'', N'', N'1111111111', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (23, 24645646884, N'wdfawd', N'wadwad', N'', CAST(N'2018-12-28T04:27:42.023' AS DateTime), N'1', N'', N'-1', N'', N'', N'', N'1111111111', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (20, 45456456456, N'İsmail', N'bakar', N'', CAST(N'2018-12-28T02:19:28.487' AS DateTime), N'0', N'', N'-1', N'', N'', N'3325864876', N'5124656786', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (22, 45464654654, N'test', N'12131', N'', CAST(N'2018-12-28T04:24:30.520' AS DateTime), N'0', N'', N'-1', N'', N'', N'', N'1111111111', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (1, 45645645645, N'Mustafa', N'kuru', N'konya', CAST(N'2018-12-27T12:55:53.333' AS DateTime), N'0', N'A Rh+', N'1', N'davut', N'şükran', N'', N'1111111111', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (11, 46456484568, N'Ayşe', N'Sezer', N'Tekirdağ', CAST(N'2018-12-28T01:05:30.340' AS DateTime), N'1', N'', N'0', N'Kezban', N'Mehmet', N'', N'5465423123', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (7, 52413124534, N'Sami', N'uyar', N'mersin', CAST(N'2018-12-28T00:28:06.520' AS DateTime), N'0', N'B rh -', N'0', N'betül', N'kemal', N'3534564564', N'5454684531', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (18, 54164564565, N'Aykut', N'Burçak', N'', CAST(N'2018-12-28T02:01:54.287' AS DateTime), N'0', N'', N'-1', N'', N'', N'7556464554', N'5645645321', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (8, 54645645645, N'Zeki', N'bayar', N'bursa', CAST(N'2018-12-28T01:02:11.367' AS DateTime), N'0', N'', N'0', N'melike', N'hasan', N'3636454654', N'5545318645', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (13, 54646864786, N'Osman', N'uysal', N'', CAST(N'2018-12-28T01:13:28.230' AS DateTime), N'0', N'', N'-1', N'', N'', N'', N'5684267864', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (9, 56456456456, N'Hüseyin', N'Aydın', N'manisa', CAST(N'2018-12-28T01:03:29.853' AS DateTime), N'0', N'', N'1', N'fatma', N'adem', N'', N'5555865456', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (14, 56489645645, N'Sayit', N'Kazan', N'', CAST(N'2018-12-28T01:13:56.110' AS DateTime), N'0', N'', N'-1', N'', N'', N'', N'5546854163', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (21, 64564864563, N'Sadrettin', N'baltacı', N'', CAST(N'2018-12-28T03:03:13.200' AS DateTime), N'0', N'', N'-1', N'', N'', N'3764646456', N'5696967408', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (19, 64567864854, N'aykut', N'soner', N'', CAST(N'2018-12-28T02:10:20.210' AS DateTime), N'0', N'', N'-1', N'', N'', N'3355213546', N'5568621323', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (16, 65432786786, N'Selda', N'baytar', N'', CAST(N'2018-12-28T01:14:37.827' AS DateTime), N'1', N'', N'-1', N'', N'', N'', N'5175454587', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (15, 95313215786, N'Büşra', N'şimşek', N'', CAST(N'2018-12-28T01:14:17.440' AS DateTime), N'1', N'', N'-1', N'', N'', N'', N'5456832685', N'')
GO
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (10, 96876543216, N'Ahmet', N'Tek', N'Ankara', CAST(N'2018-12-28T01:04:42.693' AS DateTime), N'0', N'', N'0', N'', N'', N'', N'5321546564', N'')
GO
SET IDENTITY_INSERT [dbo].[birey] OFF
GO
SET IDENTITY_INSERT [dbo].[doktor] ON 
GO
INSERT [dbo].[doktor] ([doktorid], [tckimlikno]) VALUES (1, 56456456456)
GO
INSERT [dbo].[doktor] ([doktorid], [tckimlikno]) VALUES (2, 96876543216)
GO
INSERT [dbo].[doktor] ([doktorid], [tckimlikno]) VALUES (3, 46456484568)
GO
INSERT [dbo].[doktor] ([doktorid], [tckimlikno]) VALUES (4, 21383126876)
GO
SET IDENTITY_INSERT [dbo].[doktor] OFF
GO
SET IDENTITY_INSERT [dbo].[dosya] ON 
GO
INSERT [dbo].[dosya] ([dosyaid], [dosyatarihi], [hastatckimlikno]) VALUES (1, CAST(N'2018-12-28T00:28:04.103' AS DateTime), 21354564564)
GO
INSERT [dbo].[dosya] ([dosyaid], [dosyatarihi], [hastatckimlikno]) VALUES (2, CAST(N'2018-12-28T00:29:14.237' AS DateTime), 52413124534)
GO
INSERT [dbo].[dosya] ([dosyaid], [dosyatarihi], [hastatckimlikno]) VALUES (3, CAST(N'2018-12-28T02:20:13.747' AS DateTime), 45456456456)
GO
INSERT [dbo].[dosya] ([dosyaid], [dosyatarihi], [hastatckimlikno]) VALUES (4, CAST(N'2018-12-28T03:03:51.820' AS DateTime), 64564864563)
GO
SET IDENTITY_INSERT [dbo].[dosya] OFF
GO
INSERT [dbo].[hasta] ([tckimlikno], [dosyaID], [kurumsicilno], [kurumadi], [yakintel], [yakinkurumsicilno], [yakinkurumadi]) VALUES (21354564564, 1, N'123156456', N'238645685', N'5645386456', N'123456486', N'123864457')
GO
INSERT [dbo].[hasta] ([tckimlikno], [dosyaID], [kurumsicilno], [kurumadi], [yakintel], [yakinkurumsicilno], [yakinkurumadi]) VALUES (45456456456, 3, N'456545646', N'695463289', N'5348965434', N'231967578', N'215796789')
GO
INSERT [dbo].[hasta] ([tckimlikno], [dosyaID], [kurumsicilno], [kurumadi], [yakintel], [yakinkurumsicilno], [yakinkurumadi]) VALUES (52413124534, 2, N'126315654', N'384656448', N'5684565465', N'456463532', N'786456328')
GO
INSERT [dbo].[hasta] ([tckimlikno], [dosyaID], [kurumsicilno], [kurumadi], [yakintel], [yakinkurumsicilno], [yakinkurumadi]) VALUES (64564864563, 4, N'546486486', N'546865466', N'5648654654', N'157686786', N'456786541')
GO
SET IDENTITY_INSERT [dbo].[islem] ON 
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (1, N'muayene', N'100')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (2, N'ameliyat', N'1250')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (3, N'kontrol', N'50')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (4, N'uygunluk kontrol', N'175')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (5, N'Tansiyon Ölçme', N'25')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (6, N'M.R. Çekimi', N'500')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (7, N'Röntgen', N'225')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (8, N'Platin Diş', N'2275')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (9, N'Ortopedik Ayakkabı', N'775')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (10, N'İşitme Testi', N'280')
GO
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (11, N'Anju Ameliyatı', N'2285')
GO
SET IDENTITY_INSERT [dbo].[islem] OFF
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T01:13:25.463' AS DateTime), 1, 1, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T01:13:25.463' AS DateTime), 3, 1, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T01:50:50.153' AS DateTime), 2, 1, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T01:50:50.153' AS DateTime), 3, 3, 5)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T01:50:50.153' AS DateTime), 5, 1, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T01:50:50.153' AS DateTime), 10, 5, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T02:34:20.753' AS DateTime), 3, 1, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T02:34:20.753' AS DateTime), 6, 3, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T02:34:20.753' AS DateTime), 7, 2, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T02:34:20.753' AS DateTime), 8, 2, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T02:34:20.753' AS DateTime), 10, 2, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T02:34:20.753' AS DateTime), 11, 3, 1)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T02:40:19.437' AS DateTime), 2, 3, 2)
GO
INSERT [dbo].[islemler] ([sevktarihi], [islemid], [personelid], [miktar]) VALUES (CAST(N'2018-12-28T02:51:30.060' AS DateTime), 10, 5, 1)
GO
SET IDENTITY_INSERT [dbo].[kullanicilar] ON 
GO
INSERT [dbo].[kullanicilar] ([id], [tckimlikno], [username], [sifre], [yetki], [unvan], [isebaslama], [maas]) VALUES (4, 64567864854, N'aykut_123', N'123456', N'0', N'işci', CAST(N'2018-12-28T02:10:20.207' AS DateTime), N'')
GO
INSERT [dbo].[kullanicilar] ([id], [tckimlikno], [username], [sifre], [yetki], [unvan], [isebaslama], [maas]) VALUES (1, 45645645645, N'hepter', N'123456', N'1', N'Öğrenci', CAST(N'2018-12-27T05:19:19.067' AS DateTime), N'')
GO
SET IDENTITY_INSERT [dbo].[kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[odeme] ON 
GO
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (1, N'Nakit')
GO
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (2, N'Kredi Kartı - Tek Çekim')
GO
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (3, N'Havale')
GO
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (4, N'Senet')
GO
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (5, N'Kredi Kartı - 6 Ay taksit')
GO
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (6, N'Kredi Kartı - 12 Ay taksit')
GO
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (7, N'Kredi Kartı - 24 Ay taksit')
GO
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (8, N'Çek')
GO
SET IDENTITY_INSERT [dbo].[odeme] OFF
GO
SET IDENTITY_INSERT [dbo].[personel] ON 
GO
INSERT [dbo].[personel] ([personelid], [tckimlikno]) VALUES (1, 54645645645)
GO
INSERT [dbo].[personel] ([personelid], [tckimlikno]) VALUES (2, 54646864786)
GO
INSERT [dbo].[personel] ([personelid], [tckimlikno]) VALUES (3, 56489645645)
GO
INSERT [dbo].[personel] ([personelid], [tckimlikno]) VALUES (4, 95313215786)
GO
INSERT [dbo].[personel] ([personelid], [tckimlikno]) VALUES (5, 65432786786)
GO
SET IDENTITY_INSERT [dbo].[personel] OFF
GO
INSERT [dbo].[poliklinik] ([poliklinikadi], [durum], [aciklama], [bolumid]) VALUES (N'Cerrahi-1', N'1', N'', 44)
GO
INSERT [dbo].[poliklinik] ([poliklinikadi], [durum], [aciklama], [bolumid]) VALUES (N'Cerrahi-2', N'1', N'', 44)
GO
INSERT [dbo].[poliklinik] ([poliklinikadi], [durum], [aciklama], [bolumid]) VALUES (N'Diş - 1 (Yedek Bina)', N'1', N'', 2)
GO
INSERT [dbo].[poliklinik] ([poliklinikadi], [durum], [aciklama], [bolumid]) VALUES (N'kulak', N'1', N'', 43)
GO
INSERT [dbo].[poliklinik] ([poliklinikadi], [durum], [aciklama], [bolumid]) VALUES (N'Obezite - 1', N'1', N'', 78)
GO
INSERT [dbo].[poliklinik] ([poliklinikadi], [durum], [aciklama], [bolumid]) VALUES (N'platin', N'1', N'', 16)
GO
SET IDENTITY_INSERT [dbo].[poliklinik_isim] ON 
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (1, N'Acil Servis')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (2, N'Agiz ve Dis Sagligi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (3, N'Agri Poliklinigi (Algoloji)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (4, N'Akupunktur Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (5, N'Alerji Hastaliklari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (6, N'Androloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (7, N'Anestezi ve Reanimasyon')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (8, N'Ayak Sagligi Merkez')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (9, N'Bakteriyoloji ve Mikrobiyoloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (10, N'Bas Agrisi Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (11, N'Beslenme ve Diyet')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (12, N'Beyin Sagligi Koruma Programi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (13, N'Beyin ve Sinir Cerrahisi (Nörosirürji)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (14, N'Biyokimya Laboratuvari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (15, N'Böbrek Nakli Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (16, N'Check Up Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (17, N'Çocuk Allerjisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (18, N'Çocuk Cerrahisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (19, N'Çocuk Endokrinolojisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (20, N'Çocuk Enfeksiyon Hastaliklari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (21, N'Çocuk Ergen ve Ruh Sagligi (Çocuk Psikiyatrisi)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (22, N'Çocuk Gastroenterolojisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (23, N'Çocuk Gögüs Hastaliklari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (24, N'Çocuk Hematolojisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (25, N'Çocuk Kardiyolojisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (26, N'Çocuk Kemik Iligi Nakli Ünitesi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (27, N'Çocuk Nefrolojisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (28, N'Çocuk Nörolojisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (29, N'Çocuk Onkolojisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (30, N'Çocuk Sagligi ve Hastaliklari (Pediatri)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (31, N'Çocuk Ürolojisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (32, N'Çocuk ve Genç Sporcu Sagligi Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (33, N'Deri ve Zührevi Hastaliklari (Dermatoloji)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (34, N'Doku Tipleme ve Immünoloji Laboratuvari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (35, N'Elekta Versa HD SIGNATURE')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (36, N'Endokrinoloji ve Metabolizma Hastaliklari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (37, N'Endometriozis Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (38, N'Enfeksiyon Hastaliklari ve Klinik Mikrobiyoloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (39, N'Estetik, Plastik ve Rekonstrüktif Cerrahi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (40, N'Evde Bakim Hizmetleri')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (41, N'Fizik Tedavi ve Rehabilitasyon')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (42, N'Gastroenteroloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (43, N'Genel Cerrahi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (44, N'Genel Yogun Bakim')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (45, N'Genetik Kanser Poliklinigi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (46, N'Genetik Laboratuvari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (47, N'Girisimsel Nöroradyoloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (48, N'Girisimsel Radyoloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (49, N'Gögüs Cerrahisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (50, N'Gögüs Hastaliklari (Akciger Hastaliklari)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (51, N'Göz Hastaliklari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (52, N'Hastane Direktörlügü')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (53, N'Havacilik Tip Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (54, N'Hematoloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (55, N'Iç Hastaliklari (Dahiliye)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (56, N'Inme ve Beyin Hasari Rehabilitasyon Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (57, N'Istahsiz Çocuk Poliklinigi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (58, N'Jinekolojik Onkoloji (Kadin Kanserleri)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (59, N'Kadin Hastaliklari ve Dogum')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (60, N'Kalp ve Damar Cerrahisi (KVC)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (61, N'Karaciger Nakli Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (62, N'Kardiyoloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (63, N'Kas ve Sinir Hastaliklari Merkezi (Nöromusküler Hastaliklar)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (64, N'Kat ve Triaj Hekimligi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (65, N'Kemik Iligi Nakli Merkezi (Kök Hücre Nakli Merkezi)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (66, N'Kemoterapi (Tibbi Onkoloji)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (67, N'Koroner Yogun Bakim Ünitesi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (68, N'Kozmetik Dermatoloji (Kozmetoloji)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (69, N'Kulak Burun Bogaz Hastaliklari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (70, N'KVC Yogun Bakim Ünitesi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (71, N'Liyezon Psikiyatrisi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (72, N'Meme Sagligi Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (73, N'Mezoterapi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (74, N'Mikrobiyoloji Laboratuvari')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (75, N'Nefroloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (76, N'Nöroloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (77, N'Nükleer Tip')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (78, N'Obezite Cerrahisi Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (79, N'Omurga Sagligi Ünitesi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (80, N'Onkoloji Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (81, N'Organ Nakli Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (82, N'Ortopedi ve Travmatoloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (83, N'Pedagoji (Çocuk ve Ergen Psikolojisi)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (84, N'Perinatal Tani ve Tedavi Merkezi (Riskli Gebelikler)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (85, N'Perinatoloji (Yüksek Riskli Gebelik)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (86, N'PET/CT')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (87, N'Proktoloji Merkezi (Hemoroid ve Anorektal Hastaliklar Ünitesi)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (88, N'Psikiyatri')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (89, N'Psikoloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (90, N'Radyasyon Onkolojisi(Radyoterapi)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (91, N'Radyoloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (92, N'Radyonüklid Tedavi Ünitesi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (93, N'Robotik Cerrahi Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (94, N'Robotik Rehabilitasyon Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (95, N'Saç Ekimi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (96, N'Solunum Terapisi Merkezi (Nefes Terapisi)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (97, N'Tanisi Konulamayan Hastaliklar Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (98, N'Tibbi Onkoloji (Kemoterapi)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (99, N'Tomosentez')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (100, N'Transfüzyon Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (101, N'TrueBeam')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (102, N'Tüp Bebek (IVF) ve Üreme Sagligi Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (103, N'Uyku Bozuklugu Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (104, N'Ürojinekoloji (Kadin Üroloji Merkezi)')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (105, N'Üroloji')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (106, N'Yara Analizi ve Tedavi Merkezi')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (107, N'Yenidogan Yogun Bakim Ünitesi')
GO
SET IDENTITY_INSERT [dbo].[poliklinik_isim] OFF
GO
INSERT [dbo].[sevk] ([sevktarihi], [dosyaid], [sevkedendoktorid], [poliklinik], [sira], [saat], [taburcuid]) VALUES (CAST(N'2018-12-28T01:13:25.463' AS DateTime), 2, 1, N'kulak', N'10', N'01:13:25', 3)
GO
INSERT [dbo].[sevk] ([sevktarihi], [dosyaid], [sevkedendoktorid], [poliklinik], [sira], [saat], [taburcuid]) VALUES (CAST(N'2018-12-28T01:50:50.153' AS DateTime), 2, 4, N'Obezite - 1', N'11', N'01:50:50', 4)
GO
INSERT [dbo].[sevk] ([sevktarihi], [dosyaid], [sevkedendoktorid], [poliklinik], [sira], [saat], [taburcuid]) VALUES (CAST(N'2018-12-28T02:34:20.753' AS DateTime), 2, 3, N'Cerrahi-1', N'121', N'02:34:20', 5)
GO
INSERT [dbo].[sevk] ([sevktarihi], [dosyaid], [sevkedendoktorid], [poliklinik], [sira], [saat], [taburcuid]) VALUES (CAST(N'2018-12-28T02:40:19.437' AS DateTime), 1, 1, N'Obezite - 1', N'54654', N'02:40:19', 6)
GO
INSERT [dbo].[sevk] ([sevktarihi], [dosyaid], [sevkedendoktorid], [poliklinik], [sira], [saat], [taburcuid]) VALUES (CAST(N'2018-12-28T02:51:30.060' AS DateTime), 1, 4, N'kulak', N'54', N'02:51:30', 7)
GO
SET IDENTITY_INSERT [dbo].[taburcu] ON 
GO
INSERT [dbo].[taburcu] ([taburcuid], [cikisSaati], [odemeid], [taburcuoldumu], [toplamtutar]) VALUES (3, CAST(N'2018-12-28T02:42:19.937' AS DateTime), 2, 1, N'150                 ')
GO
INSERT [dbo].[taburcu] ([taburcuid], [cikisSaati], [odemeid], [taburcuoldumu], [toplamtutar]) VALUES (4, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[taburcu] ([taburcuid], [cikisSaati], [odemeid], [taburcuoldumu], [toplamtutar]) VALUES (5, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[taburcu] ([taburcuid], [cikisSaati], [odemeid], [taburcuoldumu], [toplamtutar]) VALUES (6, CAST(N'2018-12-28T02:41:19.080' AS DateTime), 7, 1, N'2500                ')
GO
INSERT [dbo].[taburcu] ([taburcuid], [cikisSaati], [odemeid], [taburcuoldumu], [toplamtutar]) VALUES (7, NULL, NULL, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[taburcu] OFF
GO
ALTER TABLE [dbo].[doktor]  WITH CHECK ADD  CONSTRAINT [FK_doktor_birey] FOREIGN KEY([tckimlikno])
REFERENCES [dbo].[birey] ([tckimlikno])
GO
ALTER TABLE [dbo].[doktor] CHECK CONSTRAINT [FK_doktor_birey]
GO
ALTER TABLE [dbo].[dosya]  WITH CHECK ADD  CONSTRAINT [FK_dosya_hasta] FOREIGN KEY([hastatckimlikno])
REFERENCES [dbo].[hasta] ([tckimlikno])
GO
ALTER TABLE [dbo].[dosya] CHECK CONSTRAINT [FK_dosya_hasta]
GO
ALTER TABLE [dbo].[hasta]  WITH CHECK ADD  CONSTRAINT [FK_hasta_birey] FOREIGN KEY([tckimlikno])
REFERENCES [dbo].[birey] ([tckimlikno])
GO
ALTER TABLE [dbo].[hasta] CHECK CONSTRAINT [FK_hasta_birey]
GO
ALTER TABLE [dbo].[islemler]  WITH CHECK ADD  CONSTRAINT [FK_islemler_islem] FOREIGN KEY([islemid])
REFERENCES [dbo].[islem] ([islemid])
GO
ALTER TABLE [dbo].[islemler] CHECK CONSTRAINT [FK_islemler_islem]
GO
ALTER TABLE [dbo].[islemler]  WITH CHECK ADD  CONSTRAINT [FK_islemler_personel] FOREIGN KEY([personelid])
REFERENCES [dbo].[personel] ([personelid])
GO
ALTER TABLE [dbo].[islemler] CHECK CONSTRAINT [FK_islemler_personel]
GO
ALTER TABLE [dbo].[kullanicilar]  WITH CHECK ADD  CONSTRAINT [FK_kullanicilar_birey] FOREIGN KEY([tckimlikno])
REFERENCES [dbo].[birey] ([tckimlikno])
GO
ALTER TABLE [dbo].[kullanicilar] CHECK CONSTRAINT [FK_kullanicilar_birey]
GO
ALTER TABLE [dbo].[personel]  WITH CHECK ADD  CONSTRAINT [FK_personel_birey] FOREIGN KEY([tckimlikno])
REFERENCES [dbo].[birey] ([tckimlikno])
GO
ALTER TABLE [dbo].[personel] CHECK CONSTRAINT [FK_personel_birey]
GO
ALTER TABLE [dbo].[poliklinik]  WITH CHECK ADD  CONSTRAINT [FK_poliklinik_bolumid] FOREIGN KEY([bolumid])
REFERENCES [dbo].[poliklinik_isim] ([id])
GO
ALTER TABLE [dbo].[poliklinik] CHECK CONSTRAINT [FK_poliklinik_bolumid]
GO
ALTER TABLE [dbo].[sevk]  WITH CHECK ADD  CONSTRAINT [FK_sevk_doktor] FOREIGN KEY([sevkedendoktorid])
REFERENCES [dbo].[doktor] ([doktorid])
GO
ALTER TABLE [dbo].[sevk] CHECK CONSTRAINT [FK_sevk_doktor]
GO
ALTER TABLE [dbo].[sevk]  WITH CHECK ADD  CONSTRAINT [FK_sevk_dosya] FOREIGN KEY([dosyaid])
REFERENCES [dbo].[dosya] ([dosyaid])
GO
ALTER TABLE [dbo].[sevk] CHECK CONSTRAINT [FK_sevk_dosya]
GO
ALTER TABLE [dbo].[sevk]  WITH CHECK ADD  CONSTRAINT [FK_sevk_poliklinik] FOREIGN KEY([poliklinik])
REFERENCES [dbo].[poliklinik] ([poliklinikadi])
GO
ALTER TABLE [dbo].[sevk] CHECK CONSTRAINT [FK_sevk_poliklinik]
GO
ALTER TABLE [dbo].[sevk]  WITH CHECK ADD  CONSTRAINT [FK_sevk_taburcu] FOREIGN KEY([taburcuid])
REFERENCES [dbo].[taburcu] ([taburcuid])
GO
ALTER TABLE [dbo].[sevk] CHECK CONSTRAINT [FK_sevk_taburcu]
GO
ALTER TABLE [dbo].[taburcu]  WITH CHECK ADD  CONSTRAINT [FK_taburcu_odeme] FOREIGN KEY([odemeid])
REFERENCES [dbo].[odeme] ([odemeid])
GO
ALTER TABLE [dbo].[taburcu] CHECK CONSTRAINT [FK_taburcu_odeme]
GO
/****** Object:  StoredProcedure [dbo].[userCheck]    Script Date: 28.12.2018 05:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE procedure [dbo].[userCheck]
	-- Add the parameters for the stored procedure here
	   @username VARCHAR(50),     
	   @result bit out
	  
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	
    -- =============================================


	 IF EXISTS(SELECT * FROM kullanicilar WHERE username = @username)
		BEGIN  
		  set @result =1
	END
	else
	BEGIN  
		   set @result =0
	END


END
GO
