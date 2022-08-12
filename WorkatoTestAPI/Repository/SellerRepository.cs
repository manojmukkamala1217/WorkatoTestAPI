using System.Linq.Expressions;
using WorkatoTestAPI.Contracts;
using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Repository
{
    public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
    {
        public  SellerRepository(EnginuityContext workatoContext): base(workatoContext)
        {

        }
        public Task<IEnumerable<Seller>> GetAllSellersAsync()
        => GetAllAsync();
        public Task UpdateSellerAsync(Seller seller)
            => UpdateAsync(seller);
        public Task<Seller> CreateSellerAsync(Seller seller)
            => CreateAsync(seller);
        public Task<IEnumerable<Seller>> GetSellersFindByAsync(Expression<Func<Seller, bool>> predicate) => FindByAsync(predicate);
    }
}
