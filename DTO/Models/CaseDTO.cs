using System;
using System.Collections.Generic;
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
        public int DepartmentNumber { get; set; }

        public CaseDTO()
        {

        }

        public CaseDTO(int caseNumber, string headline, string description, int departmentNumber)
        {
            CaseNumber = caseNumber;
            Headline = headline;
            Description = description;
            DepartmentNumber = departmentNumber;
        }

        public CaseDTO(int caseNumber, string headline, string description)
        {
            CaseNumber = caseNumber;
            Headline = headline;
            Description = description;
        }
    }
}
