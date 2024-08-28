string greeting = @"Welcome to Reductio & Absurdum!";

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Name = "Wand"
    },
    new ProductType()
    {
        Id = 2,
        Name = "Apparel"
    },
    new ProductType()
    {
        Id = 3,
        Name = "Potion"
    },
    new ProductType()
    {
        Id = 4,
        Name = "Enchanted Object"
    }
};

List<Product> products = new List<Product>()
{
    new Product()
    {
        Id = 1,
        Name = "The Stick",
        Price = 18.99M,
        Sold = false,
        ProductTypeId = 1 
    },
    new Product()
    {
        Id = 2,
        Name = "Robe of the Wise",
        Price = 45.00M,
        Sold = false,
        ProductTypeId = 2
    },
    new Product()
    {
        Id = 3,
        Name = "Healing Potion",
        Price = 12.50M,
        Sold = true,
        ProductTypeId = 3
    },
    new Product()
    {
        Id = 4,
        Name = "Invisibility Cloak",
        Price = 99.99M,
        Sold = false,
        ProductTypeId = 4
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
        PostProduct();
    }
    else if (choice == "3")
    {
        Console.Clear();
        DeleteProduct();
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
        Id: {product.Id}
        Name: {product.Name}
        Price: {product.Price}
        Sold: {product.Sold}
        ");
    }
}

void PostProduct()
{
    Console.WriteLine("Enter Name");
    string name = Console.ReadLine();

    Console.Write("Enter Price");
    decimal price;
    while(!decimal.TryParse(Console.ReadLine(), out price))
    {
        Console.WriteLine("Please enter a valid price");
    }

    Console.WriteLine("Enter Product Type Id (1-4)");
    int userProductTypeIdChoice;
    while(!int.TryParse(Console.ReadLine(), out userProductTypeIdChoice) || userProductTypeIdChoice < 1 || userProductTypeIdChoice > 4)
    {
        Console.WriteLine("Please enter a valid number between 1-4");
    }

    Product newProduct = new Product()
    {
        Name = name,
        Price = price,
        Sold = false,
        ProductTypeId = userProductTypeIdChoice
    };

    products.Add(newProduct);
    Console.WriteLine($"{name} has been added to the product list");
}

void DeleteProduct()
{
    ViewProducts();

    Console.WriteLine("Enter product you wish to delete. (must be id)");
    int userDeleteChoice;
    while(!int.TryParse(Console.ReadLine(), out userDeleteChoice) || userDeleteChoice < 1 || userDeleteChoice > products.Count)
    {
        Console.WriteLine("Please enter a valid product id");
    }

    products.RemoveAt(userDeleteChoice -1 );
    Console.WriteLine("Product has been successfully removed");
}