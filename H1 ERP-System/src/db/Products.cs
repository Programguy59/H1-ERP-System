using H1_ERP_System.products;

namespace H1_ERP_System.db;

public partial class Database
{
    public static List<Product> Products = new();

    public static Product? GetProductById(int id)
    {
        return Products.FirstOrDefault(product => product.Id == id);
    }

    public static List<Product> GetAllProducts()
    {
        return Products;
    }

    public static void InsertProduct(Product product)
    {
        Products.Add(product);
    }

    public static bool UpdateProduct(Product product, int id)
    {
        var existingProduct = GetProductById(id);

        if (existingProduct == null) return false;

        existingProduct.Id = product.Id;

        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;

        existingProduct.SalesPrice = product.SalesPrice;
        existingProduct.PurchasePrice = product.PurchasePrice;

        existingProduct.Location = product.Location;
        existingProduct.Stock = product.Stock;

        existingProduct.Unit = product.Unit;

        return true;
    }

    public static bool DeleteProductById(int id)
    {
        var productToDelete = GetProductById(id);

        if (productToDelete == null) return false;

        Products.Remove(productToDelete);

        return true;
    }

    public static void ClearProducts()
    {
        Products.Clear();
    }
}