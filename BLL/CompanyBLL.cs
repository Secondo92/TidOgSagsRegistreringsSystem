using DAL.Models;
using DTO.Models;
using DAL.Repository;
using System.Collections.Generic;

namespace BLL
{
    public class CompanyBLL
    {
        // Opret et nyt firma
        public static CompanyDTO CreateCompany(string companyName, List<EmployeeDTO> employees = null)
        {
            var newCompany = new CompanyDTO(companyName);

            if (employees != null)
            {
                newCompany.Employees.AddRange(employees);
            }

            return CompanyRepository.AddCompany(newCompany);
        }

        // Opdater et eksisterende firma
        public static void UpdateCompany(CompanyDTO companyDTO)
        {
            CompanyRepository.UpdateCompany(companyDTO);
        }

        // Slet et firma
        public static void DeleteCompany(string companyName)
        {
            CompanyRepository.DeleteCompany(companyName);
        }

        // Hent alle firmaer
        public static List<CompanyDTO> GetAllCompanies()
        {
            return CompanyRepository.GetCompanies();
        }

        // Hent et firma baseret på navn
        public static CompanyDTO GetCompanyByName(string companyName)
        {
            return CompanyRepository.GetCompany(companyName);
        }
    }
}
