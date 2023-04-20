using H1_ERP_System.company;

namespace H1_ERP_System.db;

public partial class Database
{
    public static List<Company> Companies = new();

    public static Company? GetCompanyById(int id)
    {
        return Companies.FirstOrDefault(company => company.Id == id);
    }

    public static List<Company> GetAllCompanies()
    {
        return Companies;
    }

    public static void InsertCompany(Company company)
    {
        Companies.Add(company);
    }

    public static bool UpdateCompany(Company company, int id)
    {
        var existingCompany = GetCompanyById(id);

        if (existingCompany == null) return false;

        existingCompany.Id = company.Id;

        existingCompany.CompanyName = company.CompanyName;
        existingCompany.Currency = company.Currency;
        existingCompany.Address = company.Address;

        return true;
    }

    public static bool DeleteCompanyById(int id)
    {
        var companyToDelete = GetCompanyById(id);

        if (companyToDelete == null) return false;

        Companies.Remove(companyToDelete);

        return true;
    }

    public static void ClearCompanies()
    {
        Companies.Clear();
    }
}