public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Sold { get; set; }
    public int ProductTypeId { get; set; }

    public ProductType ProductType { get; set; } 
    public DateTime DateStocked { get; set; }
    public int DaysOnShelf
{
    get
    {
        TimeSpan timeOnShelf = DateTime.Now - DateStocked;
        return timeOnShelf.Days;
    }
}
}
