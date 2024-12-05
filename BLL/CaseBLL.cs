using DAL.Models;
using DTO.Models;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class CaseBLL
    {
        // Opret en ny sag
        public static CaseDTO CreateCase(int caseNumber, string headline, string description, string departmentName)
        {
            var newCase = new CaseDTO(caseNumber, headline, description, departmentName);
            return CaseRepository.AddCase(newCase);
        }

        public static CaseDTO CreateCase(CaseDTO Case)
        {
            return CaseRepository.AddCase(Case);
        }


        // Opdater en eksisterende sag
        public static void UpdateCase(CaseDTO caseDTO)
        { 
            CaseRepository.UpdateCase(caseDTO);
        }

        // Slet en sag
        public static void DeleteCase(int caseNumber)
        {
            CaseRepository.DeleteCase(caseNumber);
        }

        // Hent alle sager
        public static List<CaseDTO> GetAllCases()
        {
            return CaseRepository.GetCases();
        }

        // Hent en sag baseret på navn
        public static CaseDTO GetCaseByName(string name)
        {
            var cases = CaseRepository.GetCases();
            return cases.FirstOrDefault(c => c.Headline == name);
        }

        public static CaseDTO GetCaseById(int caseId)
        {
            var cases = CaseRepository.GetCases();
            return cases.FirstOrDefault(c => c.CaseNumber == caseId);
        }


    }
}
