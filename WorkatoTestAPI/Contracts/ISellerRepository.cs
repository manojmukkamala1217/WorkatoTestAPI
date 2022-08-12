using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Contracts
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> GetAllSellersAsync();

        Task UpdateSellerAsync(Seller seller);
        Task<Seller> CreateSellerAsync(Seller seller);


    }
}
