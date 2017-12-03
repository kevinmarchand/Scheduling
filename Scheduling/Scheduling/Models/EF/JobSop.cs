using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class JobSop
    {
        public JobSop()
        {
            this.Jobs = new HashSet<Job>();
            this.Employees = new HashSet<Employee>();
        }
        public int JobSopId { get; set; }
        public string Title { get; set; }

        public ICollection<Job> Jobs { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}