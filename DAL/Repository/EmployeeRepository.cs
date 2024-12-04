using DAL.Context;
using DAL.Mappers;
using DAL.Models;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class EmployeeRepository
    {
        // Henter en enkelt medarbejder baseret på CPR-nummer
        public static EmployeeDTO GetEmployee(string cprNumber)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var employee = context.Employees
                    .FirstOrDefault(e => e.CprNumber == cprNumber);

                return employee != null ? EmployeeMapper.Map(employee) : null;
            }
        }

        // Henter alle medarbejdere
        public static List<EmployeeDTO> GetEmployees()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var employees = context.Employees.ToList();
                return employees.Select(EmployeeMapper.Map).ToList();
            }
        }

        // Tilføjer en ny medarbejder
        public static EmployeeDTO AddEmployee(EmployeeDTO employeeDTO)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                Employee employee = EmployeeMapper.Map(employeeDTO);
                context.Employees.Add(employee);
                context.SaveChanges();

                return employeeDTO;
            }
        }

        // Opdaterer en eksisterende medarbejder
        public static void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                Employee existingEmployee = context.Employees
                    .FirstOrDefault(e => e.CprNumber == employeeDTO.CprNumber);

                if (existingEmployee != null)
                {
                    existingEmployee.Name = employeeDTO.Name;
                    existingEmployee.DepartmentName = employeeDTO.DepartmentName;

                    context.SaveChanges();
                }
            }
        }

        // Sletter en medarbejder
        public static void DeleteEmployee(string cprNumber)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                Employee employee = context.Employees
                    .FirstOrDefault(e => e.CprNumber == cprNumber);

                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
            }
        }
    }
}
