using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Contracts
{
    public interface ISellerService
    {
        Task<IEnumerable<Seller>> GetAllSellersAsync();
        Task<Seller>CreateSellerAsync(Seller seller);
        Task UpdatSellerAsync(Seller seller);
    }
}
