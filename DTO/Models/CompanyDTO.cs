using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class CompanyDTO
    {
        public string CompanyName { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
        public CompanyDTO(string companyName)
        {
            CompanyName = companyName;
            Employees = new List<EmployeeDTO>();
        }
    }
}
