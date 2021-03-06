﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class Department
    {
        public Department()
        {
            this.ScheduleDetails = new HashSet<ScheduleDetail>();
            this.Jobs = new HashSet<Job>();
        }

        public int DepartmentId { get; set; }
        public string Title { get; set; }

        public ICollection<ScheduleDetail> ScheduleDetails { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}