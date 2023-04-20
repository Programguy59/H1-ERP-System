using H1_ERP_System.company;

namespace H1_ERP_System.db;

public static partial class Database
{
	public static readonly List<Company> Companies = new();

	public static Company? GetCompanyById(int id)
	{
		return Companies.FirstOrDefault(company => company.Id == id);
	}

	public static List<Company> GetAllCompanies()
	{
		return Companies;
	}
}
