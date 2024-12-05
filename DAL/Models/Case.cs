using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Case
    {
        [Key]
        public int CaseNumber { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string DepartmentName { get; set; }
        public Case()
        {

        }

        public Case(int caseNumber, string headline, string description, string departmentName)
        {
            CaseNumber = caseNumber;
            Headline = headline;
            Description = description;
            DepartmentName = departmentName;
        }

        public Case(int caseNumber, string headline, string description)
        {
            CaseNumber = caseNumber;
            Headline = headline;
            Description = description;
        }
    }
}
