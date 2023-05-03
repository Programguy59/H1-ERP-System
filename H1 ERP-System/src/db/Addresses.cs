using H1_ERP_System.util;

namespace H1_ERP_System.db;

public static partial class Database
{
	public static readonly List<Address> Addresses = new();

	public static Address? GetAddressById(int id)
	{
		return Addresses.FirstOrDefault(address => address.Id == id);
	}

	public static List<Address> GetAllAddresses()
	{
		return Addresses;
	}
}
