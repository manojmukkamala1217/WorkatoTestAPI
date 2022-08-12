using AutoMapper;
using WorkatoTestAPI.Domain;
using WorkatoTestAPI.Entites;

namespace WorkatoTestAPI.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Seller, SellerDTO>().ReverseMap(); 
        }
    }
}
