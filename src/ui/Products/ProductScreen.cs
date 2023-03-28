using H1_ERP_System.products;
using TECHCOOL.UI;

namespace H1_ERP_System.ui;

public class ProductScreen : Screen
{
    public override string Title { get; set; } = "product info";
    public ProductScreenList CurrentProduct { get; set; }

    public ProductScreen(ProductScreenList product) 
    { 
        this.CurrentProduct = product;
    }

    protected override void Draw()
    {
        Clear(this);
        ListPage<ProductScreenList> listPage = new ListPage<ProductScreenList>();
        listPage.Add(CurrentProduct);
                        
        listPage.AddColumn("Product", "ProductName");
        listPage.AddColumn("Description", "ProductDescription");
        listPage.AddColumn("Sales Price", "SalesPrice");
        listPage.AddColumn("Purchase Price", "PurchasePrice");
        listPage.AddColumn("Earnings", "Earnings");
        listPage.AddColumn("Profit Margin", "ProfitMargin");

        ProductScreenList selected = listPage.Select();
        
        Console.Clear();

      
        
        Quit();



    }
}