USE [Workato]
GO

/****** Object:  Table [dbo].[Seller]    Script Date: 12-08-2022 12:26:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE  TABLE [dbo].[Sellers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SignstheAgreement]  bit NULL,
	[Status]    [nvarchar](50) NULL,
	[LegalName] [nvarchar](50) NOT NULL,
	[FEIN] [nvarchar](50) NULL,
	[DBA] [nvarchar](50) NULL,
	[b_StreetAddressLine1] [nvarchar](50) NULL,
	[b_StreetAddressLine2] [nvarchar](50) NULL,
	[b_City] [nvarchar](50) NULL,
	[b_State] [nvarchar](50) NULL,
	[b_Zip] [nvarchar](50) NULL,
	[b_MainPhone] [nvarchar](50) NULL,
	[b_MainFax] [nvarchar](50) NULL,
	[b_Website] [nvarchar](50) NULL,
	[m_StreetAddressLine1] [nvarchar](50) NULL,
	[m_StreetAddressLine2] [nvarchar](50) NULL,
	[m_City] [nvarchar](50) NULL,
	[m_State] [nvarchar](50) NULL,
	[m_Zip] [nvarchar](50) NULL,
	[LegalOrganization] [nvarchar](50) NULL,
	[DealerLicenseID] [nvarchar](50) NULL,
	[DealerFranchiseModel] [nvarchar](50) NULL,
	[AverageMonthlySalesVolume] [nvarchar](50) NULL,
	[PIPforFandIeContracting] [nvarchar](50) NULL,
	[DMSProvider] [nvarchar](50) NULL,
	[FandIUses] [nvarchar](50) NULL,
	[Roles] [nvarchar](50) NULL,
	[BusinessRoles] [nvarchar](50) NULL,
) ON [PRIMARY]
GO


