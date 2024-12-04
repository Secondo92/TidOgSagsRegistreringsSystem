using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class DepartmentMapper
    {
        public static DepartmentDTO Map(Department department)
        {
            if (department == null)
            {
                return null;
            }

            DepartmentDTO departmentDTO = new DepartmentDTO(department.DepartmentName, department.DepartmentNumber);

            return departmentDTO;
        }

        public static Department Map(DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null)
            {
                return null;
            }

            Department department = new Department(departmentDTO.DepartmentName, departmentDTO.DepartmentNumber);

            return department;
        }
    }
}