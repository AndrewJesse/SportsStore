namespace SportsStore.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Product { get; }
    }
}
