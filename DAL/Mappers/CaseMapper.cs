using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class CaseMapper
    {
        public static CaseDTO Map(Case Case)
        {
            if (Case == null)
            {
                return null;
            }

            CaseDTO caseDTO = new CaseDTO(Case.CaseNumber, Case.Headline, Case.Description, Case.DepartmentNumber);

            return caseDTO;
        }

        public static Case Map(CaseDTO caseDTO)
        {
            if (caseDTO == null)
            {
                return null;
            }

            Case Case = new Case(caseDTO.CaseNumber, caseDTO.Headline, caseDTO.Description, caseDTO.DepartmentNumber);

            return Case;
        }
    }
}