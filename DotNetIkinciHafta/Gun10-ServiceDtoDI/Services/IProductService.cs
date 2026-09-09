public interface IProductService
{
    List<Product> GetAll();

    Product? GetById(int id);

    Product Create(CreateProductDto dto);
}