using DAL.Context;
using DAL.Mappers;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CompanyRepository
    {
        // Hent et firma baseret på navn
        public static CompanyDTO GetCompany(string companyName)
        {
            using (var context = new DatabaseContext())
            {
                var companyEntity = context.Companies.FirstOrDefault(c => c.CompanyName == companyName);
                return companyEntity != null ? CompanyMapper.Map(companyEntity) : null;
            }
        }

        // Hent alle firmaer
        public static List<CompanyDTO> GetCompanies()
        {
            using (var context = new DatabaseContext())
            {
                var companies = context.Companies.ToList();
                return companies.Select(CompanyMapper.Map).ToList();
            }
        }

        // Tilføj et firma
        public static CompanyDTO AddCompany(CompanyDTO companyDTO)
        {
            using (var context = new DatabaseContext())
            {
                var companyEntity = CompanyMapper.Map(companyDTO);
                context.Companies.Add(companyEntity);
                context.SaveChanges();
                return companyDTO;
            }
        }

        // Opdater et firma
        public static void UpdateCompany(CompanyDTO companyDTO)
        {
            using (var context = new DatabaseContext())
            {
                var companyEntity = context.Companies.FirstOrDefault(c => c.CompanyName == companyDTO.CompanyName);
                if (companyEntity != null)
                {
                    companyEntity.Employees = companyDTO.Employees.Select(EmployeeMapper.Map).ToList();
                    context.SaveChanges();
                }
            }
        }

        // Slet et firma
        public static void DeleteCompany(string companyName)
        {
            using (var context = new DatabaseContext())
            {
                var companyEntity = context.Companies.FirstOrDefault(c => c.CompanyName == companyName);
                if (companyEntity != null)
                {
                    context.Companies.Remove(companyEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
