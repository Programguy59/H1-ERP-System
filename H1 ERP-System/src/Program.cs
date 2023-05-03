using H1_ERP_System.ui;
using H1_ERP_System.util;
using TECHCOOL.UI;

using Menu = H1_ERP_System.ui.Menu;

namespace H1_ERP_System;

public static class Program
{
	private static void Main()
	{
		Console.Title = "LNE Security A/S ERP System";
		DatabaseServer.Initialize(0);
		
		Music.PlaySound(Constants.DefualtSongPath, true);
		
		Screen.Display(new Menu.MenuScreen());
	}
}
