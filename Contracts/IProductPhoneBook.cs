using API_Practice.Models;



namespace API_Practice.Contracts;

public interface IProductPhoneBook
{
    List<Product> GetProducts();
    Product GetProductById(int id);
    bool AddProduct(Product product);     
}
