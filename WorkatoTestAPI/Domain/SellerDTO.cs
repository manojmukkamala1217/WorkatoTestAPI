namespace WorkatoTestAPI.Domain
{
    public class SellerDTO
    {
        public int Id { get; set; }
        public bool SignstheAgreement { get; set; }
        public string? Status { get; set; }   
        public string? LegalName { get; set; }
        public string? FEIN { get; set; }
        public string? DBA { get; set; }
        public string? b_StreetAddressLine1 { get; set; }
        public string? b_StreetAddressLine2 { get; set; }
        public string? b_City { get; set; }
        public string? b_State { get; set; }
        public string? b_Zip { get; set; }
        public string? b_MainPhone { get; set; }
        public string? b_MainFax { get; set; }
        public string? b_Website { get; set; }
        public string? m_StreetAddressLine1 { get; set; }
        public string? m_StreetAddressLine2 { get; set; }
        public string? m_City { get; set; }
        public string? m_State { get; set; }
        public string? m_Zip { get; set; }
        public string? LegalOrganization { get; set; }
        public string? DealerLicenseID { get; set; }
        public string? DealerFranchiseModel { get; set; }
        public string? AverageMonthlySalesVolume { get; set; }
        public string? PIPforFandIeContracting { get; set; }
        public string? DMSProvider { get; set; }
        public string? FandIUses { get; set; }
        public string? Roles { get; set; }
        public string? BusinessRoles { get; set; }            
    }
}
