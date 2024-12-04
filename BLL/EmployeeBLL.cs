using DAL.Models;
using DTO.Models;
using DAL.Repository;
using System.Collections.Generic;

namespace BLL
{
    public class EmployeeBLL
    {
        // Opret en ny medarbejder
        public static EmployeeDTO CreateEmployee(string cprNumber, string name, string departmentName)
        {
            var newEmployee = new EmployeeDTO
            {
                CprNumber = cprNumber,
                Name = name,
                DepartmentName = departmentName
            };
            return EmployeeRepository.AddEmployee(newEmployee);
        }

        public static EmployeeDTO CreateEmployee(EmployeeDTO employee)
        {
            return EmployeeRepository.AddEmployee(employee);
        }

        // Opdater en medarbejder
        public static void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            EmployeeRepository.UpdateEmployee(employeeDTO);
        }

        // Slet en medarbejder
        public static void DeleteEmployee(string cprNumber)
        {
            EmployeeRepository.DeleteEmployee(cprNumber);
        }

        // Hent alle medarbejdere
        public static List<EmployeeDTO> GetAllEmployees()
        {
            return EmployeeRepository.GetEmployees();
        }

        // Hent en medarbejder baseret på CPR
        public static EmployeeDTO GetEmployeeByCpr(string cprNumber)
        {
            return EmployeeRepository.GetEmployee(cprNumber);
        }
    }
}
