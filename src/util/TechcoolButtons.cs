using H1_ERP_System.src.Company;
using H1_ERP_System.src.ui.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace H1_ERP_System.src.util
{
    public class TechcoolButtons
    {
        public static void MakeCompanyButton(CompanyScreenList Button)
        {
            Screen.Display(new CompanyEditDataScreen());
        }
        public static void EditCompanyButton(CompanyScreenList Button)
        {
            Screen.Display(new CompanyEditDataScreen());
        }
    }
}
