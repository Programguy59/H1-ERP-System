using H1_ERP_System.ui;
using TECHCOOL.UI;
namespace H1_ERP_System;

public static class Program
{
    private static void Main(string[] args)
    {
        MyFirstScreen firstScreen = new MyFirstScreen();
        Screen.Display(firstScreen);
    }
}
