using H1_ERP_System.src.ui.Company;
using H1_ERP_System.ui.customer;
using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class Menu
{
    public class MenuScreen : Screen
    {
        public override string Title { get; set; } = "Menu"; 
        protected override void Draw()
        {
            var menu = new TECHCOOL.UI.Menu();
            
            menu.Add(new CompanySetupScreen());
            menu.Add(new CustomerScreen());
            menu.Add(new ProductSetupScreen());
            menu.Start(this);
        }
    }
}
