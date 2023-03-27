namespace H1_ERP_System.ui;

    
public class CompanySetupList
    {
        public enum CompanySetupState { Todo, Started, Done }
        public string CompanyName {get;set;} = "";
        public string Country {get;set;} = "";
        public string Currency {get;set;} = "";
        public int Priority {get;set;}
    
        public CompanySetupState State {get;set;}
    
        public CompanySetupList(string companyName, string country, string currency, int priority=1)
        {
            CompanyName = companyName;
            Country = country;
            Currency = currency;
            Priority = priority;
        }
}