namespace DevShoop.ProductAPI;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> FindById(long id);
    Task Create(Product product);
    Task Update(Product product);
    Task<bool> Delete(long id);
}
