﻿using H1_ERP_System.src.ui.Company;
using H1_ERP_System.ui.customer;
using H1_ERP_System.ui.sale;
using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class Menu
{
	public class MenuScreen : Screen
	{
		public override string Title { get; set; } = "Menu";

		protected override void Draw()
		{
			Clear(this);

			var menu = new TECHCOOL.UI.Menu();

			menu.Add(new CompanySetupScreen());
			menu.Add(new CustomerSetupScreen());
			menu.Add(new ProductSetupScreen());
			menu.Add(new SalesScreen());
			menu.Start(this);

            Clear(this);
        }
	}
}
