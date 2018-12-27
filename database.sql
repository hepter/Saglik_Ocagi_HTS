USE [saglikDB]
GO
/****** Object:  Table [dbo].[birey]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[doktor]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[dosya]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[hasta]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[islem]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[islemler]    Script Date: 27.12.2018 15:19:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[islemler](
	[sevktarihi] [datetime] NOT NULL,
	[islemid] [int] NOT NULL,
	[doktorid] [int] NOT NULL,
	[miktar] [int] NULL,
 CONSTRAINT [PK_yapilanislemler] PRIMARY KEY CLUSTERED 
(
	[sevktarihi] ASC,
	[islemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanicilar]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[odeme]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[poliklinik]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[poliklinik_isim]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[sevk]    Script Date: 27.12.2018 15:19:25 ******/
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
/****** Object:  Table [dbo].[taburcu]    Script Date: 27.12.2018 15:19:25 ******/
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

INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (5, 0, N'Semih', N'baltacı', N'', CAST(N'2018-12-27T12:57:57.087' AS DateTime), N'0', N'', N'-1', N'', N'', N'', N'5568745645', N'')
INSERT [dbo].[birey] ([id], [tckimlikno], [ad], [soyad], [dogumyeri], [dtarihi], [cinsiyet], [kangrubu], [medenihal], [anneadi], [babaadi], [evtel], [ceptel], [adres]) VALUES (1, 45645645645, N'mustafa', N'kuru', N'konya', CAST(N'2018-12-27T12:55:53.333' AS DateTime), N'0', N'A Rh+', N'1', N'davut', N'şükran', N'', N'1111111111', N'')
SET IDENTITY_INSERT [dbo].[birey] OFF
SET IDENTITY_INSERT [dbo].[islem] ON 

INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (1, N'muayene', N'100')
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (2, N'ameliyat', N'1250')
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (3, N'kontrol', N'50')
INSERT [dbo].[islem] ([islemid], [islemadi], [birimfiyat]) VALUES (4, N'uygunluk kontrol', N'175')
SET IDENTITY_INSERT [dbo].[islem] OFF
SET IDENTITY_INSERT [dbo].[kullanicilar] ON 

