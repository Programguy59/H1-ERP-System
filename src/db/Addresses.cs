using H1_ERP_System.util;

namespace H1_ERP_System.db;

public partial class Database
{
	public static readonly List<Address> Addresses = new();
	private static int _nextAddressId = 1;

	public static Address? GetAddressById(int id)
	{
		return Addresses.FirstOrDefault(address => address.Id == id);
	}

	public static List<Address> GetAllAddresses()
	{
		return Addresses;
	}

	public static void InsertAddress(Address address)
	{
		address.Id = _nextAddressId++;

		Addresses.Add(address);
	}

	public static bool UpdateAddress(Address address, int id)
	{
		var existingAddress = GetAddressById(id);

		if (existingAddress == null)
		{
			return false;
		}

		existingAddress.StreetName = address.StreetName;
		existingAddress.StreetNumber = address.StreetNumber;

		existingAddress.City = address.City;
		existingAddress.ZipCode = address.ZipCode;

		existingAddress.Country = address.Country;

		return true;
	}

	public static bool DeleteAddressById(int id)
	{
		var addressToDelete = GetAddressById(id);

		if (addressToDelete == null)
		{
			return false;
		}

		Addresses.Remove(addressToDelete);

		return true;
	}

	public static void ClearAddresses()
	{
		Addresses.Clear();

		_nextAddressId = 1;
	}
}
