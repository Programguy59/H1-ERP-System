using Org.BouncyCastle.Asn1.Ocsp;

namespace H1_ERP_System.products;

public class Product
{
	public Product(int id, string name, string description, double salesPrice, double purchasePrice, string location, double stock,
		Unit unit)
	{
		Id = id;

		Name = name;
		Description = description;

		SalesPrice = salesPrice;
		PurchasePrice = purchasePrice;

		Location = location;
		Stock = stock;

		Unit = unit;

		Earnings = GetEarnings();
		ProfitMargin = GetProfitMargin();


	}
	public Product(string name, string description, double salesPrice, double purchasePrice, string location, double stock, Unit unit) : 
		this(-1,name,description,salesPrice,purchasePrice,location,stock,unit) { }

    public int Id { get; set; }

	public string Name { get; set; }
	public string Description { get; set; }

	public double SalesPrice { get; set; }
	public double PurchasePrice { get; set; }
	public double Earnings { get; set; }
	public double ProfitMargin { get; set; }
	public string Location { get; set; }
	public double Stock { get; set; }

	public Unit Unit { get; set; }

	public double GetEarnings()
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

public static class UnitExtensions
{
	public static Unit Of(this string unit)
	{
		return unit switch
		{
			"Piece" => Unit.Piece,
			"Hours" => Unit.Hours,
			"Meters" => Unit.Meters,
			_ => throw new ArgumentException("Invalid unit!")
		};
	}
}
