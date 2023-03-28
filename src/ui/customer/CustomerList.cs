using H1_ERP_System.sales;
using H1_ERP_System.util;

namespace H1_ERP_System.ui.customer;

public class CustomerList
{
	public int Id { get; }
	
	public string FirstName { get; }
	public string LastName { get; }
	
	public string Phone { get; }
	public string Email { get; }
	
	public Order? LastOrder { get; }
	
	public Address Address { get; }
	
	public string FormattedName => $"{FirstName} {LastName}";
	public string FormattedLastOrderDate => LastOrder == null ? "Ingen ordre!" : LastOrder.CreatedAt;
	public string FormattedAddress => $"{Address.StreetName} {Address.StreetNumber}, {Address.ZipCode} {Address.City} {Address.Country}";
	
	public CustomerList(int id, string firstName, string lastName, string phone, string email, Order? lastOrder, Address address)
	{
		Id = id;
		
		FirstName = firstName;
		LastName = lastName;
		
		Phone = phone;
		Email = email;
		
		LastOrder = lastOrder;
		Address = address;
	}
}
