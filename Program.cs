string greeting = @"Welcome to Reductio & Absurdum!";

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Name = "Wand"
    }
};

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "The Stick",
        Price = 18.99M,
        Sold = false,
        ProductTypeId = 1
    }
};


Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. Add Product to Inventory
                        3. Delete Product from Inventory
                        4. Update a Product's Details");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        Console.Clear();
        ViewProducts();
    }
    else if (choice == "2")
    {
        Console.Clear();
        break;
    }
    else if (choice == "3")
    {
        Console.Clear();
        break;
    }
    else if (choice == "4")
    {
        Console.Clear();
        break;
    }
}

void ViewProducts()
{
    Console.WriteLine("Here are all the current products: ");

    foreach (var product in products)
    {
        Console.WriteLine(@$"
        Name: {product.Name}
        Price: {product.Price}
        Sold: {product.Sold}
        ");
    }
}