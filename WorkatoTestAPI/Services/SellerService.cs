using System.Linq.Expressions;
using WorkatoTestAPI.Contracts;
using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        {
            var sellers = await _sellerRepository.GetAllSellersAsync();
            return sellers;
        }
        public async Task<Seller> CreateSellerAsync(Seller seller)
        {
            var sellerTemp = await _sellerRepository.CreateSellerAsync(seller);
            return sellerTemp;
        }

      public  Task UpdatSellerAsync(Seller seller)
        {
            var sellerTemp =  _sellerRepository.UpdateSellerAsync(seller);
            return sellerTemp;
        }
        public async Task<IEnumerable<Seller>> GetSellersFindByAsync(Expression<Func<Seller, bool>> predicate)
        {
            return await _sellerRepository.GetSellersFindByAsync(predicate);
        }
}
}
