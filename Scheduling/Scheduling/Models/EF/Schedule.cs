using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class Schedule
    {
        public Schedule()
        {
            this.scheduleDetails = new HashSet<ScheduleDetail>();
        }

        public int ScheduleId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public string Comment { get; set; }

        public ICollection<ScheduleDetail> scheduleDetails { get; set; }
    }
}