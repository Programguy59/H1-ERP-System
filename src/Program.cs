using H1_ERP_System.db;
using H1_ERP_System.util;

namespace H1_ERP_System;

public static class Program
{
	private static void Main(string[] args)
	{
		DatabaseServer.GetConnection();
		
		var companies = DatabaseServer.FetchCompanies();
		foreach (var company in companies)
		{
			Database.InsertCompany(company);
		}
		
		var products = DatabaseServer.FetchProducts();
		foreach (var product in products)
		{
			Database.InsertProduct(product); // TODO: Magnus make this method.
		}
	}
}
