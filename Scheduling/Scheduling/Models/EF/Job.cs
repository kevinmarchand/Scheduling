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
            this.Departments = new HashSet<Department>();
            this.Employees = new HashSet<Employee>();
        }

        public int JobId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}