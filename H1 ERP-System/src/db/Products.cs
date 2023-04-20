using H1_ERP_System.products;

namespace H1_ERP_System.db;

public static partial class Database
{
	public static readonly List<Product> Products = new();

	public static Product? GetProductById(int id)
	{
		return Products.FirstOrDefault(product => product.Id == id);
	}

	public static List<Product> GetAllProducts()
	{
		return Products;
	}
}
