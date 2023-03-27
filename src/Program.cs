using H1_ERP_System.db;
using H1_ERP_System.sales;
using H1_ERP_System.src.customer;
using H1_ERP_System.ui;
using H1_ERP_System.ui.customer;
using TECHCOOL.UI;

namespace H1_ERP_System;

public static class Program
{
    private static void Main(string[] args)
    {
        // Create 25 some customers.
        for (int i = 0; i < 25; i++)
        {
            Database.InsertCustomer(new Customer("C" + i, "2021-01-01", i, "John", "Doe", "john.doe@example.com", "112", "MainStreet", "1", "1234",
                "Aalborg", "Denmark"));
        }
        
        // Create 25 some orders.
        for (int i = 0; i < 25; i++)
        {
            var orderLine = new OrderLine("1", "now", 1.ToString());
            var order = new Order(i, "2021-01-01", "2021-01-01", i.ToString(), OrderStatus.Completed, orderLine, 100);
            
            Database.InsertOrder(order);
        }
        
        Screen.Display(new CustomerScreen());
    }
}
