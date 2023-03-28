namespace H1_ERP_System.ui.sale;

public class SalesList
{
    public int Id { get; }
    
    public string Date { get; }
    public string CustomerId { get; }
    public string CustomerName { get; }
    
    public double TotalPrice { get; }
    
    public SalesList(int id, string date, string customerId, string customerName, double totalPrice)
    {
        Id = id;
        
        Date = date;
        CustomerId = customerId;
        CustomerName = customerName;
        
        TotalPrice = totalPrice;
    }
}