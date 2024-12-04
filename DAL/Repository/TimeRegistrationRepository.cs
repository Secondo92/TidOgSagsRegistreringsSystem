using DAL.Context;
using DAL.Mappers;
using DAL.Models;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class TimeRegistrationRepository
    {
        // Hent en tidsregistrering baseret på ID
        public static TimeRegistrationDTO GetTimeRegistration(int id)
        {
            using (var context = new DatabaseContext())
            {
                var timeRegistrationEntity = context.TimeRegistrations.FirstOrDefault(t => t.TimeRegistrationId == id);
                return timeRegistrationEntity != null ? TimeRegistrationMapper.Map(timeRegistrationEntity) : null;
            }
        }

        // Hent alle tidsregistreringer
        public static List<TimeRegistrationDTO> GetTimeRegistrations()
        {
            using (var context = new DatabaseContext())
            {
                var timeRegistrations = context.TimeRegistrations.ToList();
                return timeRegistrations.Select(TimeRegistrationMapper.Map).ToList();
            }
        }

        // Tilføj en tidsregistrering
        public static TimeRegistrationDTO AddTimeRegistration(TimeRegistrationDTO timeRegistrationDTO)
        {
            using (var context = new DatabaseContext())
            {
                var timeRegistrationEntity = TimeRegistrationMapper.Map(timeRegistrationDTO);
                context.TimeRegistrations.Add(timeRegistrationEntity);
                context.SaveChanges();
                return timeRegistrationDTO;
            }
        }

        // Slet en tidsregistrering
        public static void DeleteTimeRegistration(int id)
        {
            using (var context = new DatabaseContext())
            {
                var timeRegistrationEntity = context.TimeRegistrations.FirstOrDefault(t => t.TimeRegistrationId == id);
                if (timeRegistrationEntity != null)
                {
                    context.TimeRegistrations.Remove(timeRegistrationEntity);
                    context.SaveChanges();
                }
            }
        }

        public static List<TimeRegistrationDTO> GetTimeRegistrationsByEmployee(string employeeId)
        {
            using (var context = new DatabaseContext())
            {
                var timeRegistrations = context.TimeRegistrations.Where(t => t.EmployeeId == employeeId).ToList();
                return timeRegistrations.Select(TimeRegistrationMapper.Map).ToList();
            }
        }
    }
}
