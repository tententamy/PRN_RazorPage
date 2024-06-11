/*// See https://aka.ms/new-console-template for more information
using MilkBabyBusiness;
using MilkBabyData.Models;

Console.WriteLine("Hello, World!");

var productBusiness = new ProductBusiness();
var productList = await productBusiness.GetAll();




if (productList.Status > 0 && productList.Data != null)
{
    var products = (List<Product>)productList.Data;

    if (products != null && products.Count > 0)
    {
        foreach (var product in products)
        {
            Console.WriteLine(product.ProductName);
        }
    }
}
else
{
    Console.WriteLine("Get All product fail");
}



// Parse product ID
Guid productId;
try
{
    productId = Guid.Parse("4d42e8d9-2f63-4cb8-85ff-ea0914a2c1b7");
}
catch (FormatException)
{
    Console.WriteLine("Invalid product ID format.");
    return;
}

// Get product by ID
var productByIdResult = await productBusiness.GetById(productId);

if (productByIdResult.Status > 0 && productByIdResult.Data != null)
{
    var product = (Product)productByIdResult.Data;
    Console.WriteLine($"Product found by ID {productId}: {product.ProductName}");

    // Delete the product
    var deleteResult = await productBusiness.DeleteById(productId);

    if (deleteResult.Status > 0)
    {
        Console.WriteLine($"Product with ID {productId} deleted successfully.");
    }
    else
    {
        Console.WriteLine($"Failed to delete product with ID {productId}. Error: {deleteResult.Message}");
    }
}
else
{
    Console.WriteLine($"Failed to get product by ID {productId}. Error: {productByIdResult.Message}");
}

//add product
Guid idNew = Guid.NewGuid();
productByIdResult = await productBusiness.GetById(idNew);

if (productByIdResult.Status > 0 && productByIdResult.Data != null)
{
    Console.WriteLine("Product is exist");
}
else
{
    var item = new Product()
    {
        ProductId = idNew,
        ProductName = "Vinamilk",
        ProductCategory = "Vinamilk",
        ProductPrice = 20,
        ProductQuantity = 20,
        ProductDateEnd = DateOnly.FromDateTime(new DateTime(2024, 12, 31)), // Set the desired end date
        ProductDateStart = DateOnly.FromDateTime(DateTime.Now), // Set the start date to the current date and time
        ProductDescription = "Milk for kid",
        
    };

    var result = await productBusiness.Save(item);
    Console.WriteLine(result.Message);
}

// Prompt user for updated product information
Console.WriteLine("Enter the ID of the product you want to update:");

while (true)
{
    if (Guid.TryParse(Console.ReadLine(), out productId))
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid product ID format. Please enter a valid GUID.");
    }
}

var productToUpdateResult = await productBusiness.GetById(productId);

if (productToUpdateResult.Status > 0 && productToUpdateResult.Data != null)
{
    var productToUpdate = (Product)productToUpdateResult.Data;

    Console.WriteLine($"Enter the updated name for product {productToUpdate.ProductName}:");
    productToUpdate.ProductName = Console.ReadLine();

    Console.WriteLine($"Enter the updated price for product {productToUpdate.ProductName}:");
    decimal updatedPrice;
    while (!decimal.TryParse(Console.ReadLine(), out updatedPrice) || updatedPrice <= 0)
    {
        Console.WriteLine("Invalid price. Please enter a valid positive decimal value.");
    }
    productToUpdate.ProductPrice = updatedPrice;

    Console.WriteLine($"Enter the updated description for product {productToUpdate.ProductName}:");
    productToUpdate.ProductDescription = Console.ReadLine();

    // Update the product
    var updateResult = await productBusiness.Update(productToUpdate);

    if (updateResult.Status > 0)
    {
        Console.WriteLine($"Product with ID {productId} updated successfully.");
    }
    else
    {
        Console.WriteLine($"Failed to update product with ID {productId}. Error: {updateResult.Message}");
    }
}
else
{
    Console.WriteLine($"Failed to get product by ID {productId}. Error: {productToUpdateResult.Message}");
}

Console.ReadLine();*/