
using API_Practice.Contracts;
using API_Practice.Models;

namespace API_Practice.PhoneBook;

public class ProductPhoneBook : IProductPhoneBook
{

    static public List<Product> Products = new List<Product>()
    {
        new Product() { Id = 1, Name = "Ali Alavi", PhoneNumber = 56898798, CreateAt = DateTime.Now },
        new Product() { Id = 2, Name = "Parham Darvishi", PhoneNumber = 75848744, CreateAt = DateTime.Now },
        new Product() { Id = 3, Name = "Sajad Izadipanah", PhoneNumber = 45254155, CreateAt = DateTime.Now },
    };

    public List<Product> GetProducts()
    {
        return Products;
    }

    public Product GetProductById(int id)
    {
        var product = Products.Where(x => x.Id == id).FirstOrDefault();
        return product;
    }

    public bool AddProduct(Product product)
    {
        Products.Add(product);
        return true;
    }
}
