using WorkatoTestAPI.Contracts;
using WorkatoTestAPI.Domain;
using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Services
{
    public class WorkatoService : IWorkatoService
    {
        private readonly ISellerService _sellerService;
        private readonly IHttpClientService _httpClientService;
        private readonly IMapperService _mapperService;

        public WorkatoService(ISellerService sellerService, IHttpClientService httpClientService, IMapperService mapperService)
        {
            _sellerService = sellerService;
            _httpClientService = httpClientService;
            _mapperService = mapperService;
        }
        public async Task<string> CreateSellerAsync(SellerDTO sellerDTO)
        {
            var sellerTemp = await _sellerService.GetSellersFindByAsync(_ => _.LegalName!.ToLower() == sellerDTO.LegalName!.ToLower());
            if (sellerTemp == null)
            {
                var seller = _mapperService.Map<Seller>(sellerDTO);
                await _sellerService.CreateSellerAsync(seller);
                //
                return await _httpClientService.PostDataAsync<Seller>(seller);
            }
            else
            {
                 throw new Exception($"There is record exists in Seller table with LegalName: {sellerDTO.LegalName}");
            }
        }

        public async Task<string> UpdateSellerAsync(SellerDTO sellerDTO)
        {
            var sellerTemp = await _sellerService.GetSellersFindByAsync(_=> _.LegalName!.ToLower() == sellerDTO.LegalName!.ToLower());

            if (sellerTemp != null)
            {
                var seller = sellerTemp!.FirstOrDefault();
                if (seller != null)
                {
                    seller.SignstheAgreement = sellerDTO.SignstheAgreement;
                    seller.Status = sellerDTO.Status;
                    seller.LegalName = sellerDTO.LegalName;
                    seller.FEIN = sellerDTO.FEIN;
                    seller.DBA = sellerDTO.DBA;
                    seller.b_StreetAddressLine1 = sellerDTO.b_StreetAddressLine1;
                    seller.b_StreetAddressLine2 = sellerDTO.b_StreetAddressLine2;
                    seller.b_City = sellerDTO.b_City;
                    seller.b_State = sellerDTO.b_State;
                    seller.b_Zip = sellerDTO.b_Zip;
                    seller.b_MainPhone = sellerDTO.b_MainPhone;
                    seller.b_MainFax = sellerDTO.b_MainFax;
                    seller.b_Website = sellerDTO.b_Website;
                    seller.m_StreetAddressLine1 = sellerDTO.m_StreetAddressLine1;
                    seller.m_StreetAddressLine2 = sellerDTO.m_StreetAddressLine2;
                    seller.m_City = sellerDTO.m_City;
                    seller.m_State = sellerDTO.m_State;
                    seller.m_Zip = sellerDTO.m_Zip;
                    seller.LegalOrganization = sellerDTO.LegalOrganization;
                    seller.DealerLicenseID = sellerDTO.DealerLicenseID;
                    seller.DealerFranchiseModel = sellerDTO.DealerFranchiseModel;
                    seller.AverageMonthlySalesVolume = sellerDTO.AverageMonthlySalesVolume;
                    seller.PIPforFandIeContracting = sellerDTO.PIPforFandIeContracting;
                    seller.DMSProvider = sellerDTO.DMSProvider;
                    seller.FandIUses = sellerDTO.FandIUses;
                    seller.Roles = sellerDTO.Roles;
                    seller.BusinessRoles = sellerDTO.BusinessRoles;
                    await _sellerService.UpdatSellerAsync(seller);
                  // return await _httpClientService.PutDataAsync<Seller>(seller);
                }
               
            }
            return String.Empty;
        }

        public async Task<string> CreateSellerAsync(string name, string phone)
        {
            return await _httpClientService.GetResultAsync(name,phone);
        }

        public async Task<IEnumerable<SellerDTO>> GetAllSellersAsync()
        {
           var seller= await _sellerService.GetAllSellersAsync();
            return _mapperService.Map<IEnumerable<SellerDTO>>(seller);
            
        }
    }
}
