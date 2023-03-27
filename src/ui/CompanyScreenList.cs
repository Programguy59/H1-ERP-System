namespace H1_ERP_System.ui;

public class CompanyScreenList
{
    public enum CompanyScreen { Todo, Started, Done }
    public string CompanyName {get;set;} = "";
    public string CompanyCountry {get;set;} = "";
    
    public string CompanyStreet {get;set;} = "";
    
    
    public string CompanyZipCode {get;set;} = "";
    
    public string CompanyCity {get;set;} = "";
    public string CompanyCurrency {get;set;} = "";
    public int Priority {get;set;}
    
    
    
    public CompanyScreen State {get;set;}

    public CompanyScreenList(string companyName, string companyCountry, string companyStreet, string companyZipCode, string companyCity, string companyCurrency, int priority=1)
    {
        CompanyName = companyName;
        CompanyCountry = companyCountry;
        CompanyStreet = companyStreet;
        CompanyZipCode = companyZipCode;
        CompanyCity = companyCity;
        CompanyCurrency = companyCurrency;
        Priority = priority;
        
    }
    public CompanyScreenList(string companyName, string country, string currency, int priority=1)
    {
        CompanyName = companyName;
        CompanyCountry = country;
        CompanyCurrency = currency;
        Priority = priority;
    }
}