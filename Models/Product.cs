using API_Practice.Contracts;

namespace API_Practice.Models;

public class Product : BaseEntity<int>
{
    public string Name { get; set; }
    public int PhoneNumber { get; set; }

}
