using H1_ERP_System.company;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui.company;

public class CompanyEditDataScreen : Screen
{
	private readonly int selectedCompanyId;

	public CompanyEditDataScreen(int CompanyId)
	{
		selectedCompanyId = CompanyId;
	}

	public override string Title { get; set; } = "Edit Company";

	protected override void Draw()
	{
		TechCoolUtils.Clear(this);
		var companyScreenList = CompanyScreenList.GetCompanyScreenListFromId(selectedCompanyId);
		var editor = new Form<CompanyScreenList>();

		//Add a textbox
		editor.TextBox("Company", "CompanyName");
		editor.TextBox("Country", "CompanyCountry");
		editor.TextBox("Street Name", "CompanyStreetName");
		editor.TextBox("Street Number", "CompanyStreetNumber");
		editor.TextBox("Zipcode", "CompanyZipCode");
		editor.TextBox("City", "CompanyCity");
		editor.TextBox("Currency", "CompanyCurrency");

		//editor.IntBox("Importance", "Priority");
		TechCoolUtils.Clear(this);
		//Draw the editor
		editor.Edit(companyScreenList);
		TechCoolUtils.Clear(this);

		Company company = new(companyScreenList.CompanyId, companyScreenList.CompanyName,
			companyScreenList.CompanyAddress,
			companyScreenList.CompanyCurrency);
		
		company.Address = new Address(companyScreenList.CompanyAddress.Id, companyScreenList.CompanyStreetName,
			companyScreenList.CompanyStreetNumber, companyScreenList.CompanyZipCode, companyScreenList.CompanyCity,
			companyScreenList.CompanyCountry);

		if (company == null)
		{
			return;
		}

		if (!DatabaseServer.UpdateCompany(company))
		{
			return;
		}


		TechCoolUtils.Clear(this);
		Display(new Menu.MenuScreen());
	}
}
