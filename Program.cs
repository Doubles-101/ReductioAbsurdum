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
        ProductTypeId = 1,
        DateStocked = new DateTime(2024, 1, 1)
    },
    new Product()
    {
        Id = 2,
        Name = "Robe of the Wise",
        Price = 45.00M,
        Sold = false,
        ProductTypeId = 2,
        DateStocked = new DateTime(2024, 2, 12)
    },
    new Product()
    {
        Id = 3,
        Name = "Healing Potion",
        Price = 12.50M,
        Sold = true,
        ProductTypeId = 3,
        DateStocked = new DateTime(2024, 5, 15)
    },
    new Product()
    {
        Id = 4,
        Name = "Invisibility Cloak",
        Price = 99.99M,
        Sold = false,
        ProductTypeId = 4,
        DateStocked = new DateTime(2024, 8, 1)
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
                        4. Update a Product's Details
                        5. Search by Product Type Id");
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
        UpdateProduct();
    }
    else if (choice == "5")
    {
        Console.Clear();
        SearchProductId();
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
        Date Stocked: {product.DateStocked}
        Days on Shelf: {product.DaysOnShelf}
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

void UpdateProduct()
{
    try
    {
        ViewProducts();

        Console.WriteLine("Enter the Id of the product you wish to update:");
        int userUpdateChoice;
        while (!int.TryParse(Console.ReadLine(), out userUpdateChoice))
        {
            Console.WriteLine("Please enter a valid product Id.");
        }

        // Initialize a variable to store the product to be updated
        Product productToUpdate = null;

        // Use a foreach loop to find the product with the matching Id
        foreach (var product in products)
        {
            if (product.Id == userUpdateChoice)
            {
                productToUpdate = product;
                break; // Exit the loop once the product is found
            }
        }

        // Check if the product was found
        if (productToUpdate != null)
        {
            Console.WriteLine($"Updating Product: {productToUpdate.Name}");

            // Update Name
            Console.WriteLine("Enter new Name (or press Enter to keep current):");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                productToUpdate.Name = newName;
            }

            // Update Price
            Console.WriteLine("Enter new Price (or press Enter to keep current):");
            string newPriceInput = Console.ReadLine();
            if (decimal.TryParse(newPriceInput, out decimal newPrice))
            {
                productToUpdate.Price = newPrice;
            }

            // Update Sold status
            Console.WriteLine("Is the product sold? (y/n, or press Enter to keep current):");
            string newSoldStatus = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newSoldStatus))
            {
                if (newSoldStatus.ToLower() == "y")
                {
                    productToUpdate.Sold = true;
                }
                else if (newSoldStatus.ToLower() == "n")
                {
                    productToUpdate.Sold = false;
                }
            }

            // Update Product Type
            Console.WriteLine("Enter new Product Type Id (1-4, or press Enter to keep current):");
            string newProductTypeIdInput = Console.ReadLine();
            if (int.TryParse(newProductTypeIdInput, out int newProductTypeId) &&
                newProductTypeId >= 1 && newProductTypeId <= 4)
            {
                productToUpdate.ProductTypeId = newProductTypeId;
            }

            Console.WriteLine($"Product '{productToUpdate.Name}' has been successfully updated.");
        }
        else
        {
            Console.WriteLine("Product with the specified Id was not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while attempting to update the product: {ex.Message}");
    }
}

void SearchProductId()
{
    Console.WriteLine("Please enter a number between 1 and 4");

    int userChoice;
    while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 4)
    {
        Console.WriteLine("Please enter a valid number between 1-4");
    }

    foreach (var product in products)
    {
        if (userChoice == product.ProductTypeId)
        {
            Console.WriteLine(@$"
            Id: {product.Id}
            Name: {product.Name}
            Price: {product.Price}
            Sold: {product.Sold}
            ");
        }
        
    }
}
