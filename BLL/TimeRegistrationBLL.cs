using DAL.Repository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class TimeRegistrationBLL
    {
        // Opret en ny tidsregistrering
        public static TimeRegistrationDTO CreateTimeRegistration(int id, DateTime startTime, DateTime endTime, string employeeId, int caseNumber)
        {
            var newTimeRegistration = new TimeRegistrationDTO(id, startTime, endTime, employeeId, caseNumber);
            return TimeRegistrationRepository.AddTimeRegistration(newTimeRegistration);
        }

        public static TimeRegistrationDTO CreateTimeRegistration(int id, DateTime startTime, DateTime endTime, string employeeId)
        {
            var newTimeRegistration = new TimeRegistrationDTO(id, startTime, endTime, employeeId, null);
            return TimeRegistrationRepository.AddTimeRegistration(newTimeRegistration);
        }

        // Slet en tidsregistrering
        public static void DeleteTimeRegistration(int id)
        {
            TimeRegistrationRepository.DeleteTimeRegistration(id);
        }

        // Hent alle tidsregistreringer
        public static List<TimeRegistrationDTO> GetAllTimeRegistrations()
        {
            return TimeRegistrationRepository.GetTimeRegistrations();
        }

        // Hent en tidsregistrering baseret på ID
        public static TimeRegistrationDTO GetTimeRegistrationById(int id)
        {
            return TimeRegistrationRepository.GetTimeRegistration(id);
        }

        public static void RegisterTime(TimeRegistrationDTO timeRegistration)
        {
            if (timeRegistration.EndTime <= timeRegistration.StartTime)
                throw new Exception("Sluttid skal komme efter starttid.");

            TimeRegistrationRepository.AddTimeRegistration(timeRegistration);
        }

        public static List<TimeReportDTO> GetWeeklySummary(string employeeId)
        {
            var allRegistrations = TimeRegistrationRepository.GetTimeRegistrationsByEmployee(employeeId);

            var weeklyData = allRegistrations
                .GroupBy(r => System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                    r.StartTime,
                    System.Globalization.CalendarWeekRule.FirstDay,
                    DayOfWeek.Monday))
                .Select(g => new TimeReportDTO
                {
                    Period = $"Uge {g.Key}",
                    TotalHours = g.Sum(r => (r.EndTime - r.StartTime).TotalHours)
                })
                .ToList();

            return weeklyData;
        }


        public static void CreateTimeRegistration(TimeRegistrationDTO timeRegistration)
        {
            TimeRegistrationRepository.AddTimeRegistration(timeRegistration);
        }
        public static List<TimeReportDTO> GetMonthlySummary(string employeeId)
        {
            var allRegistrations = TimeRegistrationRepository.GetTimeRegistrationsByEmployee(employeeId);

            var monthlyData = allRegistrations
                .GroupBy(r => new { r.StartTime.Year, r.StartTime.Month })
                .Select(g => new TimeReportDTO
                {
                    Period = $"{g.Key.Month}/{g.Key.Year}",
                    TotalHours = g.Sum(r => (r.EndTime - r.StartTime).TotalHours)
                })
                .ToList();

            return monthlyData;
        }


        public static List<TimeReportDTO> GetTotalReport(string employeeId)
        {
            var allRegistrations = TimeRegistrationRepository.GetTimeRegistrationsByEmployee(employeeId);
            var totalHours = allRegistrations.Sum(r => (r.EndTime - r.StartTime).TotalHours);
            return new List<TimeReportDTO>
            {
                new TimeReportDTO { Period = "Total", TotalHours = totalHours }
            };
        }
    }
}
