using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class TimeRegistrationMapper
    {
        public static TimeRegistrationDTO Map(TimeRegistration timeRegistration)
        {
            if (timeRegistration == null)
            {
                return null;
            }

            TimeRegistrationDTO timeRegistrationDTO = new TimeRegistrationDTO(
                timeRegistration.TimeRegistrationId, timeRegistration.StartTime,
                timeRegistration.EndTime, timeRegistration.EmployeeId, timeRegistration.CaseNumber);

            return timeRegistrationDTO;
        }

        public static TimeRegistration Map(TimeRegistrationDTO timeRegistrationDTO)
        {
            if (timeRegistrationDTO == null)
            {
                return null;
            }

            TimeRegistration timeRegistration = new TimeRegistration(
                timeRegistrationDTO.TimeRegistrationId, timeRegistrationDTO.StartTime,
                timeRegistrationDTO.EndTime, timeRegistrationDTO.EmployeeId, timeRegistrationDTO.CaseNumber);

            return timeRegistration;
        }
    }
}