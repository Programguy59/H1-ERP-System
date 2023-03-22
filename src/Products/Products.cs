namespace H1_ERP_System.Products;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public double SalesPrice { get; set; }
    public double PurchasePrice { get; set; }

    public string Location { get; set; }
    public double AmountInStock { get; set; }

    public Unit Unit { get; set; }

    public Product(int id, string name, string description, double salesPrice, double purchasePrice, string location, double amountInStock, Unit unit)
    {
        Id = id;

        Name = name;
        Description = description;

        SalesPrice = salesPrice;
        PurchasePrice = purchasePrice;

        Location = location;
        AmountInStock = amountInStock;

        Unit = unit;
    }
    
    public double GetEaring()
    {
        return SalesPrice - PurchasePrice;
    }

    public double GetProfitMargin()
    {
        return (SalesPrice - PurchasePrice) / PurchasePrice * 100;
    }
}

public enum Unit
{
    Piece,
    Hours,
    Meters
}