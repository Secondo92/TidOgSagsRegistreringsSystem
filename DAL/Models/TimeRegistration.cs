using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TimeRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeRegistrationId { get; set; }


        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public string EmployeeId { get; set; }
        public int? CaseNumber { get; set; } 

        public TimeRegistration()
        {

        }
        public TimeRegistration(int timeRegistrationId, DateTime startTime, DateTime endTime, string employeeId, int? caseNumber)
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
