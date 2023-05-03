using H1_ERP_System.ui.company;
using H1_ERP_System.ui.customer;
using H1_ERP_System.ui.products;
using H1_ERP_System.ui.sale;
using H1_ERP_System.util;
using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class Menu
{
	public class MenuScreen : Screen
	{
		public override string Title { get; set; } = "LNE Security A/S";

		protected override void Draw()
		{
			TechCoolUtils.Clear(this);

			var menu = new TECHCOOL.UI.Menu();
			
			menu.Add(new CompanySetupScreen());
			menu.Add(new CustomerSetupScreen());
			menu.Add(new ProductSetupScreen());
			menu.Add(new SaleSetupScreen());
			menu.Add(new MusicScreen());
			
			menu.Start(this);
			
			TechCoolUtils.Clear(this);
		}
	}
}
