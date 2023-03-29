using H1_ERP_System.util;
using TECHCOOL.UI;

using Menu = H1_ERP_System.ui.Menu;

namespace H1_ERP_System;

public static class Program
{
    private static void Main()
    {
        DatabaseServer.Initialize();

        Screen.Display(new Menu.MenuScreen());
    }
}
