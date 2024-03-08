namespace API_Practice.Contracts;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public DateTime CreateAt { get; set; }
}
