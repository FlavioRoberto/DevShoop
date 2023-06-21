namespace DevShoop.ProductAPI;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> FindById(long id);
    void Create(Product product);
    void Update(Product product);
    Task Delete(long id);
    Task<bool> Commit();
}
