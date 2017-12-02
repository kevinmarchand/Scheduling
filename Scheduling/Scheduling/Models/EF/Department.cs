using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class Department
    {
        public Department()
        {
            this.Schedules = new HashSet<Schedule>();
            this.Jobs = new HashSet<Job>();
        }

        public int DepartmentId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}