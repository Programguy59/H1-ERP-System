using H1_ERP_System.db;
using H1_ERP_System.company;
using H1_ERP_System.src.ui.Company;
using H1_ERP_System.util;
using TECHCOOL.UI;
using Menu = H1_ERP_System.ui.Menu;

namespace H1_ERP_System.src.Company;

public class CompanyEditDataScreen : Screen
{
	private readonly string selectedCompanyName;
	public override string Title { get; set; } = "Edit Company";

    public CompanyEditDataScreen(string CompanyName)
    {
       selectedCompanyName = CompanyName;
    }

    protected override void Draw()
	{
		Clear(this);
		var companyScreenList = CompanyScreenList.GetCompanyScreenListFromName(selectedCompanyName);
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
		Clear(this);
		//Draw the editor
		editor.Edit(companyScreenList);
		Clear(this);

        company.Company company = new(companyScreenList.CompanyId, companyScreenList.CompanyName, companyScreenList.CompanyAddress, companyScreenList.CompanyCurrency);

        if (company == null){return;}
		if (!DatabaseServer.UpdateCompany(company)){return;}
		
        Clear(this);
        Screen.Display(new Menu.MenuScreen());
    }
}
