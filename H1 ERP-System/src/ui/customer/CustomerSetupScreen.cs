using H1_ERP_System.customer;
using H1_ERP_System.db;
using H1_ERP_System.ui.customer;
using H1_ERP_System.util;
using TECHCOOL.UI;
using Menu = H1_ERP_System.ui.Menu;

namespace H1_ERP_System.src.ui.customer;

public class CustomerSetupScreen : Screen
{
	public static int SelectedCustomerId;
	public override string Title { get; set; } = "Kunder";

	protected override void Draw()
	{
		Clear();
		
		var listPage = CustomerScreenList.GetPageList();
		
		listPage.AddColumn("ID", "Id");
		
		listPage.AddColumn("Navn", "FormattedName");
		
		listPage.AddColumn("Email", "Email");
		listPage.AddColumn("Telefon", "PhoneNumber");
		
		listPage.AddColumn("Seneste Ordre", "FormattedLastOrderDate");
		
		SelectedCustomerId = listPage.Select().Id;
		
		Clear();
		Quit();
		/*
		company.Company company = new(companyScreenList.CompanyId, companyScreenList.CompanyName, companyScreenList.CompanyAddress, companyScreenList.CompanyCurrency);
		Address address = new(companyScreenList.CompanyAddress.Id, companyScreenList.CompanyStreetName, companyScreenList.CompanyStreetNumber, companyScreenList.CompanyZipCode, companyScreenList.CompanyCity, companyScreenList.CompanyCountry);
		
		if (company == null)
		{
			return;
		}

		if (!DatabaseServer.UpdateCompany(company))
		{
			return;
		}

		if (address == null)
		{
			return;
		}
		if (!DatabaseServer.UpdateAddress(address)) {return;}
		*/
		Clear(this);
		Display(new Menu.MenuScreen());
	}
}
