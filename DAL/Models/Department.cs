using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
    {
        [Key]
        public int DepartmentNumber { get; set; }
        public string DepartmentName { get; set; }
        public Department()
        {
        }
        public Department(string departmentName, int departmentNumber)
        {
            this.DepartmentName = departmentName;
            this.DepartmentNumber = departmentNumber;
        }
    }
}
