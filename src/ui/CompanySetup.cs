namespace H1_ERP_System.ui;

using TECHCOOL.UI;
public class MyFirstScreen : Screen
{
    public override string Title { get; set; } = "My first screen";
    protected override void Draw()
    {
        Clear(this);
        Console.WriteLine("My first screen!");
    }
}