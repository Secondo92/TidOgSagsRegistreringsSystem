using DAL.Models;
using DTO.Models;
using DAL.Repository;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BLL
{
    public class DepartmentBLL
    {
        // Opret en ny afdeling
        public static void CreateDepartment(string departmentName, int departmentNumber)
        {
            var department = new DepartmentDTO(departmentName, departmentNumber);
            DepartmentRepository.AddDepartment(department);
        }

        // Opdater en afdeling
        public static void UpdateDepartment(DepartmentDTO departmentDTO)
        {
            DepartmentRepository.UpdateDepartment(departmentDTO);
        }

        // Slet en afdeling
        public static void DeleteDepartment(int departmentNumber)
        {
            DepartmentRepository.DeleteDepartment(departmentNumber);
        }

        // Hent alle afdelinger
        public static List<DepartmentDTO> GetAllDepartments()
        {
            return DepartmentRepository.GetDepartments();
        }

        // Hent en afdeling baseret på nummer
        public static DepartmentDTO GetDepartmentByNumber(int departmentNumber)
        {
            return DepartmentRepository.GetDepartment(departmentNumber);
        }
    }
}
