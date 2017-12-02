using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class Job
    {
        public Job()
        {
            this.Schedules = new HashSet<Schedule>();
            this.Employees = new HashSet<Employee>();
        }

        public int JobId { get; set; }
        public string Title { get; set; }

        public int DeparmentId { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}