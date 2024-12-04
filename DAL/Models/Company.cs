using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Company
    {
        [Key]
        public string CompanyName { get; set; }
        public List<Employee> Employees { get; set; }
        public Company()
        {
        }
        public Company(string companyName)
        {
            CompanyName = companyName;
            Employees = new List<Employee>();
        }
    }
}
