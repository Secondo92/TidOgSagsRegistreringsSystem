using DAL.Context;
using DAL.Mappers;
using DAL.Models;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class DepartmentRepository
    {
        // Hent en afdeling baseret på afdelingsnummer
        public static DepartmentDTO GetDepartment(int departmentNumber)
        {
            using (var context = new DatabaseContext())
            {
                var departmentEntity = context.Departments.FirstOrDefault(d => d.DepartmentNumber == departmentNumber);
                return departmentEntity != null ? DepartmentMapper.Map(departmentEntity) : null;
            }
        }

        // Hent alle afdelinger
        public static List<DepartmentDTO> GetDepartments()
        {
            using (var context = new DatabaseContext())
            {
                return context.Departments.Select(DepartmentMapper.Map).ToList();
            }
        }

        // Tilføj en afdeling
        public static void AddDepartment(DepartmentDTO departmentDTO)
        {
            using (var context = new DatabaseContext())
            {
                var departmentEntity = DepartmentMapper.Map(departmentDTO);
                context.Departments.Add(departmentEntity);
                context.SaveChanges();
            }
        }

        // Opdater en afdeling
        public static void UpdateDepartment(DepartmentDTO departmentDTO)
        {
            using (var context = new DatabaseContext())
            {
                var departmentEntity = context.Departments.FirstOrDefault(d => d.DepartmentNumber == departmentDTO.DepartmentNumber);
                if (departmentEntity != null)
                {
                    departmentEntity.DepartmentName = departmentDTO.DepartmentName;
                    context.SaveChanges();
                }
            }
        }

        // Slet en afdeling
        public static void DeleteDepartment(int departmentNumber)
        {
            using (var context = new DatabaseContext())
            {
                var departmentEntity = context.Departments.FirstOrDefault(d => d.DepartmentNumber == departmentNumber);
                if (departmentEntity != null)
                {
                    context.Departments.Remove(departmentEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
