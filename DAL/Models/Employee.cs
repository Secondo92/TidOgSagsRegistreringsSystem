using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee
    {
        [Key]
        public string CprNumber { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Initials { get; set; }
        public Employee()
        {

        }
        public Employee(string cprNumber, string name, string departmentName)
        {
            CprNumber = cprNumber;
            Name = name;
            DepartmentName = departmentName;
            Initials = GetInitials(name);

        }

        public Employee(string cprNumber, string name)
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
