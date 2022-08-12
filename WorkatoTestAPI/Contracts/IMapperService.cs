namespace WorkatoTestAPI.Contracts
{
    public interface IMapperService
    {
        TDestination Map<TDestination>(object source);        
    }
}
