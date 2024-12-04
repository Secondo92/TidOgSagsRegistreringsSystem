using DAL.Models;
using DTO.Models;
using System.Linq;

namespace DAL.Mappers
{
    public class CompanyMapper
    {
        public static CompanyDTO Map(Company company)
        {
            if (company == null)
            {
                return null;
            }

            CompanyDTO companyDTO = new CompanyDTO(company.CompanyName);
            companyDTO.Employees.AddRange(company.Employees.Select(employee => EmployeeMapper.Map(employee)));

            return companyDTO;
        }

        public static Company Map(CompanyDTO companyDTO)
        {
            if (companyDTO == null)
            {
                return null;
            }

            Company company = new Company(companyDTO.CompanyName);
            company.Employees.AddRange(companyDTO.Employees.Select(employee => EmployeeMapper.Map(employee)));

            return company;
        }
    }
}