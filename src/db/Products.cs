using H1_ERP_System.products;

namespace H1_ERP_System.db
{
    public partial class Database
    {
        private static readonly List<Product> products = new();
        private static int _nextProductId = 1;

        public static Product GetProductById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id)!;
        }

        public static List<Product> GetAllProducts()
        {
            return products;
        }

        public static void InsertProduct(Product product)
        {
            product.Id = _nextProductId++;

            products.Add(product);
        }

        public static bool UpdateProduct(Product product, int id)
        {
            var existingProduct = GetProductById(id);

            if (existingProduct == null)
            {
                return false;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.SalesPrice = product.SalesPrice;
            existingProduct.PurchasePrice = product.PurchasePrice;
            existingProduct.Location = product.Location;
            existingProduct.AmountInStock = product.AmountInStock;
            existingProduct.Unit = product.Unit;

            return true;
        }

        public static bool DeleteProductById(int id)
        {
            var productToDelete = GetProductById(id);

            if (productToDelete == null)
            {
                return false;
            }

            products.Remove(productToDelete);

            return true;
        }




    }
}
