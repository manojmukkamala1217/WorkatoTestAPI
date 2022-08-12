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
            var seller = _mapperService.Map<Seller>(sellerDTO);
            await _sellerService.CreateSellerAsync(seller);
            //
            return await _httpClientService.PostDataAsync<Seller>(seller);
        }

        public async Task UpdateSellerAsync(SellerDTO sellerDTO)
        {
            var seller = _mapperService.Map<Seller>(sellerDTO);
            await _sellerService.UpdatSellerAsync(seller);
        }

        public async Task<string> CreateSellerAsync(string name, string phone)
        {
            return await _httpClientService.GetResultAsync(name,phone);
        }
    }
}
