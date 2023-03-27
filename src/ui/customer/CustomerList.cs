using H1_ERP_System.sales;

namespace H1_ERP_System.ui.customer;

public class CustomerList
{
	public int Id { get; }
	
	public string FirstName { get; }
	public string LastName { get; }
	public string FullName => $"{FirstName} {LastName}";
	
	public string Phone { get; }
	public string Email { get; }
	
	public Order LastOrder { get; }
	
	public CustomerList(int id, string firstName, string lastName, string phone, string email, Order lastOrder)
	{
		Id = id;
		
		FirstName = firstName;
		LastName = lastName;
		
		Phone = phone;
		Email = email;
		
		LastOrder = lastOrder;
	}
}