INSERT [dbo].[kullanicilar] ([id], [tckimlikno], [username], [sifre], [yetki], [unvan], [isebaslama], [maas]) VALUES (1, 45645645645, N'hepter', N'123456', N'1', N'Öğrenci', CAST(N'2018-12-27T05:19:19.067' AS DateTime), N'0')
INSERT [dbo].[kullanicilar] ([id], [tckimlikno], [username], [sifre], [yetki], [unvan], [isebaslama], [maas]) VALUES (2, 0, N'semih123', N'123456', N'0', N'İşci', CAST(N'2018-12-27T12:57:57.083' AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[kullanicilar] OFF
SET IDENTITY_INSERT [dbo].[odeme] ON 

INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (1, N'Nakit')
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (2, N'Kredi Kartı - Tek Çekim')
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (3, N'Havale')
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (4, N'Senet')
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (5, N'Kredi Kartı - 6 Ay taksit')
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (6, N'Kredi Kartı - 12 Ay taksit')
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (7, N'Kredi Kartı - 24 Ay taksit')
INSERT [dbo].[odeme] ([odemeid], [yontemadi]) VALUES (8, N'Çek')
SET IDENTITY_INSERT [dbo].[odeme] OFF
INSERT [dbo].[poliklinik] ([poliklinikadi], [durum], [aciklama], [bolumid]) VALUES (N'kbb', N'1', N'', 69)
INSERT [dbo].[poliklinik] ([poliklinikadi], [durum], [aciklama], [bolumid]) VALUES (N'kulak', N'1', N'', 43)
INSERT [dbo].[poliklinik] ([poliklinikadi], [durum], [aciklama], [bolumid]) VALUES (N'platin', N'1', N'', 16)
SET IDENTITY_INSERT [dbo].[poliklinik_isim] ON 

INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (1, N'Acil Servis')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (2, N'Agiz ve Dis Sagligi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (3, N'Agri Poliklinigi (Algoloji)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (4, N'Akupunktur Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (5, N'Alerji Hastaliklari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (6, N'Androloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (7, N'Anestezi ve Reanimasyon')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (8, N'Ayak Sagligi Merkez')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (9, N'Bakteriyoloji ve Mikrobiyoloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (10, N'Bas Agrisi Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (11, N'Beslenme ve Diyet')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (12, N'Beyin Sagligi Koruma Programi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (13, N'Beyin ve Sinir Cerrahisi (Nörosirürji)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (14, N'Biyokimya Laboratuvari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (15, N'Böbrek Nakli Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (16, N'Check Up Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (17, N'Çocuk Allerjisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (18, N'Çocuk Cerrahisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (19, N'Çocuk Endokrinolojisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (20, N'Çocuk Enfeksiyon Hastaliklari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (21, N'Çocuk Ergen ve Ruh Sagligi (Çocuk Psikiyatrisi)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (22, N'Çocuk Gastroenterolojisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (23, N'Çocuk Gögüs Hastaliklari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (24, N'Çocuk Hematolojisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (25, N'Çocuk Kardiyolojisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (26, N'Çocuk Kemik Iligi Nakli Ünitesi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (27, N'Çocuk Nefrolojisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (28, N'Çocuk Nörolojisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (29, N'Çocuk Onkolojisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (30, N'Çocuk Sagligi ve Hastaliklari (Pediatri)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (31, N'Çocuk Ürolojisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (32, N'Çocuk ve Genç Sporcu Sagligi Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (33, N'Deri ve Zührevi Hastaliklari (Dermatoloji)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (34, N'Doku Tipleme ve Immünoloji Laboratuvari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (35, N'Elekta Versa HD SIGNATURE')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (36, N'Endokrinoloji ve Metabolizma Hastaliklari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (37, N'Endometriozis Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (38, N'Enfeksiyon Hastaliklari ve Klinik Mikrobiyoloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (39, N'Estetik, Plastik ve Rekonstrüktif Cerrahi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (40, N'Evde Bakim Hizmetleri')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (41, N'Fizik Tedavi ve Rehabilitasyon')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (42, N'Gastroenteroloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (43, N'Genel Cerrahi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (44, N'Genel Yogun Bakim')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (45, N'Genetik Kanser Poliklinigi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (46, N'Genetik Laboratuvari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (47, N'Girisimsel Nöroradyoloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (48, N'Girisimsel Radyoloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (49, N'Gögüs Cerrahisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (50, N'Gögüs Hastaliklari (Akciger Hastaliklari)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (51, N'Göz Hastaliklari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (52, N'Hastane Direktörlügü')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (53, N'Havacilik Tip Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (54, N'Hematoloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (55, N'Iç Hastaliklari (Dahiliye)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (56, N'Inme ve Beyin Hasari Rehabilitasyon Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (57, N'Istahsiz Çocuk Poliklinigi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (58, N'Jinekolojik Onkoloji (Kadin Kanserleri)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (59, N'Kadin Hastaliklari ve Dogum')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (60, N'Kalp ve Damar Cerrahisi (KVC)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (61, N'Karaciger Nakli Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (62, N'Kardiyoloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (63, N'Kas ve Sinir Hastaliklari Merkezi (Nöromusküler Hastaliklar)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (64, N'Kat ve Triaj Hekimligi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (65, N'Kemik Iligi Nakli Merkezi (Kök Hücre Nakli Merkezi)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (66, N'Kemoterapi (Tibbi Onkoloji)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (67, N'Koroner Yogun Bakim Ünitesi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (68, N'Kozmetik Dermatoloji (Kozmetoloji)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (69, N'Kulak Burun Bogaz Hastaliklari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (70, N'KVC Yogun Bakim Ünitesi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (71, N'Liyezon Psikiyatrisi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (72, N'Meme Sagligi Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (73, N'Mezoterapi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (74, N'Mikrobiyoloji Laboratuvari')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (75, N'Nefroloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (76, N'Nöroloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (77, N'Nükleer Tip')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (78, N'Obezite Cerrahisi Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (79, N'Omurga Sagligi Ünitesi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (80, N'Onkoloji Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (81, N'Organ Nakli Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (82, N'Ortopedi ve Travmatoloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (83, N'Pedagoji (Çocuk ve Ergen Psikolojisi)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (84, N'Perinatal Tani ve Tedavi Merkezi (Riskli Gebelikler)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (85, N'Perinatoloji (Yüksek Riskli Gebelik)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (86, N'PET/CT')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (87, N'Proktoloji Merkezi (Hemoroid ve Anorektal Hastaliklar Ünitesi)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (88, N'Psikiyatri')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (89, N'Psikoloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (90, N'Radyasyon Onkolojisi(Radyoterapi)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (91, N'Radyoloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (92, N'Radyonüklid Tedavi Ünitesi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (93, N'Robotik Cerrahi Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (94, N'Robotik Rehabilitasyon Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (95, N'Saç Ekimi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (96, N'Solunum Terapisi Merkezi (Nefes Terapisi)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (97, N'Tanisi Konulamayan Hastaliklar Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (98, N'Tibbi Onkoloji (Kemoterapi)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (99, N'Tomosentez')
GO
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (100, N'Transfüzyon Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (101, N'TrueBeam')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (102, N'Tüp Bebek (IVF) ve Üreme Sagligi Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (103, N'Uyku Bozuklugu Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (104, N'Ürojinekoloji (Kadin Üroloji Merkezi)')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (105, N'Üroloji')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (106, N'Yara Analizi ve Tedavi Merkezi')
INSERT [dbo].[poliklinik_isim] ([id], [isim]) VALUES (107, N'Yenidogan Yogun Bakim Ünitesi')
SET IDENTITY_INSERT [dbo].[poliklinik_isim] OFF
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
ALTER TABLE [dbo].[islemler]  WITH CHECK ADD  CONSTRAINT [FK_islemler_doktor] FOREIGN KEY([doktorid])
REFERENCES [dbo].[doktor] ([doktorid])
GO
ALTER TABLE [dbo].[islemler] CHECK CONSTRAINT [FK_islemler_doktor]
GO
ALTER TABLE [dbo].[islemler]  WITH CHECK ADD  CONSTRAINT [FK_islemler_islem] FOREIGN KEY([islemid])
REFERENCES [dbo].[islem] ([islemid])
GO
ALTER TABLE [dbo].[islemler] CHECK CONSTRAINT [FK_islemler_islem]
GO
ALTER TABLE [dbo].[kullanicilar]  WITH CHECK ADD  CONSTRAINT [FK_kullanicilar_birey] FOREIGN KEY([tckimlikno])
REFERENCES [dbo].[birey] ([tckimlikno])
GO
ALTER TABLE [dbo].[kullanicilar] CHECK CONSTRAINT [FK_kullanicilar_birey]
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
/****** Object:  StoredProcedure [dbo].[userCheck]    Script Date: 27.12.2018 15:19:26 ******/
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
