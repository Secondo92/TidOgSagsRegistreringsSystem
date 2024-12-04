using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class EmployeeDTO
    {
        public string CprNumber { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Initials { get; private set; }
        public EmployeeDTO()
        {

        }
        public EmployeeDTO(string cprNumber, string name, string departmentName)
        {
            CprNumber = cprNumber;
            Name = name;
            DepartmentName = departmentName;
            Initials = GetInitials(name);
        }

        public EmployeeDTO(string cprNumber, string name)
        {
            CprNumber = cprNumber;
            Name = name;
            Initials = GetInitials(name);
        }

        private string GetInitials(string name)
        {
            string[] words = name.Split(' ');
            string initials = "";

            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    initials += word[0];
                }
            }
            return initials;
        }
    }
}
