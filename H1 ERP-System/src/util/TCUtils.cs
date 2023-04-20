using TECHCOOL.UI;

namespace H1_ERP_System.util;

public class TechCoolUtils
{
    public static void Clear(Screen screen)
    {
        Screen.Clear(screen);
        Screen.Clear();

        Console.Clear();
    }
}