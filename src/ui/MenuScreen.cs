using H1_ERP_System.src.ui.Company;
using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class Menu
{
    public class MenuScreen : Screen
    {
        public override string Title { get; set; } = "Menu"; 
        protected override void Draw()
        {
            TECHCOOL.UI.Menu menu = new TECHCOOL.UI.Menu();
            menu.Add(new CompanySetupScreen());
            menu.Start(this);
        }
    }
}