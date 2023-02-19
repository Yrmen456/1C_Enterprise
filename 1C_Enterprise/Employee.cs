using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C_Enterprise
{
    public class Employee
    {
        public List<EmployeeListItem> Employees;
    }

    public class EmployeeListItem
    {
        public int ID { get; set; }

        public string FIO { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public bool HarmfulProduction;
        public bool Pension;
        public string HarmfulProduction_;
        public string Pension_ { get; set; }



    }
}
