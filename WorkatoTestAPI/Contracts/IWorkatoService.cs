using WorkatoTestAPI.Domain;
using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Contracts
{
    public interface IWorkatoService
    {        
        Task<string>CreateSellerAsync(SellerDTO seller);
        Task<string> CreateSellerAsync(string name, string phone);
        Task<string> UpdateSellerAsync(SellerDTO seller);
        Task<IEnumerable<SellerDTO>> GetAllSellersAsync();
    }
}
