using DAL.Context;
using DAL.Mappers;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CaseRepository
    {
        // Hent en sag baseret på sagsnummer
        public static CaseDTO GetCase(int caseNumber)
        {
            using (var context = new DatabaseContext())
            {
                var caseEntity = context.Cases.FirstOrDefault(c => c.CaseNumber == caseNumber);
                return caseEntity != null ? CaseMapper.Map(caseEntity) : null;
            }
        }

        // Hent alle sager
        public static List<CaseDTO> GetCases()
        {
            using (var context = new DatabaseContext())
            {
                var cases = context.Cases.ToList();
                return cases.Select(CaseMapper.Map).ToList();
            }
        }

        // Tilføj en sag
        public static CaseDTO AddCase(CaseDTO caseDTO)
        {
            using (var context = new DatabaseContext())
            {
                var caseEntity = CaseMapper.Map(caseDTO);
                context.Cases.Add(caseEntity);
                context.SaveChanges();
                return caseDTO;
            }
        }

        // Opdater en sag
        public static void UpdateCase(CaseDTO caseDTO)
        {
            using (var context = new DatabaseContext())
            {
                var caseEntity = context.Cases.FirstOrDefault(c => c.CaseNumber == caseDTO.CaseNumber);
                if (caseEntity != null)
                {
                    caseEntity.Headline = caseDTO.Headline;
                    caseEntity.Description = caseDTO.Description;
                    caseEntity.DepartmentName = caseDTO.DepartmentName;
                    context.SaveChanges();
                }
            }
        }

        // Slet en sag
        public static void DeleteCase(int caseNumber)
        {
            using (var context = new DatabaseContext())
            {
                var caseEntity = context.Cases.FirstOrDefault(c => c.CaseNumber == caseNumber);
                if (caseEntity != null)
                {
                    context.Cases.Remove(caseEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
