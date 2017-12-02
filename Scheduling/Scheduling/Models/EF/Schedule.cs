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
            this.Departments = new HashSet<Department>();
        }

        public int ScheduleId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}