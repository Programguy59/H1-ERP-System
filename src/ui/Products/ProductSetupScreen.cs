using H1_ERP_System.src;
using H1_ERP_System.util;

namespace H1_ERP_System.ui;

using H1_ERP_System.products;
using H1_ERP_System.src.ui.Company;
using TECHCOOL.UI;
public class ProductSetupScreen : Screen
{
    public override string Title { get; set; } = "product setup";

    public Product product = new Product(88, "CoolProduct", "It is cool", 25, 30, "Bag dig", 3, Unit.Meters);
    public Product product2 = new Product(44, "unCoolProduct", "It is  not cool", 35, 30, "foran dig", -3, Unit.Meters);



    protected override void Draw()
    {



        Clear(this);
        ListPage<ProductScreenList> listPage = new ListPage<ProductScreenList>();
        var Products = DatabaseServer.FetchProducts();
        for (int i = 0; i < Products.Count; i++)
        {
            listPage.Add(new ProductScreenList(Products[i], 1));
        }
        

        listPage.AddColumn("Product number", "ProductNumber" );
        listPage.AddColumn("Product", "ProductName" );
        listPage.AddColumn("Sales Price", "SalesPrice");
        listPage.AddColumn("Purchase Price", "PurchasePrice");
        listPage.AddColumn("Profit Margin", "ProfitMargin");



        ProductScreenList selected = listPage.Select();
        
        Console.WriteLine("You selected: " + selected.ProductName);
        Console.Clear();
        
        Quit();
                
                Screen.Display(new ProductScreen(selected));
    }



}