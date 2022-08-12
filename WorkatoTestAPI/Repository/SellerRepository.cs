using WorkatoTestAPI.Contracts;
using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Repository
{
    public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
    {
        public  SellerRepository(WorkatoContext workatoContext): base(workatoContext)
        {

        }
        public Task<IEnumerable<Seller>> GetAllSellersAsync()
        => GetAllAsync();
        public Task UpdateSellerAsync(Seller seller)
            => UpdateAsync(seller);
        public Task<Seller> CreateSellerAsync(Seller seller)
            => CreateAsync(seller);
       
    }
}
