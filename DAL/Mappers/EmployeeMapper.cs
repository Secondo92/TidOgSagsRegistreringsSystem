using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class EmployeeMapper
    {
        public static EmployeeDTO Map(Employee employee)
        {
            if(employee == null)
            {
                return null;
            }

            EmployeeDTO employeeDTO = new EmployeeDTO(employee.CprNumber, employee.Name, employee.DepartmentName);

            return employeeDTO;
        }

        public static Employee Map(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return null;
            }

            Employee employee = new Employee(employeeDTO.CprNumber, employeeDTO.Name, employeeDTO.DepartmentName);

            return employee;
        }
    }
}
