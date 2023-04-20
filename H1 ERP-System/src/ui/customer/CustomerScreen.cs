﻿using TECHCOOL.UI;

namespace H1_ERP_System.ui.customer;

public class CustomerScreen : Screen
{
	public override string Title { get; set; } = "Customer";

	protected override void Draw()
	{
		Clear();

		var listPage = CustomerScreenList.GetPageListFromId(CustomerSetupScreen.SelectedCustomerId);
		
		listPage.AddColumn("ID", "Id");
		
		listPage.AddColumn("First Name", "FirstName");
		listPage.AddColumn("Last Name", "LastName");
		
		listPage.AddColumn("Email", "Email");
		listPage.AddColumn("Phone Number", "PhoneNumber");
		
		listPage.AddColumn("Street Name", "StreetName");
		listPage.AddColumn("Street Number", "StreetNumber");
		listPage.AddColumn("Zip Code", "ZipCode");
		listPage.AddColumn("City", "City");
		listPage.AddColumn("Country", "Country");
		
		listPage.AddColumn("Last Order", "FormattedLastOrderDate");
		
		listPage.Select();
		
		Clear(this);

		Display(new Menu.MenuScreen());
	}
}
