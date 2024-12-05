using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class CaseDTO
    {
        public int CaseNumber { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string DepartmentName { get; set; }

        public CaseDTO()
        {

        }

        public CaseDTO(int caseNumber, string headline, string description, string departmentName)
        {
            CaseNumber = caseNumber;
            Headline = headline;
            Description = description;
            DepartmentName = departmentName;
        }

        public CaseDTO(int caseNumber, string headline, string description)
        {
            CaseNumber = caseNumber;
            Headline = headline;
            Description = description;
        }
    }
}
