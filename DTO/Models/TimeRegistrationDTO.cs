using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class TimeRegistrationDTO
    {
        public int TimeRegistrationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EmployeeId { get; set; }
        public int? CaseNumber { get; set; }
        public TimeRegistrationDTO()
        {

        }
        public TimeRegistrationDTO(int timeRegistrationId, DateTime startTime, DateTime endTime, string employeeId, int? caseNumber)
        {
            TimeRegistrationId = timeRegistrationId;
            StartTime = startTime;
            EndTime = endTime;
            EmployeeId = employeeId;
            CaseNumber = caseNumber;
        }
        public TimeSpan TimeSpent
        {
            get
            {
                return StartTime - EndTime;
            }
        }
    }
}
